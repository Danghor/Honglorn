using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace HonglornBL {
  class MySqlHandler {
    readonly string _sConnectionString;

    public MySqlHandler(string sServer, uint iPort, string sUsername, string sPassword, string sDatabase) {
      MySqlConnectionStringBuilder oConStringBuilder = new MySqlConnectionStringBuilder {
        Server = sServer,
        Port = iPort,
        UserID = sUsername,
        Password = sPassword,
        Database = sDatabase,
        CharacterSet = "utf8"
      };


      _sConnectionString = oConStringBuilder.GetConnectionString(true);
    }

    //todo: handle exception when connection cannot be established
    MySqlConnection GetConnection() {
      return new MySqlConnection(_sConnectionString);
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

    public string[] GetValidCourseNames(int iYear) {
      MySqlCommand oSelectCommand = new MySqlCommand {
        Connection = GetConnection(),
        CommandText = "SELECT DISTINCT CourseName FROM StudentCourseRel WHERE year = @iYear ORDER BY CourseName ASC"
      };

      oSelectCommand.Parameters.AddWithValue("@iYear", iYear);

      DataTable oDataTable = new DataTable();

      using (MySqlDataAdapter oDataAdapter = new MySqlDataAdapter(oSelectCommand)) {
        oDataAdapter.Fill(oDataTable);
      }

      int iArrayLength = oDataTable.Rows.Count - 1;
      string[] asResult = new string[iArrayLength + 1];

      for (int iRow = 0; iRow <= iArrayLength; iRow++) {
        asResult[iRow] = Convert.ToString(oDataTable.Rows[iRow][0]);
      }

      return asResult;
    }

    public char[] GetValidClassNames(int iYear) {
      MySqlCommand oSelectCommand = new MySqlCommand();
      DataTable oDataTable = new DataTable();

      oSelectCommand.Connection = GetConnection();
      oSelectCommand.CommandText =
        "SELECT DISTINCT ClassName FROM StudentCourseRel INNER JOIN CourseClassRel ON StudentCourseRel.CourseName = CourseClassRel.CourseName INNER JOIN Class on courseclassrel.ClassName = Class.Name WHERE StudentCourseRel.year = @iYear ORDER BY ClassName ASC";
      oSelectCommand.Parameters.AddWithValue("@iYear", iYear);

      using (MySqlDataAdapter oDataAdapter = new MySqlDataAdapter(oSelectCommand)) {
        oDataAdapter.Fill(oDataTable);
      }

      int iArrayLength = oDataTable.Rows.Count - 1;
      char[] acResult = new char[iArrayLength + 1];

      for (int iRow = 0; iRow <= iArrayLength; iRow++) {
        char cCurrentClass = Convert.ToChar(oDataTable.Rows[iRow][0]);

        if (Prerequisites.IsValidClassName(cCurrentClass)) {
          acResult[iRow] = Convert.ToChar(oDataTable.Rows[iRow][0]);
        } else {
          throw new ArgumentOutOfRangeException("Invalid ClassName" + cCurrentClass + "received from database.");
        }
      }

      return acResult;
    }

    /// <summary>
    ///   Returns a data table with information about the allowed traditional disciplines, i.e. the disciplines that can be
    ///   selected for the given parameters.
    /// </summary>
    /// <param name="eSex">The students' gender.</param>
    /// <param name="eDiscipline">The disciple type to be looked up.</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public DataTable GetValidTraditionalDisciplinesTable(Prerequisites.Sex eSex, Prerequisites.Discipline eDiscipline) {
      DataTable oDataTable = new DataTable();
      MySqlCommand oSelectCommand = new MySqlCommand { CommandText = "Select * from " };

      switch (eSex) {
        case Prerequisites.Sex.Male:
          switch (eDiscipline) {
            case Prerequisites.Discipline.Sprint:
              oSelectCommand.CommandText += "TraditionalMaleSprintDisciplines";
              break;
            case Prerequisites.Discipline.Throw:
              oSelectCommand.CommandText += "TraditionalMaleThrowDisciplines";
              break;
            case Prerequisites.Discipline.Jump:
              oSelectCommand.CommandText += "TraditionalMaleJumpDisciplines";
              break;
            case Prerequisites.Discipline.MiddleDistance:
              oSelectCommand.CommandText += "TraditionalMaleMiddleDistanceDisciplines";
              break;
            default:
              throw new ArgumentException("Invalid discipline: " + eDiscipline);
          }
          break;
        case Prerequisites.Sex.Female:
          switch (eDiscipline) {
            case Prerequisites.Discipline.Sprint:
              oSelectCommand.CommandText += "TraditionalFemaleSprintDisciplines";
              break;
            case Prerequisites.Discipline.Throw:
              oSelectCommand.CommandText += "TraditionalFemaleThrowDisciplines";
              break;
            case Prerequisites.Discipline.Jump:
              oSelectCommand.CommandText += "TraditionalFemaleJumpDisciplines";
              break;
            case Prerequisites.Discipline.MiddleDistance:
              oSelectCommand.CommandText += "TraditionalFemaleMiddleDistanceDisciplines";
              break;
            default:
              throw new ArgumentException("Invalid discipline: " + eDiscipline);
          }
          break;
        default:
          throw new ArgumentException("Invalid sex: " + eSex);
      }

      oSelectCommand.Connection = GetConnection();

      using (MySqlDataAdapter oDataAdapter = new MySqlDataAdapter(oSelectCommand)) {
        oDataAdapter.Fill(oDataTable);
      }

      return oDataTable;
    }

    public DataTable GetValidCompetitionDisciplinesTable(Prerequisites.Discipline discipline) {
      MySqlCommand selectCommand = new MySqlCommand {
        CommandText = $"Select * from {Prerequisites.CompetitionDisciplinesViewNames[discipline]}",
        Connection = GetConnection()
      };

      DataTable dataTable = new DataTable();

      using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(selectCommand)) {
        dataAdapter.Fill(dataTable);
      }

      return dataTable;
    }

    public Prerequisites.GameType GetGameType(char cClassName, int iYear) {
      Prerequisites.GameType functionReturnValue;

      if (Prerequisites.IsValidYear(iYear) && Prerequisites.IsValidClassName(cClassName)) {
        MySqlCommand oSelectCommand = new MySqlCommand {
          CommandType = CommandType.StoredProcedure,
          Connection = GetConnection(),
          CommandText = "GetGameType"
        };

        oSelectCommand.Parameters.AddWithValue("@cClassName", cClassName);
        oSelectCommand.Parameters.AddWithValue("@yYear", iYear);

        MySqlParameter oReturnParameter = new MySqlParameter {
          Direction = ParameterDirection.ReturnValue,
          ParameterName = "@eReturnValue",
          MySqlDbType = MySqlDbType.Enum
        };

        oSelectCommand.Parameters.Add(oReturnParameter);

        try {
          oSelectCommand.Connection.Open();
          oSelectCommand.ExecuteNonQuery();

          string sReturnedGameType = oReturnParameter.Value.ToString();

          switch (sReturnedGameType) {
            case "Competition":
              functionReturnValue = Prerequisites.GameType.Competition;
              break;
            case "Traditional":
              functionReturnValue = Prerequisites.GameType.Traditional;
              break;
            case "":
              functionReturnValue = Prerequisites.GameType.Unknown;
              break;
            default:
              throw new DataException("Invalid GameType received from database: " + sReturnedGameType);
          }
        } finally {
          oSelectCommand.Connection?.Close();
        }
      } else {
        //todo: distiguish between which provided argument is invalid
        throw new ArgumentException($"Invalid year or class name provided. Year: {iYear}; Class Name: {cClassName}");
      }
      return functionReturnValue;
    }

    public MySqlDataAdapter GetRawDataEditAdapter(string sCourseName, int iYear) {
      MySqlDataAdapter oDataAdapter = new MySqlDataAdapter();
      MySqlCommand oSelectCommand = new MySqlCommand();

      oSelectCommand.Connection = GetConnection();

      oSelectCommand.CommandText =
        "SELECT Student.PKey, Surname, Forename, Sex, Sprint, Jump, Throw, MiddleDistance FROM Student INNER JOIN StudentCourseRel ON Student.Pkey = StudentCourseRel.StudentPKey LEFT JOIN Competition On Student.PKey = Competition.StudentPKey and Competition.Year = @Year WHERE StudentCourseRel.Year = @Year AND StudentCourseRel.CourseName = @CourseName ORDER BY Surname ASC, Forename ASC";

      oSelectCommand.Parameters.AddWithValue("@Year", iYear);
      oSelectCommand.Parameters.AddWithValue("@CourseName", sCourseName);

      MySqlCommand oUpdateCommand = new MySqlCommand("EnterCompetitionValues", GetConnection()) {
        CommandType = CommandType.StoredProcedure
      };

      oUpdateCommand.Parameters.AddWithValue("yYear", iYear);

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

    public MySqlDataAdapter GetDisciplinesEditAdapter(char cClassName, int iYear) {
      MySqlDataAdapter oDataAdapter = new MySqlDataAdapter();
      MySqlCommand oSelectCommand = new MySqlCommand {
        Connection = GetConnection(),
        CommandText = "SELECT * FROM ClassDisciplineMeta WHERE ClassName = @cClassName AND YEAR = @yYear"
      };

      oSelectCommand.Parameters.AddWithValue("@cClassName", cClassName);
      oSelectCommand.Parameters.AddWithValue("@yYear", iYear);

      MySqlCommand oUpdateCommand = new MySqlCommand("EnterDisciplineMeta", GetConnection()) {
        CommandType = CommandType.StoredProcedure
      };

      oUpdateCommand.Parameters.AddWithValue("cClassName", cClassName);
      oUpdateCommand.Parameters.AddWithValue("yYear", iYear);

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

    public void ImportStudentData(string sSurname, string sForename, string sCourseName, string sClassName,
      Prerequisites.Sex eSex, int iYearOfBirth, int iYear) {
      MySqlCommand oCmd = new MySqlCommand("ImportStudent", GetConnection()) {CommandType = CommandType.StoredProcedure};

      oCmd.Parameters.AddWithValue("@sSurname", sSurname);
      oCmd.Parameters.AddWithValue("@sForename", sForename);
      oCmd.Parameters.AddWithValue("@cCourseName", sCourseName);
      oCmd.Parameters.AddWithValue("@cClassName", sClassName);
      oCmd.Parameters.AddWithValue("@eSex", eSex.ToString());
      oCmd.Parameters.AddWithValue("@yYearOfBirth", iYearOfBirth);
      oCmd.Parameters.AddWithValue("@yYear", iYear);

      try {
        oCmd.Connection.Open();
        oCmd.ExecuteNonQuery();
      } finally {
        oCmd.Connection?.Close();
      }
    }
  }
}