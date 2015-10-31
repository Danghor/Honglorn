using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HonglornBL.Models;
using MySql.Data.MySqlClient;
using static HonglornBL.Prerequisites;

namespace HonglornBL {
  public class Honglorn {
    readonly MySqlHandler mySQLHandler;

    MySqlDataAdapter _daCurrentDisciplinesEditAdapter;
    MySqlDataAdapter _daCurrentRawDataEditAdapter;

    public Honglorn(string server, uint port, string username, string password, string database) {
      mySQLHandler = new MySqlHandler(server, port, username, password, database);
    }

    public DataTable GetValidTraditionalDisciplinesTable(Sex sex, DisciplineType discipline) {
      return mySQLHandler.GetValidTraditionalDisciplinesTable(sex, discipline);
    }

    public DataTable GetValidCompetitionDisciplinesTable(DisciplineType discipline) {
      return mySQLHandler.GetValidCompetitionDisciplinesTable(discipline);
    }

    /// <summary>
    ///   Return the GameType currently set in DisciplineMeta for the selected class name and year or nothing, if no GameType
    ///   is set.
    /// </summary>
    /// <param name="className">The class name of the class the GameType is to be returned.</param>
    /// <param name="year">The year for which the GameType is valid.</param>
    /// <returns>
    ///   A member of the Enum GameType that represents the GameType set in DisciplineMeta for the corresponding class
    ///   in the given year.
    /// </returns>
    /// <remarks></remarks>
    public GameType GetGameType(char className, ushort year) {
      return mySQLHandler.GetGameType(className, year);
    }

    /// <summary>
    ///   Get the years for which student data is present in the database.
    /// </summary>
    /// <returns>An int collection representing the valid years.</returns>
    public static ICollection<ushort> GetYearsWithStudentData() {
      ICollection<ushort> result = new List<ushort>();

      using (HonglornDB db = new HonglornDB()) {
        IQueryable<short> years = (from relations in db.StudentCourseRel
          select relations.Year).Distinct();

        foreach (short year in years) {
          ushort convertedYear = (ushort) year;
          if (IsValidYear((short) convertedYear)) {
//todo: strange casting needs to be fixed at the root
            result.Add(convertedYear);
          } else {
            throw new DataException($"Invalid year retrieved from Database: {year}");
          }
        }
      }

      return result;
    }

    /// <summary>
    ///   Get a String Array representing the course names for which there is at least one student present in the given year.
    /// </summary>
    /// <param name="year">The year for which the valid course names should be retrieved.</param>
    /// <returns>A String Array representing the valid course names.</returns>
    /// <remarks></remarks>
    public ICollection<string> GetValidCourseNames(int year) {
      return mySQLHandler.GetValidCourseNames(year);
    }

    /// <summary>
    ///   Get a Char Array representing the class names for which there is at least one student present in the given year.
    /// </summary>
    /// <param name="year">The year for which the valid class names should be retrieved.</param>
    /// <returns>A Char Array representing the valid class names.</returns>
    /// <remarks></remarks>
    public ICollection<char> GetValidClassNames(uint year) {
      return mySQLHandler.GetValidClassNames(year);
    }

    #region "CompetitionEdit"

    /// <summary>
    ///   Returns a DataTable containing the relevant data to fill the DataGridView for editing the competition data per course
    ///   in the UI. Simultaneously, the corresponding DataAdapter is preserved, so it can be used for updating the DataBase
    ///   later.
    /// </summary>
    /// <param name="courseNames">The name of the course to be edited.</param>
    /// <param name="year">The year for which the data should be selected.</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public DataTable GetCompetitionEditDataTable(string courseNames, int year) {
      DataTable dtEditDataTable = new DataTable();
      _daCurrentRawDataEditAdapter = mySQLHandler.GetRawDataEditAdapter(courseNames, year);

      _daCurrentRawDataEditAdapter.Fill(dtEditDataTable);

      return dtEditDataTable;
    }

    public void SaveRawDataEditTableChanges(DataTable changes) {
      if (_daCurrentRawDataEditAdapter != null) {
        _daCurrentRawDataEditAdapter.Update(changes);
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
    /// <param name="classNames">The name of the class whose discipline settings should be displayed.</param>
    /// <param name="year">The year for which the data should be retrieved.</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public DataTable GetDisciplinesEditDataTable(char classNames, int year) {
      DataTable dsDisciplinesEditDataTable = new DataTable();
      _daCurrentDisciplinesEditAdapter = mySQLHandler.GetDisciplinesEditAdapter(classNames, year);

      _daCurrentDisciplinesEditAdapter.Fill(dsDisciplinesEditDataTable);

      return dsDisciplinesEditDataTable;
    }

    public void SaveDisciplinesEditTableChanges(DataTable changes) {
      if (_daCurrentDisciplinesEditAdapter != null) {
        _daCurrentDisciplinesEditAdapter.Update(changes);
      } else {
        throw new InvalidOperationException("The raw data edit table has not been initialized.");
      }
    }

    #endregion

    #region "Import"

    //todo: currently only works with a "perfect" Excel sheet
    //todo: test inserting an already existing student

    /// <summary>
    ///   Imports an Excel sheet containing data for multiple students into the database.
    /// </summary>
    /// <param name="filePath">The full path to the Excel file to be imported.</param>
    /// <param name="year">The year in which the imported data is valid (relevant for mapping the courses).</param>
    public static void ImportStudentCourseExcelSheet(string filePath, short year) {
      ICollection<ImportStudent> studentsFromExcelSheet = ExcelImporter.GetStudentDataTableFromExcelFile(filePath);

      foreach (ImportStudent importStudent in studentsFromExcelSheet) {
        Student student = new Student {
          Surname = importStudent.Surname,
          Forename = importStudent.Forename,
          Sex = importStudent.Sex,
          YearOfBirth = importStudent.YearOfBirth
        };

        string courseName = importStudent.CourseName;

        ImportSingleStudent(student, courseName, year);
      }
    }

    /// <summary>
    ///   Imports data of a single student into the database.
    /// </summary>
    /// <remarks></remarks>
    static void ImportSingleStudent(Student student, string courseName, short year) {
      GetClassName(courseName); //check whether the course name can be mapped to a class name

      using (HonglornDB db = new HonglornDB()) {
        IQueryable<Student> studentQuery = from s in db.Student
          where s.Forename == student.Forename
                && s.Surname == student.Surname
                && s.Sex == student.Sex
                && s.YearOfBirth == student.YearOfBirth
          select s;

        if (studentQuery.Any()) {
          Student existingStudent = studentQuery.First();

          IEnumerable<StudentCourseRel> exisitingRelation = from r in existingStudent.studentCourseRel
            where r.Year == year
            select r;

          if (!exisitingRelation.Any()) {
            existingStudent.AddStudentCourseRel(year, courseName);
          }
        } else {
          Student newStudent = new Student {
            Forename = student.Forename,
            Surname = student.Surname,
            Sex = student.Sex,
            YearOfBirth = student.YearOfBirth
          };

          newStudent.AddStudentCourseRel(year, courseName);
          db.Student.Add(newStudent);
        }

        db.SaveChanges();
      }
    }

    #endregion
  }
}