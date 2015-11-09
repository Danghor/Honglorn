using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using HonglornBL.APIClasses;
using HonglornBL.Interfaces;
using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using static System.Windows.Forms.ProgressBarStyle;
using static HonglornBL.Prerequisites;

namespace HonglornBL {
  public class Honglorn {
    public static DataTable GetStudentCompetitionTable(string courseName, short year) {
      // Prepare table
      DataTable table = new DataTable();

      DataColumn PKeyColumn = table.Columns.Add(nameof(Student.PKey), typeof(Guid));
      DataColumn SurnameColumn = table.Columns.Add(nameof(Student.Surname), typeof(string));
      DataColumn ForenameColumn = table.Columns.Add(nameof(Student.Forename), typeof(string));
      DataColumn SexColumn = table.Columns.Add(nameof(Student.Sex), typeof(Sex));
      DataColumn SprintColumn = table.Columns.Add(nameof(Competition.Sprint), typeof(float));
      DataColumn JumpColumn = table.Columns.Add(nameof(Competition.Jump), typeof(float));
      DataColumn ThrowColumn = table.Columns.Add(nameof(Competition.Throw), typeof(float));
      DataColumn MiddleDistanceColumn = table.Columns.Add(nameof(Competition.MiddleDistance), typeof(float));

      using (HonglornDB db = new HonglornDB()) {
        IEnumerable<Student> studentList = (from s in db.Student
                                            where s.studentCourseRel.Any(rel => rel.Year == year && rel.CourseName == courseName)
                                            orderby s.Surname, s.Forename, s.YearOfBirth descending
                                            select s).ToList();

        foreach (Student student in studentList) {
          Competition competition = (from c in student.competition
                                     where c.Year == year
                                     select c).SingleOrDefault();

          DataRow newRow = table.NewRow();

          newRow.SetField(PKeyColumn, student.PKey);
          newRow.SetField(SurnameColumn, student.Surname);
          newRow.SetField(ForenameColumn, student.Forename);
          newRow.SetField(SexColumn, student.Sex);
          newRow.SetField(SprintColumn, competition?.Sprint);
          newRow.SetField(JumpColumn, competition?.Jump);
          newRow.SetField(ThrowColumn, competition?.Throw);
          newRow.SetField(MiddleDistanceColumn, competition?.MiddleDistance);

          table.Rows.Add(newRow);
        }
      }

      return table;
    }

    public static void UpdateStudentCompetitionDataCollection(IEnumerable<IStudentCompetitionData> competitionData, short year) {
      if (!IsValidYear(year)) {
        throw new ArgumentOutOfRangeException($"{year} is not a valid year.");
      }

      foreach (IStudentCompetitionData row in competitionData) {
        UpdateSingleStudentCompetition(row, year);
      }
    }

    static void UpdateSingleStudentCompetition(IStudentCompetitionData data, short year) {
      if (data == null) {
        throw new ArgumentNullException($"The parameter of type {nameof(IStudentCompetitionData)} cannot be null.");
      }

      using (HonglornDB db = new HonglornDB()) {
        Student student = db.Student.Find(data.PKey);

        if (student != null) {
          Competition existingCompetition = (from c in student.competition
                                             where c.Year == year
                                             select c).SingleOrDefault();

          if ((data.Sprint ?? data.Jump ?? data.Throw ?? data.MiddleDistance) == null) {
            // Delete competition row
            if (existingCompetition != null) {
              db.Competition.Remove(existingCompetition);
            }
          } else {
            // Update competition row
            if (existingCompetition == null) {
              // Create
              Competition newCompetition = new Competition {
                Year = year,
                Sprint = data.Sprint,
                Jump = data.Jump,
                Throw = data.Throw,
                MiddleDistance = data.MiddleDistance
              };
              student.competition.Add(newCompetition);
            } else {
              // Update
              existingCompetition.Sprint = data.Sprint;
              existingCompetition.Jump = data.Jump;
              existingCompetition.Throw = data.Throw;
              existingCompetition.MiddleDistance = data.MiddleDistance;
            }
          }

          db.SaveChanges();
        } else {
          throw new ArgumentException($"No {nameof(Student)} with such key in databse: {data.PKey}");
        }
      }
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
    public static GameType? GetGameType(string className, short year) {
      GameType? result;

      using (HonglornDB db = new HonglornDB()) {
        IQueryable<GameType> collection = from c in db.DisciplineCollection
                                          where c.ClassName == className
                                                && c.Year == year
                                          select c.GameType;

        result = collection.SingleOrDefault();
      }

      return result;
    }

    /// <summary>
    ///   Get the years for which student data is present in the database.
    /// </summary>
    /// <returns>A short collection representing the valid years.</returns>
    public static ICollection<short> GetYearsWithStudentData() {
      ICollection<short> result;

      using (HonglornDB db = new HonglornDB()) {
        IQueryable<short> years = (from relations in db.StudentCourseRel
                                   select relations.Year).Distinct();

        result = years.OrderByDescending(year => year).ToArray();
      }

      return result;
    }

    /// <summary>
    ///   Get a the course names for which there is at least one student present in the given year.
    /// </summary>
    /// <param name="year">The year for which the valid course names should be retrieved.</param>
    /// <returns>All valid course names.</returns>
    public static ICollection<string> GetValidCourseNames(short year) {
      ICollection<string> validCourseNames;

      using (HonglornDB db = new HonglornDB()) {
        IQueryable<string> courseNames = (from r in db.StudentCourseRel
                                          where r.Year == year
                                          select r.CourseName).Distinct();
        validCourseNames = courseNames.OrderBy(name => name).ToArray();
      }

      return validCourseNames;
    }

    /// <summary>
    ///   Get a Char Array representing the class names for which there is at least one student present in the given year.
    /// </summary>
    /// <param name="year">The year for which the valid class names should be retrieved.</param>
    /// <returns>A Char Array representing the valid class names.</returns>
    /// <remarks></remarks>
    public static ICollection<string> GetValidClassNames(short year) {
      ICollection<string> validCourseNames = GetValidCourseNames(year);

      return validCourseNames.Select(GetClassName).ToArray();
    }

    #region "Import"

    //todo: currently only works with a "perfect" Excel sheet
    //todo: test inserting an already existing student

    /// <summary>
    ///   Imports an Excel sheet containing data for multiple students into the database.
    /// </summary>
    /// <param name="filePath">The full path to the Excel file to be imported.</param>
    /// <param name="year">The year in which the imported data is valid (relevant for mapping the courses).</param>
    /// <param name="worker">The background worker used to process this method. Used for status updates.</param>
    public static void ImportStudentCourseExcelSheet(string filePath, short year, BackgroundWorker worker) {
      if (!IsValidYear(year)) {
        throw new ArgumentException($"{year} not a valid year.");
      }

      worker.ReportProgress(0, new ProgressInformer {Style = Marquee, StatusMessage = "Lese Daten aus Excel Datei..."});

      ICollection<Tuple<Student, string>> studentsFromExcelSheet = ExcelImporter.GetStudentDataTableFromExcelFile(filePath);

      int currentlyImported = 0;

      worker.ReportProgress(0, new ProgressInformer {Style = Continuous, StatusMessage = "Schreibe Daten in die Datenbank..."});

      foreach (Tuple<Student, string> importStudent in studentsFromExcelSheet) {
        ImportSingleStudent(importStudent.Item1, importStudent.Item2, year);

        currentlyImported++;
        worker.ReportProgress(PercentageValue(currentlyImported, studentsFromExcelSheet.Count), new ProgressInformer {
          Style = Continuous,
          StatusMessage = "Schreibe Daten in die Datenbank..."
        });
      }

      worker.ReportProgress(100, new ProgressInformer {
        Style = Continuous,
        StatusMessage = "Fertig!"
      });
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
          Student existingStudent = studentQuery.Single();

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