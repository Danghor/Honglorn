using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using HonglornBL.APIClasses;
using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using static System.Windows.Forms.ProgressBarStyle;
using static HonglornBL.Prerequisites;

namespace HonglornBL
{
    public class Honglorn
    {
        public static ICollection<Student> GetStudents(string course, short year)
        {
            using (HonglornDb db = new HonglornDb())
            {
                return (from s in db.Student
                        where s.StudentCourseRel.Any(rel => rel.Year == year && rel.CourseName == course)
                        orderby s.Surname, s.Forename, s.YearOfBirth descending
                        select s).Include(s => s.Competition).ToList();
            }
        }

        public static DataTable GetStudentCompetitionTable(string courseName, short year)
        {
            // Prepare table
            DataTable table = new DataTable();

            DataColumn pKeyColumn = table.Columns.Add(nameof(Student.PKey), typeof(Guid));
            DataColumn surnameColumn = table.Columns.Add(nameof(Student.Surname), typeof(string));
            DataColumn forenameColumn = table.Columns.Add(nameof(Student.Forename), typeof(string));
            DataColumn sexColumn = table.Columns.Add(nameof(Student.Sex), typeof(Sex));
            DataColumn sprintColumn = table.Columns.Add(nameof(Competition.Sprint), typeof(float));
            DataColumn jumpColumn = table.Columns.Add(nameof(Competition.Jump), typeof(float));
            DataColumn throwColumn = table.Columns.Add(nameof(Competition.Throw), typeof(float));
            DataColumn middleDistanceColumn = table.Columns.Add(nameof(Competition.MiddleDistance), typeof(float));

            using (HonglornDb db = new HonglornDb())
            {
                IEnumerable<Student> studentList = (from s in db.Student
                                                    where s.StudentCourseRel.Any(rel => rel.Year == year && rel.CourseName == courseName)
                                                    orderby s.Surname, s.Forename, s.YearOfBirth descending
                                                    select s).ToList();

                foreach (Student student in studentList)
                {
                    Competition competition = (from c in student.Competition
                                               where c.Year == year
                                               select c).SingleOrDefault();

                    DataRow newRow = table.NewRow();

                    newRow.SetField(pKeyColumn, student.PKey);
                    newRow.SetField(surnameColumn, student.Surname);
                    newRow.SetField(forenameColumn, student.Forename);
                    newRow.SetField(sexColumn, student.Sex);
                    newRow.SetField(sprintColumn, competition?.Sprint);
                    newRow.SetField(jumpColumn, competition?.Jump);
                    newRow.SetField(throwColumn, competition?.Throw);
                    newRow.SetField(middleDistanceColumn, competition?.MiddleDistance);

                    table.Rows.Add(newRow);
                }
            }

            return table;
        }

        public static void UpdateStudentCompetitionData(DataTable table, short year)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(DataTable));
            }

            if (!IsValidYear(year))
            {
                throw new ArgumentOutOfRangeException($"{year} is not a valid year.");
            }

            DataColumn pKeyColumn = table.Columns[nameof(Student.PKey)];
            DataColumn surnameColumn = table.Columns[nameof(Student.Surname)];
            DataColumn forenameColumn = table.Columns[nameof(Student.Forename)];
            DataColumn sexColumn = table.Columns[nameof(Student.Sex)];
            DataColumn sprintColumn = table.Columns[nameof(Competition.Sprint)];
            DataColumn jumpColumn = table.Columns[nameof(Competition.Jump)];
            DataColumn throwColumn = table.Columns[nameof(Competition.Throw)];
            DataColumn middleDistanceColumn = table.Columns[nameof(Competition.MiddleDistance)];

            foreach (DataRow row in table.Rows)
            {
                Guid pKey = (Guid) row[pKeyColumn];
                string surname = row[surnameColumn].ToString();
                string forename = row[forenameColumn].ToString();
                Sex sex = (Sex) row[sexColumn];
                float? sprint = row[sprintColumn] as float?;
                float? jump = row[jumpColumn] as float?;
                float? Throw = row[throwColumn] as float?;
                float? middleDistance = row[middleDistanceColumn] as float?;

                UpdateSingleStudentCompetition(pKey, sprint, jump, Throw, middleDistance, year);
            }
        }

        static void UpdateSingleStudentCompetition(Guid pKey, float? sprint, float? jump, float? @throw, float? middleDistance, short year)
        {
            using (HonglornDb db = new HonglornDb())
            {
                Student student = db.Student.Find(pKey);

                if (student != null)
                {
                    Competition existingCompetition = (from c in student.Competition
                                                       where c.Year == year
                                                       select c).SingleOrDefault();

                    if ((sprint ?? jump ?? @throw ?? middleDistance) == null)
                    {
                        // Delete competition row
                        if (existingCompetition != null)
                        {
                            db.Competition.Remove(existingCompetition);
                        }
                    }
                    else
                    {
                        // Update competition row
                        if (existingCompetition == null)
                        {
                            // Create
                            Competition newCompetition = new Competition
                            {
                                Year = year,
                                Sprint = sprint,
                                Jump = jump,
                                Throw = @throw,
                                MiddleDistance = middleDistance
                            };
                            student.Competition.Add(newCompetition);
                        }
                        else
                        {
                            // Update
                            existingCompetition.Sprint = sprint;
                            existingCompetition.Jump = jump;
                            existingCompetition.Throw = @throw;
                            existingCompetition.MiddleDistance = middleDistance;
                        }
                    }

                    db.SaveChanges();
                }
                else
                {
                    throw new ArgumentException($"No {nameof(Student)} with such key in database: {pKey}");
                }
            }
        }

        public static DisciplineCollection ConfiguredDisciplines(string className, short year)
        {
            using (HonglornDb db = new HonglornDb())
            {
                DisciplineCollection collection = (from c in db.DisciplineCollection
                                                   where c.ClassName == className
                                                         && c.Year == year
                                                   select c).SingleOrDefault();

                if (collection != null)
                {
                    // Pre-load properties; otherwise they won't be available after the context is disposed.
                    IEnumerable<Expression<Func<DisciplineCollection, Discipline>>> references = new Expression<Func<DisciplineCollection, Discipline>>[]
                    {
                        c => c.MaleSprint,
                        c => c.MaleJump,
                        c => c.MaleThrow,
                        c => c.MaleMiddleDistance,
                        c => c.FemaleSprint,
                        c => c.FemaleJump,
                        c => c.FemaleThrow,
                        c => c.FemaleMiddleDistance
                    };

                    foreach (Expression<Func<DisciplineCollection, Discipline>> reference in references)
                    {
                        db.Entry(collection).Reference(reference).Load();
                    }
                }

                return collection;
            }
        }

        public static ICollection<CompetitionDiscipline> FilteredCompetitionDisciplines(DisciplineType disciplineType)
        {
            using (HonglornDb db = new HonglornDb())
            {
                return (from d in db.CompetitionDiscipline
                        where d.Type == disciplineType
                        select d).OrderBy(d => d.Name).ToArray();
            }
        }

        public static ICollection<TraditionalDiscipline> FilteredTraditionalDisciplines(DisciplineType disciplineType, Sex sex)
        {
            using (HonglornDb db = new HonglornDb())
            {
                return (from d in db.TraditionalDiscipline
                        where d.Type == disciplineType && d.Sex == sex
                        select d).OrderBy(d => d.Name).ToArray();
            }
        }

        public static ICollection<CompetitionDiscipline> AllCompetitionDisciplines()
        {
            using (HonglornDb db = new HonglornDb())
            {
                return db.CompetitionDiscipline.ToArray();
            }
        }

        public static void CreateOrUpdateCompetitionDiscipline(CompetitionDiscipline givenDiscipline)
        {
            if (givenDiscipline == null)
            {
                throw new ArgumentNullException(nameof(CompetitionDiscipline));
            }

            using (HonglornDb db = new HonglornDb())
            {
                CompetitionDiscipline existing = (from d in db.CompetitionDiscipline
                                                  where d.PKey == givenDiscipline.PKey
                                                  select d).SingleOrDefault();

                if (existing == null)
                {
                    db.CompetitionDiscipline.Add(givenDiscipline);
                }
                else
                {
                    existing.Type = givenDiscipline.Type;
                    existing.Name = givenDiscipline.Name;
                    existing.Unit = givenDiscipline.Unit;
                    existing.LowIsBetter = givenDiscipline.LowIsBetter;
                }

                db.SaveChanges();
            }
        }

        public static void DeleteCompetitionDisciplineByPKey(Guid pKey)
        {
            using (HonglornDb db = new HonglornDb())
            {
                try
                {
                    CompetitionDiscipline discipline = new CompetitionDiscipline
                    {
                        PKey = pKey
                    };

                    db.Entry(discipline).State = EntityState.Deleted;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException($"This {nameof(CompetitionDiscipline)} does not exist in the database", ex);
                }
            }
        }

        /// <summary>
        ///     Return the GameType currently set in DisciplineMeta for the selected class name and year or nothing, if no GameType
        ///     is set.
        /// </summary>
        /// <param name="className">The class name of the class the GameType is to be returned.</param>
        /// <param name="year">The year for which the GameType is valid.</param>
        /// <returns>
        ///     A member of the Enum GameType that represents the GameType set in DisciplineMeta for the corresponding class
        ///     in the given year.
        /// </returns>
        /// <remarks></remarks>
        public static Game? GetGameType(string className, short year)
        {
            using (HonglornDb db = new HonglornDb())
            {
                Game[] typeArray = (from c in db.DisciplineCollection
                                    where c.ClassName == className
                                          && c.Year == year
                                    select c.Game).ToArray();

                Game? result;

                switch (typeArray.Length)
                {
                    case 0:
                        result = null;
                        break;
                    case 1:
                        result = typeArray.Single();
                        break;
                    default:
                        throw new DataException($"Multiple GameTypes received from database for class name {className} and year {year}.");
                }

                return result;
            }
        }

        /// <summary>
        ///     Get the years for which student data is present in the database.
        /// </summary>
        /// <returns>A short collection representing the valid years.</returns>
        public static ICollection<short> YearsWithStudentData()
        {
            using (HonglornDb db = new HonglornDb())
            {
                return (from relations in db.StudentCourseRel
                        select relations.Year).Distinct().OrderByDescending(year => year).ToArray();
            }
        }

        /// <summary>
        ///     Get a the course names for which there is at least one student present in the given year.
        /// </summary>
        /// <param name="year">The year for which the valid course names should be retrieved.</param>
        /// <returns>All valid course names.</returns>
        public static ICollection<string> ValidCourseNames(short year)
        {
            using (HonglornDb db = new HonglornDb())
            {
                return (from r in db.StudentCourseRel
                        where r.Year == year
                        select r.CourseName).Distinct().OrderBy(name => name).ToArray();
            }
        }

        /// <summary>
        ///     Get a Char Array representing the class names for which there is at least one student present in the given year.
        /// </summary>
        /// <param name="year">The year for which the valid class names should be retrieved.</param>
        /// <returns>A Char Array representing the valid class names.</returns>
        /// <remarks></remarks>
        public static ICollection<string> ValidClassNames(short year)
        {
            return ValidCourseNames(year).Select(GetClassName).Distinct().ToArray();
        }

        #region "Import"

        //todo: currently only works with a "perfect" Excel sheet
        //todo: test inserting an already existing student

        /// <summary>
        ///     Imports an Excel sheet containing data for multiple students into the database.
        /// </summary>
        /// <param name="filePath">The full path to the Excel file to be imported.</param>
        /// <param name="year">The year in which the imported data is valid (relevant for mapping the courses).</param>
        /// <param name="worker">The background worker used to process this method. Used for status updates.</param>
        public static void ImportStudentCourseExcelSheet(string filePath, short year, BackgroundWorker worker)
        {
            if (!IsValidYear(year))
            {
                throw new ArgumentException($"{year} is not a valid year.");
            }

            worker.ReportProgress(0, new ProgressInformer {Style = Marquee, StatusMessage = "Lese Daten aus Excel Datei..."});

            //IEnumerable<Student> students = new StudentFile(filePath);

            ICollection<Tuple<Student, string>> studentsFromExcelSheet = ExcelImporter.GetStudentDataTableFromExcelFile(filePath);

            int currentlyImported = 0;

            worker.ReportProgress(0, new ProgressInformer {Style = Continuous, StatusMessage = "Schreibe Daten in die Datenbank..."});

            foreach (Tuple<Student, string> importStudent in studentsFromExcelSheet)
            {
                ImportSingleStudent(importStudent.Item1, importStudent.Item2, year);

                currentlyImported++;
                worker.ReportProgress(PercentageValue(currentlyImported, studentsFromExcelSheet.Count), new ProgressInformer
                {
                    Style = Continuous,
                    StatusMessage = "Schreibe Daten in die Datenbank..."
                });
            }

            worker.ReportProgress(100, new ProgressInformer
            {
                Style = Continuous,
                StatusMessage = "Fertig!"
            });
        }

        /// <summary>
        ///     Imports data of a single student into the database.
        /// </summary>
        /// <remarks></remarks>
        static void ImportSingleStudent(Student student, string courseName, short year)
        {
            //todo: handle exception
            GetClassName(courseName); //check whether the course name can be mapped to a class name

            //todo: verify year

            using (HonglornDb db = new HonglornDb())
            {
                IQueryable<Student> studentQuery = from s in db.Student
                                                   where s.Forename == student.Forename
                                                         && s.Surname == student.Surname
                                                         && s.Sex == student.Sex
                                                         && s.YearOfBirth == student.YearOfBirth
                                                   select s;

                Student existingStudent = studentQuery.SingleOrDefault();

                if (existingStudent == null)
                {
                    Student newStudent = new Student
                    {
                        Forename = student.Forename,
                        Surname = student.Surname,
                        Sex = student.Sex,
                        YearOfBirth = student.YearOfBirth
                    };

                    newStudent.AddStudentCourseRel(year, courseName);
                    db.Student.Add(newStudent);
                }
                else
                {
                    IEnumerable<StudentCourseRel> courseInformationQuery = from r in existingStudent.StudentCourseRel
                                                                           where r.Year == year
                                                                           select r;

                    StudentCourseRel existingCourseInformation = courseInformationQuery.SingleOrDefault();

                    if (existingCourseInformation == null)
                    {
                        existingStudent.AddStudentCourseRel(year, courseName);
                    }
                    else
                    {
                        existingCourseInformation.CourseName = courseName;
                    }
                }

                db.SaveChanges();
            }
        }

        #endregion
    }
}