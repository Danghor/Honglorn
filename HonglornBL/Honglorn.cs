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
                        select s).Include(s => s.Competition).ToArray();
            }
        }

        public static IEnumerable<Result> GetResults(string course, short year)
        {
            IEnumerable<Result> results;

            IEnumerable<Student> students = GetStudents(course, year);
            string className = GetClassName(course);

            using (HonglornDb db = new HonglornDb())
            {
                DisciplineCollection disciplines = (from d in db.DisciplineCollection
                                                    where d.ClassName == className
                                                          && d.Year == year
                                                    select d).SingleOrDefault();

                if (disciplines == null)
                {
                    throw new DataException($"No disciplines have been configured for class {className} in year {year}. Therefore, no results can be calculated.");
                }

                Discipline[] disciplineArray = { disciplines.MaleSprint, disciplines.MaleJump, disciplines.MaleThrow, disciplines.MaleMiddleDistance, disciplines.FemaleSprint, disciplines.FemaleJump, disciplines.FemaleThrow, disciplines.FemaleMiddleDistance };

                if (disciplineArray.All(d => d is TraditionalDiscipline))
                {
                    TraditionalDisciplineContainer disciplineContainer = new TraditionalDisciplineContainer
                    {
                        MaleSprint = disciplines.MaleSprint as TraditionalDiscipline,
                        MaleJump = disciplines.MaleJump as TraditionalDiscipline,
                        MaleThrow = disciplines.MaleThrow as TraditionalDiscipline,
                        MaleMiddleDistance = disciplines.MaleMiddleDistance as TraditionalDiscipline,
                        FemaleSprint = disciplines.FemaleSprint as TraditionalDiscipline,
                        FemaleJump = disciplines.FemaleJump as TraditionalDiscipline,
                        FemaleThrow = disciplines.FemaleThrow as TraditionalDiscipline,
                        FemaleMiddleDistance = disciplines.FemaleMiddleDistance as TraditionalDiscipline
                    };

                    results = CalculateTraditionalResults(students, year, disciplineContainer);
                }
                else if (disciplineArray.All(d => d is CompetitionDiscipline))
                {
                    CompetitionDisciplineContainer disciplineContainer = new CompetitionDisciplineContainer
                    {
                        MaleSprint = disciplines.MaleSprint as CompetitionDiscipline,
                        MaleJump = disciplines.MaleJump as CompetitionDiscipline,
                        MaleThrow = disciplines.MaleThrow as CompetitionDiscipline,
                        MaleMiddleDistance = disciplines.MaleMiddleDistance as CompetitionDiscipline,
                        FemaleSprint = disciplines.FemaleSprint as CompetitionDiscipline,
                        FemaleJump = disciplines.FemaleJump as CompetitionDiscipline,
                        FemaleThrow = disciplines.FemaleThrow as CompetitionDiscipline,
                        FemaleMiddleDistance = disciplines.FemaleMiddleDistance as CompetitionDiscipline
                    };

                    results = CalculateCompetitionResults(students, year, disciplineContainer);
                }
                else
                {
                    throw new DataException($"For class {className} in year {year}, some configured disciplines are traditional disciplines, while other disciplines are competition disciplines. A result can only be calculated when all disciplines are of the same type.");
                }
            }

            return results;
        }

        static IEnumerable<Result> CalculateCompetitionResults(IEnumerable<Student> students, short year, CompetitionDisciplineContainer disciplineCollection)
        {
            List<ICompetitionResult> competitionResults = new List<ICompetitionResult>();

            IEnumerable<string> classes = (from s in students
                                           select GetClassName(s.CourseNameByYear(year))).Distinct();

            foreach (string @class in classes)
            {
                IEnumerable<Student> maleStudents = from s in students
                                                    where GetClassName(s.CourseNameByYear(year)) == @class && s.Sex == Sex.Male
                                                    select s;

                IEnumerable<Student> femaleStudents = from s in students
                                                      where GetClassName(s.CourseNameByYear(year)) == @class && s.Sex == Sex.Female
                                                      select s;

                CompetitionCalculator maleCalculator = new CompetitionCalculator(disciplineCollection.MaleSprint.LowIsBetter, disciplineCollection.MaleJump.LowIsBetter, disciplineCollection.MaleThrow.LowIsBetter, disciplineCollection.MaleMiddleDistance.LowIsBetter);

                foreach (Student maleStudent in maleStudents)
                {
                    Competition competition = (from sc in maleStudent.Competition
                                               where sc.Year == year
                                               select sc).SingleOrDefault() ?? new Competition();

                    maleCalculator.AddStudentMeasurement(maleStudent.PKey, new RawMeasurement(competition.Sprint, competition.Jump, competition.Throw, competition.MiddleDistance));
                }

                CompetitionCalculator femaleCalculator = new CompetitionCalculator(disciplineCollection.FemaleSprint.LowIsBetter, disciplineCollection.FemaleJump.LowIsBetter, disciplineCollection.FemaleThrow.LowIsBetter, disciplineCollection.FemaleMiddleDistance.LowIsBetter);

                foreach (Student femaleStudent in femaleStudents)
                {
                    Competition competition = (from sc in femaleStudent.Competition
                                               where sc.Year == year
                                               select sc).SingleOrDefault() ?? new Competition();

                    femaleCalculator.AddStudentMeasurement(femaleStudent.PKey, new RawMeasurement(competition.Sprint, competition.Jump, competition.Throw, competition.MiddleDistance));
                }

                competitionResults.AddRange(maleCalculator.Results());
                competitionResults.AddRange(femaleCalculator.Results());
            }

            IEnumerable<Result> results = from c in competitionResults
                                          join s in students on c.Identifier equals s.PKey
                                          select new Result()
                                          {
                                              Forename = s.Forename,
                                              Surname = s.Surname,
                                              Score = (ushort)(c.SprintScore + c.JumpScore + c.ThrowScore + c.MiddleDistanceScore)
                                          };

            return results;
            //throw new NotImplementedException();
        }

        static IEnumerable<Result> CalculateTraditionalResults(IEnumerable<Student> students, short year, TraditionalDisciplineContainer disciplineCollection)
        {
            ICollection<Result> results = new List<Result>();

            foreach (Student student in students)
            {
                ushort totalScore = 0;

                Competition competition = (from sc in student.Competition
                                           where sc.Year == year
                                           select sc).SingleOrDefault() ?? new Competition();

                if (student.Sex == Sex.Male)
                {
                    totalScore += TraditionalCalculator.CalculateScore(disciplineCollection.MaleSprint, competition.Sprint);
                    totalScore += TraditionalCalculator.CalculateScore(disciplineCollection.MaleJump, competition.Jump);
                    totalScore += TraditionalCalculator.CalculateScore(disciplineCollection.MaleThrow, competition.Throw);
                    totalScore += TraditionalCalculator.CalculateScore(disciplineCollection.MaleMiddleDistance, competition.MiddleDistance);
                }
                else
                {
                    totalScore += TraditionalCalculator.CalculateScore(disciplineCollection.FemaleSprint, competition.Sprint);
                    totalScore += TraditionalCalculator.CalculateScore(disciplineCollection.FemaleJump, competition.Jump);
                    totalScore += TraditionalCalculator.CalculateScore(disciplineCollection.FemaleThrow, competition.Throw);
                    totalScore += TraditionalCalculator.CalculateScore(disciplineCollection.FemaleMiddleDistance, competition.MiddleDistance);
                }

                results.Add(new Result
                {
                    Surname = student.Surname,
                    Forename = student.Forename,
                    Score = totalScore,
                    Certificate = DetermineTraditionalCertificate(student.Sex, student.YearOfBirth, totalScore)
                });
            }

            return results;
        }

        static Certificate DetermineTraditionalCertificate(Sex sex, short yearOfBirth, ushort totalScore)
        {
            Certificate result;
            int studentAge = DateTime.Now.Year - yearOfBirth;

            using (HonglornDb db = new HonglornDb())
            {
                var scoreBoundaries = (from meta in db.TraditionalReportMeta
                                       where meta.Sex == sex
                                             && meta.Age == studentAge
                                       select new { meta.HonoraryCertificateScore, meta.VictoryCertificateScore }).Single();

                if (totalScore >= scoreBoundaries.HonoraryCertificateScore)
                {
                    result = Certificate.Honorary;
                }
                else if (totalScore >= scoreBoundaries.VictoryCertificateScore)
                {
                    result = Certificate.Victory;
                }
                else
                {
                    result = Certificate.Participation;
                }
            }

            return result;
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
                Guid pKey = (Guid)row[pKeyColumn];
                string surname = row[surnameColumn].ToString();
                string forename = row[forenameColumn].ToString();
                Sex sex = (Sex)row[sexColumn];
                float? sprint = row[sprintColumn] as float?;
                float? jump = row[jumpColumn] as float?;
                float? Throw = row[throwColumn] as float?;
                float? middleDistance = row[middleDistanceColumn] as float?;

                UpdateSingleStudentCompetition(pKey, year, sprint, jump, Throw, middleDistance);
            }
        }

        public static void UpdateSingleStudentCompetition(Guid studentPKey, short year, float? sprint, float? jump, float? @throw, float? middleDistance)
        {
            using (HonglornDb db = new HonglornDb())
            {
                Student student = db.Student.Find(studentPKey);

                if (student != null)
                {
                    Competition existingCompetition = (from c in student.Competition
                                                       where c.Year == year
                                                       select c).SingleOrDefault();

                    if ((sprint ?? jump ?? @throw ?? middleDistance) == null)
                    {
                        // Delete
                        if (existingCompetition != null)
                        {
                            db.Competition.Remove(existingCompetition);
                        }
                    }
                    else
                    {
                        if (existingCompetition == null)
                        {
                            // Create
                            student.Competition.Add(new Competition
                            {
                                Year = year,
                                Sprint = sprint,
                                Jump = jump,
                                Throw = @throw,
                                MiddleDistance = middleDistance
                            });
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
                    throw new ArgumentException($"No {nameof(Student)} with such key in database: {studentPKey}");
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

        public static void CreateOrUpdateCompetitionDiscipline(Guid disciplinePKey, DisciplineType type, string name, string unit, bool lowIsBetter)
        {
            using (HonglornDb db = new HonglornDb())
            {
                CompetitionDiscipline competition = db.CompetitionDiscipline.Find(disciplinePKey);

                if (competition == null)
                {
                    // Create
                    db.CompetitionDiscipline.Add(new CompetitionDiscipline
                    {
                        Type = type,
                        Name = name,
                        Unit = unit,
                        LowIsBetter = lowIsBetter
                    });
                }
                else
                {
                    // Update
                    competition.Type = type;
                    competition.Name = name;
                    competition.Unit = unit;
                    competition.LowIsBetter = lowIsBetter;
                }

                db.SaveChanges();
            }
        }

        public static void DeleteCompetitionDisciplineByPKey(Guid pKey)
        {
            try
            {
                using (HonglornDb db = new HonglornDb())
                {
                    CompetitionDiscipline discipline = new CompetitionDiscipline
                    {
                        PKey = pKey
                    };

                    db.Entry(discipline).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"A {nameof(CompetitionDiscipline)} with PKey {pKey} does not exist in the database.", ex);
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
            Game? result = null;

            using (HonglornDb db = new HonglornDb())
            {
                DisciplineCollection disciplineCollection = (from c in db.DisciplineCollection
                                                             where c.ClassName == className
                                                                   && c.Year == year
                                                             select c).SingleOrDefault();

                if (disciplineCollection != null)
                {
                    Discipline[] disciplines = { disciplineCollection.MaleSprint, disciplineCollection.MaleJump, disciplineCollection.MaleThrow, disciplineCollection.MaleMiddleDistance, disciplineCollection.FemaleSprint, disciplineCollection.FemaleJump, disciplineCollection.FemaleThrow, disciplineCollection.FemaleMiddleDistance };

                    if (disciplines.All(d => d is CompetitionDiscipline))
                    {
                        result = Game.Competition;
                    }
                    else if (disciplines.All(d => d is TraditionalDiscipline))
                    {
                        result = Game.Traditional;
                    }
                }
            }

            return result;
        }

        public static void CreateOrUpdateDisciplineCollection(string className, short year, Guid maleSprintPKey, Guid maleJumpPKey, Guid maleThrowPKey, Guid maleMiddleDistancePKey, Guid femaleSprintPKey, Guid femaleJumpPKey, Guid femaleThrowPKey, Guid femaleMiddleDistancePKey)
        {
            using (HonglornDb db = new HonglornDb())
            {
                Discipline maleSprintDiscipline = db.Set<Discipline>().Find(maleSprintPKey);
                Discipline maleJumpDiscipline = db.Set<Discipline>().Find(maleJumpPKey);
                Discipline maleThrowDiscipline = db.Set<Discipline>().Find(maleThrowPKey);
                Discipline maleMiddleDistanceDiscipline = db.Set<Discipline>().Find(maleMiddleDistancePKey);

                Discipline femaleSprintDiscipline = db.Set<Discipline>().Find(femaleSprintPKey);
                Discipline femaleJumpDiscipline = db.Set<Discipline>().Find(femaleJumpPKey);
                Discipline femaleThrowDiscipline = db.Set<Discipline>().Find(femaleThrowPKey);
                Discipline femaleMiddleDistanceDiscipline = db.Set<Discipline>().Find(femaleMiddleDistancePKey);

                Discipline[] disciplines = new[] { maleSprintDiscipline, maleJumpDiscipline, maleThrowDiscipline, maleMiddleDistanceDiscipline, femaleSprintDiscipline, femaleJumpDiscipline, femaleThrowDiscipline, femaleMiddleDistanceDiscipline };

                if (disciplines.All(d => d is CompetitionDiscipline) || disciplines.All(d => d is TraditionalDiscipline))
                {
                    DisciplineCollection existingCollection = (from col in db.DisciplineCollection
                                                               where col.ClassName == className && col.Year == year
                                                               select col).SingleOrDefault();

                    if (existingCollection == null)
                    {
                        // Create
                        db.DisciplineCollection.Add(new DisciplineCollection()
                        {
                            ClassName = className,
                            Year = year,
                            MaleSprintPKey = maleSprintPKey,
                            MaleJumpPKey = maleJumpPKey,
                            MaleThrowPKey = maleThrowPKey,
                            MaleMiddleDistancePKey = maleMiddleDistancePKey,
                            FemaleSprintPKey = femaleSprintPKey,
                            FemaleJumpPKey = femaleJumpPKey,
                            FemaleThrowPKey = femaleThrowPKey,
                            FemaleMiddleDistancePKey = femaleMiddleDistancePKey
                        });
                    }
                    else
                    {
                        // Update
                        existingCollection.MaleSprintPKey = maleSprintPKey;
                        existingCollection.MaleJumpPKey = maleJumpPKey;
                        existingCollection.MaleThrowPKey = maleThrowPKey;
                        existingCollection.MaleMiddleDistancePKey = maleMiddleDistancePKey;
                        existingCollection.FemaleSprintPKey = femaleSprintPKey;
                        existingCollection.FemaleJumpPKey = femaleJumpPKey;
                        existingCollection.FemaleThrowPKey = femaleThrowPKey;
                        existingCollection.FemaleMiddleDistancePKey = femaleMiddleDistancePKey;
                    }

                    db.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Could not save Discipline Collection. All discipline pkeys must be either entirely from competition disciplines, or from traditional disciplines, but you cannot mix them.");
                }


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
        ///     Get a String Array representing the class names for which there is at least one student present in the given year.
        /// </summary>
        /// <param name="year">The year for which the valid class names should be retrieved.</param>
        /// <returns>A String Array representing the valid class names.</returns>
        /// <remarks></remarks>
        public static ICollection<string> ValidClassNames(short year)
        {
            return ValidCourseNames(year).Select(GetClassName).Distinct().ToArray();
        }

        public static ICollection<DisciplineType> DisciplineTypes()
        {
            return (DisciplineType[])Enum.GetValues(typeof(DisciplineType));
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

            worker.ReportProgress(0, new ProgressInformer { Style = Marquee, StatusMessage = "Lese Daten aus Excel Datei..." });

            //IEnumerable<Student> students = new StudentFile(filePath);

            ICollection<Tuple<Student, string>> studentsFromExcelSheet = ExcelImporter.GetStudentDataTableFromExcelFile(filePath);

            int currentlyImported = 0;

            worker.ReportProgress(0, new ProgressInformer { Style = Continuous, StatusMessage = "Schreibe Daten in die Datenbank..." });

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