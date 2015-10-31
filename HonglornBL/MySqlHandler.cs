using System;
using System.Collections.Generic;
using System.Data;
using HonglornBL.Models;
using MySql.Data.MySqlClient;
using static HonglornBL.Prerequisites;

namespace HonglornBL {
  class MySqlHandler {
    static readonly Dictionary<string, GameType> GameTypeDictionary =
      new Dictionary<string, GameType> {
        {"Competition", GameType.Competition},
        {"Traditional", GameType.Traditional}
      };

    static readonly Dictionary<DisciplineType, string> CompetitionDisciplinesViewNames =
      new Dictionary<DisciplineType, string> {
        {DisciplineType.Sprint, "CompetitionSprintDisciplines"},
        {DisciplineType.Jump, "CompetitionJumpDisciplines"},
        {DisciplineType.Throw, "CompetitionThrowDisciplines"},
        {DisciplineType.MiddleDistance, "CompetitionMiddleDistanceDisciplines"}
      };

    static readonly Dictionary<Tuple<Sex, DisciplineType>, string> TraditionalDisciplinesViewNames =
      new Dictionary<Tuple<Sex, DisciplineType>, string> {
        {new Tuple<Sex, DisciplineType>(Sex.Male, DisciplineType.Sprint), "TraditionalMaleSprintDisciplines"},
        {new Tuple<Sex, DisciplineType>(Sex.Male, DisciplineType.Jump), "TraditionalMaleJumpDisciplines"},
        {new Tuple<Sex, DisciplineType>(Sex.Male, DisciplineType.Throw), "TraditionalMaleThrowDisciplines"},
        {new Tuple<Sex, DisciplineType>(Sex.Male, DisciplineType.MiddleDistance), "TraditionalMaleMiddleDistanceDisciplines"},
        {new Tuple<Sex, DisciplineType>(Sex.Female, DisciplineType.Sprint), "TraditionalFemaleSprintDisciplines"},
        {new Tuple<Sex, DisciplineType>(Sex.Female, DisciplineType.Jump), "TraditionalFemaleJumpDisciplines"},
        {new Tuple<Sex, DisciplineType>(Sex.Female, DisciplineType.Throw), "TraditionalFemaleThrowDisciplines"},
        {new Tuple<Sex, DisciplineType>(Sex.Female, DisciplineType.MiddleDistance), "TraditionalFemaleMiddleDistanceDisciplines"}
      };

    readonly string connectionString;

    public MySqlHandler(string server, uint port, string username, string password, string database) {
      MySqlConnectionStringBuilder conStringBuilder = new MySqlConnectionStringBuilder {
        Server = server,
        Port = port,
        UserID = username,
        Password = password,
        Database = database,
        CharacterSet = "utf8"
      };

      connectionString = conStringBuilder.GetConnectionString(true);
    }

    //todo: handle exception when connection cannot be established
    MySqlConnection GetConnection() {
      return new MySqlConnection(connectionString);
    }

    /// <summary>
    ///   Returns an array containing all years for which there is student data present.
    /// </summary>
    /// <returns>An array containing the years.</returns>
    public ICollection<int> GetYearsWithStudentData() {
      MySqlCommand selectCommand = new MySqlCommand {
        Connection = GetConnection(),
        CommandText = "SELECT * FROM ValidYears"
      };

      DataTable table = GetFilledDataTable(selectCommand);

      ICollection<int> years = new List<int>();

      foreach (DataRow row in table.Rows) {
        years.Add(Convert.ToInt32(row["year"]));
      }

      return years;
    }

    public ICollection<string> GetValidCourseNames(int year) {
      MySqlCommand selectCommand = new MySqlCommand {
        Connection = GetConnection(),
        CommandText = "SELECT DISTINCT CourseName FROM StudentCourseRel WHERE year = @iYear ORDER BY CourseName ASC"
      };

      selectCommand.Parameters.AddWithValue("@iYear", year);

      DataTable dt = GetFilledDataTable(selectCommand);

      ICollection<string> resultList = new List<string>();

      foreach (DataRow row in dt.Rows) {
        resultList.Add(row[0].ToString());
      }

      return resultList;
    }

    static DataTable GetFilledDataTable(MySqlCommand selectCommand) {
      DataTable table = new DataTable();

      using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand)) {
        adapter.Fill(table);
      }

      return table;
    }

    public ICollection<char> GetValidClassNames(uint year) {
      MySqlCommand selectCommand = new MySqlCommand {
        Connection = GetConnection(),
        CommandText = "SELECT DISTINCT ClassName FROM StudentCourseRel INNER JOIN CourseClassRel ON StudentCourseRel.CourseName = CourseClassRel.CourseName INNER JOIN Class on courseclassrel.ClassName = Class.Name WHERE StudentCourseRel.year = @iYear ORDER BY ClassName ASC"
      };

      selectCommand.Parameters.AddWithValue("@iYear", year);

      DataTable dt = GetFilledDataTable(selectCommand);

      ICollection<char> classNames = new List<char>();

      foreach (DataRow row in dt.Rows) {
        char currentClass = Convert.ToChar(row[0]);

        if (IsValidClassName(currentClass)) {
          classNames.Add(currentClass);
        } else {
          throw new DataException($"Invalid ClassName {currentClass} received from database.");
        }
      }

      return classNames;
    }

    /// <summary>
    ///   Returns a data table with information about the allowed traditional disciplines, i.e. the disciplines that can be
    ///   selected for the given parameters.
    /// </summary>
    /// <param name="sex">The students' gender.</param>
    /// <param name="discipline">The disciple type to be looked up.</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public DataTable GetValidTraditionalDisciplinesTable(Sex sex, DisciplineType discipline) {
      return GetFilledDataTable($"Select * from {TraditionalDisciplinesViewNames[new Tuple<Sex, DisciplineType>(sex, discipline)]}");
    }

    public DataTable GetValidCompetitionDisciplinesTable(DisciplineType discipline) {
      return GetFilledDataTable($"Select * from {CompetitionDisciplinesViewNames[discipline]}");
    }

    DataTable GetFilledDataTable(string commandText) {
      MySqlCommand selectCommand = new MySqlCommand {
        Connection = GetConnection(),
        CommandText = commandText
      };

      return GetFilledDataTable(selectCommand);
    }

    public GameType GetGameType(char classNames, ushort year) {
      GameType functionReturnValue;

      if (IsValidYear((short) year) && IsValidClassName(classNames)) {
        //todo: fix casting
        MySqlCommand oSelectCommand = new MySqlCommand {
          CommandType = CommandType.StoredProcedure,
          Connection = GetConnection(),
          CommandText = "GetGameType"
        };

        oSelectCommand.Parameters.AddWithValue("@cClassName", classNames);
        oSelectCommand.Parameters.AddWithValue("@yYear", year);

        MySqlParameter oReturnParameter = new MySqlParameter {
          Direction = ParameterDirection.ReturnValue,
          ParameterName = "@eReturnValue",
          MySqlDbType = MySqlDbType.Enum
        };

        oSelectCommand.Parameters.Add(oReturnParameter);

        try {
          oSelectCommand.Connection.Open();
          oSelectCommand.ExecuteNonQuery();

          string returnedGameType = oReturnParameter.Value.ToString();

          if (!GameTypeDictionary.TryGetValue(returnedGameType, out functionReturnValue)) {
            throw new DataException($"Invalid GameType received from database: {returnedGameType}");
          }
        } finally {
          oSelectCommand.Connection?.Close();
        }
      } else {
        //todo: distiguish between which provided argument is invalid
        throw new ArgumentException($"Invalid year or class name provided. Year: {year}; Class Name: {classNames}");
      }
      return functionReturnValue;
    }

    public MySqlDataAdapter GetRawDataEditAdapter(string sCourseName, int year) {
      MySqlDataAdapter oDataAdapter = new MySqlDataAdapter();
      MySqlCommand oSelectCommand = new MySqlCommand {
        Connection = GetConnection(),
        CommandText =
          "SELECT Student.PKey, Surname, Forename, Sex, Sprint, Jump, Throw, MiddleDistance FROM Student INNER JOIN StudentCourseRel ON Student.Pkey = StudentCourseRel.StudentPKey LEFT JOIN Competition On Student.PKey = Competition.StudentPKey and Competition.Year = @Year WHERE StudentCourseRel.Year = @Year AND StudentCourseRel.CourseName = @CourseName ORDER BY Surname ASC, Forename ASC"
      };

      oSelectCommand.Parameters.AddWithValue("@Year", year);
      oSelectCommand.Parameters.AddWithValue("@CourseName", sCourseName);

      MySqlCommand oUpdateCommand = new MySqlCommand("EnterCompetitionValues", GetConnection()) {
        CommandType = CommandType.StoredProcedure
      };

      oUpdateCommand.Parameters.AddWithValue("yYear", year);

      oUpdateCommand.Parameters.Add("cPKey", MySqlDbType.Guid, 36, "PKey");
      //todo: figure out, what exactly the size does for float :D
      oUpdateCommand.Parameters.Add("fSprintValue", MySqlDbType.Float, 7, "Sprint");
      oUpdateCommand.Parameters.Add("fJumpValue", MySqlDbType.Float, 7, "Jump");
      oUpdateCommand.Parameters.Add("fThrowValue", MySqlDbType.Float, 7, "Throw");
      oUpdateCommand.Parameters.Add("fMiddleDistanceValue", MySqlDbType.Float, 7, "MiddleDistance");

      oDataAdapter.SelectCommand = oSelectCommand;
      oDataAdapter.UpdateCommand = oUpdateCommand;

      return oDataAdapter;
    }

    public MySqlDataAdapter GetDisciplinesEditAdapter(char className, int year) {
      MySqlDataAdapter oDataAdapter = new MySqlDataAdapter();
      MySqlCommand oSelectCommand = new MySqlCommand {
        Connection = GetConnection(),
        CommandText = "SELECT * FROM ClassDisciplineMeta WHERE ClassName = @cClassName AND YEAR = @yYear"
      };

      oSelectCommand.Parameters.AddWithValue("@cClassName", className);
      oSelectCommand.Parameters.AddWithValue("@yYear", year);

      MySqlCommand oUpdateCommand = new MySqlCommand("EnterDisciplineMeta", GetConnection()) {
        CommandType = CommandType.StoredProcedure
      };

      oUpdateCommand.Parameters.AddWithValue("cClassName", className);
      oUpdateCommand.Parameters.AddWithValue("yYear", year);

      oUpdateCommand.Parameters.Add("eGameType", MySqlDbType.Enum, 1, "GameType");
      // todo: test this
      oUpdateCommand.Parameters.Add("cMaleSprintPKey", MySqlDbType.Guid, 36, "MaleSprintPKey");
      oUpdateCommand.Parameters.Add("cMaleJumpPKey", MySqlDbType.Guid, 36, "MaleJumpPKey");
      oUpdateCommand.Parameters.Add("cMaleThrowPKey", MySqlDbType.Guid, 36, "MaleThrowPKey");
      oUpdateCommand.Parameters.Add("cMaleMiddleDistancePKey", MySqlDbType.Guid, 36, "MaleMiddleDistancePKey");
      oUpdateCommand.Parameters.Add("cFemaleSprintPKey", MySqlDbType.Guid, 36, "FemaleSprintPKey");
      oUpdateCommand.Parameters.Add("cFemaleJumpPKey", MySqlDbType.Guid, 36, "FemaleJumpPKey");
      oUpdateCommand.Parameters.Add("cFemaleThrowPKey", MySqlDbType.Guid, 36, "FemaleThrowPKey");
      oUpdateCommand.Parameters.Add("cFemaleMiddleDistancePKey", MySqlDbType.Guid, 36, "FemaleMiddleDistancePKey");

      oDataAdapter.SelectCommand = oSelectCommand;
      oDataAdapter.UpdateCommand = oUpdateCommand;

      return oDataAdapter;
    }

    public void ImportStudentData(Student student, char className, uint year) {
      MySqlCommand cmd = new MySqlCommand("ImportStudent", GetConnection()) {
        CommandType = CommandType.StoredProcedure
      };

      cmd.Parameters.AddWithValue("@sSurname", student.Surname);
      cmd.Parameters.AddWithValue("@sForename", student.Forename);
      //cmd.Parameters.AddWithValue("@cCourseName", student.CourseName);//todo: just commented out to build
      cmd.Parameters.AddWithValue("@cClassName", className);
      cmd.Parameters.AddWithValue("@eSex", student.Sex.ToString());
      cmd.Parameters.AddWithValue("@yYearOfBirth", student.YearOfBirth);
      cmd.Parameters.AddWithValue("@yYear", year);

      try {
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
      } finally {
        cmd.Connection?.Close();
      }
    }
  }
}