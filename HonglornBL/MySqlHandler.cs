using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using static HonglornBL.Prerequisites;

namespace HonglornBL {
  class MySqlHandler {
    static readonly Dictionary<string, GameType> GameTypeDictionary =
      new Dictionary<string, GameType> {
        {"Competition", GameType.Competition},
        {"Traditional", GameType.Traditional},
        {string.Empty, GameType.Unspecified}
      };

    static readonly Dictionary<Discipline, string> CompetitionDisciplinesViewNames =
      new Dictionary<Discipline, string> {
        {Discipline.Sprint, "CompetitionSprintDisciplines"},
        {Discipline.Jump, "CompetitionJumpDisciplines"},
        {Discipline.Throw, "CompetitionThrowDisciplines"},
        {Discipline.MiddleDistance, "CompetitionMiddleDistanceDisciplines"}
      };

    static readonly Dictionary<Tuple<Sex, Discipline>, string> TraditionalDisciplinesViewNames =
      new Dictionary<Tuple<Sex, Discipline>, string> {
        {new Tuple<Sex, Discipline>(Sex.Male, Discipline.Sprint), "TraditionalMaleSprintDisciplines"},
        {new Tuple<Sex, Discipline>(Sex.Male, Discipline.Jump), "TraditionalMaleJumpDisciplines"},
        {new Tuple<Sex, Discipline>(Sex.Male, Discipline.Throw), "TraditionalMaleThrowDisciplines"},
        {new Tuple<Sex, Discipline>(Sex.Male, Discipline.MiddleDistance), "TraditionalMaleMiddleDistanceDisciplines"},
        {new Tuple<Sex, Discipline>(Sex.Female, Discipline.Sprint), "TraditionalFemaleSprintDisciplines"},
        {new Tuple<Sex, Discipline>(Sex.Female, Discipline.Jump), "TraditionalFemaleJumpDisciplines"},
        {new Tuple<Sex, Discipline>(Sex.Female, Discipline.Throw), "TraditionalFemaleThrowDisciplines"},
        {new Tuple<Sex, Discipline>(Sex.Female, Discipline.MiddleDistance), "TraditionalFemaleMiddleDistanceDisciplines"}
      };

    readonly string conString;

    public MySqlHandler(string server, uint port, string username, string password, string database) {
      MySqlConnectionStringBuilder oConStringBuilder = new MySqlConnectionStringBuilder {
        Server = server,
        Port = port,
        UserID = username,
        Password = password,
        Database = database,
        CharacterSet = "utf8"
      };

      conString = oConStringBuilder.GetConnectionString(true);
    }

    //todo: handle exception when connection cannot be established
    MySqlConnection GetConnection() {
      return new MySqlConnection(conString);
    }

    /// <summary>
    ///   Returns an array containing all years for which there is student data present.
    /// </summary>
    /// <returns>An array containing the years.</returns>
    public int[] GetYearsWithStudentData() {
      DataSet ds = new DataSet();
      IDataAdapter da = new MySqlDataAdapter("SELECT * FROM ValidYears", GetConnection());

      da.Fill(ds);

      List<int> years = new List<int>();

      foreach (DataRow row in ds.Tables[0].Rows) {
        years.Add(Convert.ToInt32(row["year"]));
      }

      return years.ToArray();
    }

    public string[] GetValidCourseNames(int year) {
      MySqlCommand selectCommand = new MySqlCommand {
        Connection = GetConnection(),
        CommandText = "SELECT DISTINCT CourseName FROM StudentCourseRel WHERE year = @iYear ORDER BY CourseName ASC"
      };

      selectCommand.Parameters.AddWithValue("@iYear", year);

      DataTable dt = new DataTable();

      using (MySqlDataAdapter da = new MySqlDataAdapter(selectCommand)) {
        da.Fill(dt);
      }

      List<string> resultList = new List<string>();

      foreach (DataRow row in dt.Rows) {
        resultList.Add(row[0].ToString());
      }

      return resultList.ToArray();
    }

    public char[] GetValidClassNames(int year) {
      MySqlCommand oSelectCommand = new MySqlCommand();
      DataTable oDataTable = new DataTable();

      oSelectCommand.Connection = GetConnection();
      oSelectCommand.CommandText =
        "SELECT DISTINCT ClassName FROM StudentCourseRel INNER JOIN CourseClassRel ON StudentCourseRel.CourseName = CourseClassRel.CourseName INNER JOIN Class on courseclassrel.ClassName = Class.Name WHERE StudentCourseRel.year = @iYear ORDER BY ClassName ASC";
      oSelectCommand.Parameters.AddWithValue("@iYear", year);

      using (MySqlDataAdapter oDataAdapter = new MySqlDataAdapter(oSelectCommand)) {
        oDataAdapter.Fill(oDataTable);
      }

      int iArrayLength = oDataTable.Rows.Count - 1;
      char[] acResult = new char[iArrayLength + 1];

      for (int iRow = 0; iRow <= iArrayLength; iRow++) {
        char cCurrentClass = Convert.ToChar(oDataTable.Rows[iRow][0]);

        if (IsValidClassName(cCurrentClass)) {
          acResult[iRow] = Convert.ToChar(oDataTable.Rows[iRow][0]);
        } else {
          throw new ArgumentOutOfRangeException($"Invalid ClassName {cCurrentClass} received from database.");
        }
      }

      return acResult;
    }

    /// <summary>
    ///   Returns a data table with information about the allowed traditional disciplines, i.e. the disciplines that can be
    ///   selected for the given parameters.
    /// </summary>
    /// <param name="sex">The students' gender.</param>
    /// <param name="discipline">The disciple type to be looked up.</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public DataTable GetValidTraditionalDisciplinesTable(Sex sex, Discipline discipline) {
      MySqlCommand selectCommand = new MySqlCommand {
        Connection = GetConnection(),
        CommandText =
          $"Select * from {TraditionalDisciplinesViewNames[new Tuple<Sex, Discipline>(sex, discipline)]}"
      };

      DataTable dt = new DataTable();

      using (MySqlDataAdapter da = new MySqlDataAdapter(selectCommand)) {
        da.Fill(dt);
      }

      return dt;
    }

    public DataTable GetValidCompetitionDisciplinesTable(Discipline discipline) {
      MySqlCommand selectCommand = new MySqlCommand {
        CommandText = $"Select * from {CompetitionDisciplinesViewNames[discipline]}",
        Connection = GetConnection()
      };

      DataTable dataTable = new DataTable();

      using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(selectCommand)) {
        dataAdapter.Fill(dataTable);
      }

      return dataTable;
    }

    public GameType GetGameType(char classNames, uint year) {
      GameType functionReturnValue;

      if (IsValidYear(year) && IsValidClassName(classNames)) {
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

    public void ImportStudentData(string surname, string forename, string courseName, char className, Sex sex, uint yearOfBirth, uint year) {
      MySqlCommand cmd = new MySqlCommand("ImportStudent", GetConnection()) {
        CommandType = CommandType.StoredProcedure
      };

      cmd.Parameters.AddWithValue("@sSurname", surname);
      cmd.Parameters.AddWithValue("@sForename", forename);
      cmd.Parameters.AddWithValue("@cCourseName", courseName);
      cmd.Parameters.AddWithValue("@cClassName", className);
      cmd.Parameters.AddWithValue("@eSex", sex.ToString());
      cmd.Parameters.AddWithValue("@yYearOfBirth", yearOfBirth);
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