using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using HonglornBL;
using MySql.Data.MySqlClient;
namespace HonglornBL {

  public class Honglorn {
    private readonly MySqlHandler _oMySqlHandler;


    private MySqlDataAdapter _daCurrentRawDataEditAdapter;

    private MySqlDataAdapter _daCurrentDisciplinesEditAdapter;
    public Honglorn(string sServer, uint iPort, string sUsername, string sPassword, string sDatabase) {
      _oMySqlHandler = new MySqlHandler(sServer, iPort, sUsername, sPassword, sDatabase);
    }

    #region "CompetitionEdit"

    /// <summary>
    ///   Returns a DataTable containing the relevant data to fill the DataGridView for editing the competition data per course
    ///   in the UI. Simultaneously, the corresponding DataAdapter is preserved, so it can be used for updating the DataBase
    ///   later.
    /// </summary>
    /// <param name="sCourseName">The name of the course to be edited.</param>
    /// <param name="iYear">The year for which the data should be selected.</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public DataTable GetCompetitionEditDataTable(string sCourseName, int iYear) {
      DataTable dtEditDataTable = new DataTable();
      _daCurrentRawDataEditAdapter = _oMySqlHandler.GetRawDataEditAdapter(sCourseName, iYear);

      _daCurrentRawDataEditAdapter.Fill(dtEditDataTable);

      return dtEditDataTable;
    }

    public void SaveRawDataEditTableChanges(DataTable oChanges) {
      if (_daCurrentRawDataEditAdapter != null) {
        _daCurrentRawDataEditAdapter.Update(oChanges);
      } else {
        throw new InvalidOperationException("The raw data edit table has not been initialized.");
      }
    }

    #endregion

    #region "SetDisciplines"

    /// <summary>
    ///   Returns a DataTable containing the current discipline settings for the given class and year (only the PKeys).
    ///   Simultaneously, the corresponding DataAdapter is preserved, so it can be used for updating the database later.
    /// </summary>
    /// <param name="cClassName">The name of the class whose discipline settings should be displayed.</param>
    /// <param name="iYear">The year for which the data should be retrieved.</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public DataTable GetDisciplinesEditDataTable(char cClassName, int iYear) {
      DataTable dsDisciplinesEditDataTable = new DataTable();
      _daCurrentDisciplinesEditAdapter = _oMySqlHandler.GetDisciplinesEditAdapter(cClassName, iYear);

      _daCurrentDisciplinesEditAdapter.Fill(dsDisciplinesEditDataTable);

      return dsDisciplinesEditDataTable;
    }

    public void SaveDisciplinesEditTableChanges(DataTable oChanges) {
      if (_daCurrentDisciplinesEditAdapter != null) {
        _daCurrentDisciplinesEditAdapter.Update(oChanges);
      } else {
        throw new InvalidOperationException("The raw data edit table has not been initialized.");
      }
    }

    #endregion

    public DataTable GetValidTraditionalDisciplinesTable(Prerequisites.Sex eSex, Prerequisites.Discipline eDiscipline) {
      return _oMySqlHandler.GetValidTraditionalDisciplinesTable(eSex, eDiscipline);
    }

    public DataTable GetValidCompetitionDisciplinesTable(Prerequisites.Discipline eDiscipline) {
      return _oMySqlHandler.GetValidCompetitionDisciplinesTable(eDiscipline);
    }

    /// <summary>
    ///   Return the GameType currently set in DisciplineMeta for the selected class name and year or nothing, if no GameType
    ///   is set.
    /// </summary>
    /// <param name="cClassName">The class name of the class the GameType is to be returned.</param>
    /// <param name="iYear">The year for which the GameType is valid.</param>
    /// <returns>
    ///   A member of the Enum GameType that represents the GameType set in DisciplineMeta for the corresponding class
    ///   in the given year.
    /// </returns>
    /// <remarks></remarks>
    public Prerequisites.GameType GetGameType(char cClassName, int iYear) {
      return _oMySqlHandler.GetGameType(cClassName, iYear);
    }

    /// <summary>
    ///   Get an Integer Array representing the years for which student data is present in the database.
    /// </summary>
    /// <returns>An Integer Array representing the valid years.</returns>
    public int[] GetYearsWithStudentData() {
      return _oMySqlHandler.GetYearsWithStudentData();
    }

    /// <summary>
    ///   Get a String Array representing the course names for which there is at least one student present in the given year.
    /// </summary>
    /// <param name="iYear">The year for which the valid course names should be retrieved.</param>
    /// <returns>A String Array representing the valid course names.</returns>
    /// <remarks></remarks>
    public string[] GetValidCourseNames(int iYear) {
      return _oMySqlHandler.GetValidCourseNames(iYear);
    }

    /// <summary>
    ///   Get a Char Array representing the class names for which there is at least one student present in the given year.
    /// </summary>
    /// <param name="iYear">The year for which the valid class names should be retrieved.</param>
    /// <returns>A Char Array representing the valid class names.</returns>
    /// <remarks></remarks>
    public char[] GetValidClassNames(int iYear) {
      return _oMySqlHandler.GetValidClassNames(iYear);
    }

    #region "Import"

    //todo: currently only works with a "perfect" Excel sheet
    //todo: test inserting an already existing student

    /// <summary>
    ///   Imports an Excel sheet containing data for multiple students into the database.
    /// </summary>
    /// <param name="sFilePath">The full path to the Excel file to be imported.</param>
    /// <param name="iYear">The year in which the imported data is valid (relevant for mapping the courses).</param>
    public void ImportStudentCourseExcelSheet(string sFilePath, int iYear) {
      string sCurSurname = null;
      string sCurForename = null;
      string sCurCourseName = null;
      Prerequisites.Sex eCurrentSex = default(Prerequisites.Sex);
      int iCurYearOfBirth = 0;

      DataTable oDataTable = ExcelImporter.GetStudentCourseDataTable(sFilePath);

      foreach (DataRow oRow in oDataTable.Rows) {
        sCurSurname = Convert.ToString(oRow[0]);
        sCurForename = Convert.ToString(oRow[1]);
        sCurCourseName = Convert.ToString(oRow[2]);

        switch ((Convert.ToString(oRow[3]))) {
          case "M":
            eCurrentSex = Prerequisites.Sex.Male;
            break;
          case "W":
            eCurrentSex = Prerequisites.Sex.Female;
            break;
        }

        iCurYearOfBirth = Convert.ToInt32(oRow[4]);

        ImportSingleStudent(sCurSurname, sCurForename, sCurCourseName, eCurrentSex, iCurYearOfBirth, iYear);
      }
    }

    /// <summary>
    ///   Imports data of a single student into the database.
    /// </summary>
    /// <param name="sSurname">Surname of the student to be imported.</param>
    /// <param name="sForename">Forename of the student to be imported.</param>
    /// <param name="sCourseName"></param>
    /// <param name="eSex"></param>
    /// <param name="iYearOfBirth"></param>
    /// <param name="iYear"></param>
    /// <remarks></remarks>
    private void ImportSingleStudent(string sSurname, string sForename, string sCourseName, Prerequisites.Sex eSex, int iYearOfBirth, int iYear) {
      string sClassName = null;

      //todo: move this to prerequisites or so (or some other validation function)
      if (Regex.IsMatch(sCourseName, "0[5-9][A-Z]")) {
        sClassName = sCourseName[1].ToString();
      } else if (Regex.IsMatch(sCourseName, "E(0[1-9]|[1-9][0-9])")) {
        sClassName = "E";
      } else {
        throw new ArgumentException("Invalid course name. Automatic mapping to class name failed.");
      }

      _oMySqlHandler.ImportStudentData(sSurname, sForename, sCourseName, sClassName, eSex, iYearOfBirth, iYear);
    }

    #endregion
  }
}
