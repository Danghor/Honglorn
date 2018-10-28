using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using static HonglornBL.Prerequisites;
using System.Threading.Tasks;
using HonglornBL.Import;
using HonglornBL.Interfaces;

namespace HonglornBL
{
    public class Honglorn
    {
        public static IEnumerable<IStudentPerformance> StudentPerformances(string course, short year)
        {
            using (var db = new HonglornDb())
            {
                var result = new List<IStudentPerformance>();

                var relevantStudents = (from s in db.Student
                                        where s.StudentCourseRel.Any(rel => rel.Year == year && rel.CourseName == course)
                                        orderby s.Surname, s.Forename, s.YearOfBirth descending
                                        select s).Include(s => s.Competitions);

                foreach (var student in relevantStudents)
                {
                    var competition = student.Competitions.SingleOrDefault(c => c.Year == year);

                    result.Add(new StudentPerformance(student.PKey, student.Forename, student.Surname, competition?.Sprint, competition?.Jump, competition?.Throw, competition?.MiddleDistance));
                }

                return result;
            }
        }

        static ICollection<Student> GetStudents(string course, short year)
        {
            using (var db = new HonglornDb())
            {
                return (from s in db.Student
                        where s.StudentCourseRel.Any(rel => rel.Year == year && rel.CourseName == course)
                        orderby s.Surname, s.Forename, s.YearOfBirth descending
                        select s).Include(s => s.Competitions).ToArray();
            }
        }

        public static async Task<IEnumerable<IResult>> GetResultsAsync(string course, short year)
        {
            return await Task.Factory.StartNew(() => GetResults(course, year));
        }

        static IEnumerable<IResult> GetResults(string course, short year)
        {
            IEnumerable<IResult> results;

            IEnumerable<Student> students = GetStudents(course, year);
            string className = GetClassName(course);

            using (var db = new HonglornDb())
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
                    var disciplineContainer = new TraditionalDisciplineContainer
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
                    var disciplineContainer = new CompetitionDisciplineContainer
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

        static IEnumerable<IResult> CalculateCompetitionResults(IEnumerable<Student> students, short year, CompetitionDisciplineContainer disciplineCollection)
        {
            List<ICompetitionResult> competitionResults = new List<ICompetitionResult>();

            IEnumerable<string> classes = (from s in students
                                           select GetClassName(s.CourseNameByYear(year))).Distinct();
            using (var db = new HonglornDb())
            {
                foreach (string @class in classes)
                {
                    IEnumerable<Student> maleStudents = (from s in db.Student
                                                         where s.Sex == Sex.Male
                                                         select s).AsEnumerable().Where(s => GetClassName(s.CourseNameByYear(year)) == @class).ToList();

                    IEnumerable<Student> femaleStudents = (from s in db.Student
                                                           where s.Sex == Sex.Female
                                                           select s).AsEnumerable().Where(s => GetClassName(s.CourseNameByYear(year)) == @class).ToList();

                    var maleCalculator = new CompetitionCalculator(disciplineCollection.MaleSprint.LowIsBetter, disciplineCollection.MaleJump.LowIsBetter, disciplineCollection.MaleThrow.LowIsBetter, disciplineCollection.MaleMiddleDistance.LowIsBetter);

                    foreach (Student maleStudent in maleStudents)
                    {
                        Competition competition = (from sc in maleStudent.Competitions
                                                   where sc.Year == year
                                                   select sc).SingleOrDefault() ?? new Competition();

                        maleCalculator.AddStudentMeasurement(maleStudent.PKey, new RawMeasurement(competition.Sprint, competition.Jump, competition.Throw, competition.MiddleDistance));
                    }

                    var femaleCalculator = new CompetitionCalculator(disciplineCollection.FemaleSprint.LowIsBetter, disciplineCollection.FemaleJump.LowIsBetter, disciplineCollection.FemaleThrow.LowIsBetter, disciplineCollection.FemaleMiddleDistance.LowIsBetter);

                    foreach (Student femaleStudent in femaleStudents)
                    {
                        Competition competition = (from sc in femaleStudent.Competitions
                                                   where sc.Year == year
                                                   select sc).SingleOrDefault() ?? new Competition();

                        femaleCalculator.AddStudentMeasurement(femaleStudent.PKey, new RawMeasurement(competition.Sprint, competition.Jump, competition.Throw, competition.MiddleDistance));
                    }

                    competitionResults.AddRange(maleCalculator.Results());
                    competitionResults.AddRange(femaleCalculator.Results());
                }
            }

            //todo: determine certificate correctly
            IEnumerable<Result> results = from c in competitionResults
                                          join s in students on c.Identifier equals s.PKey
                                          orderby s.Surname, s.Forename, s.YearOfBirth descending
                                          select new Result(s.Forename, s.Surname, (ushort)(c.SprintScore + c.JumpScore + c.ThrowScore + c.MiddleDistanceScore), Certificate.Participation);

            return results;
        }

        static IEnumerable<IResult> CalculateTraditionalResults(IEnumerable<Student> students, short year, TraditionalDisciplineContainer disciplineCollection)
        {
            ICollection<IResult> results = new List<IResult>();

            foreach (Student student in students)
            {
                ushort totalScore = 0;

                Competition competition = (from sc in student.Competitions
                                           where sc.Year == year
                                           select sc).SingleOrDefault() ?? new Competition();

                TraditionalDiscipline[] disciplines;

                if (student.Sex == Sex.Male)
                {
                    disciplines = new[] { disciplineCollection.MaleSprint, disciplineCollection.MaleJump, disciplineCollection.MaleThrow, disciplineCollection.MaleMiddleDistance };
                }
                else
                {
                    disciplines = new[] { disciplineCollection.FemaleSprint, disciplineCollection.FemaleJump, disciplineCollection.FemaleThrow, disciplineCollection.FemaleMiddleDistance };
                }

                totalScore += TraditionalCalculator.CalculateScore(disciplines[0], competition.Sprint);
                totalScore += TraditionalCalculator.CalculateScore(disciplines[1], competition.Jump);
                totalScore += TraditionalCalculator.CalculateScore(disciplines[2], competition.Throw);
                totalScore += TraditionalCalculator.CalculateScore(disciplines[3], competition.MiddleDistance);

                results.Add(new Result(student.Surname, student.Forename, totalScore, DetermineTraditionalCertificate(student.Sex, student.YearOfBirth, totalScore)));
            }

            return results;
        }

        static Certificate DetermineTraditionalCertificate(Sex sex, short yearOfBirth, ushort totalScore)
        {
            Certificate result;
            int studentAge = DateTime.Now.Year - yearOfBirth;

            using (var db = new HonglornDb())
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

        public static void UpdateSingleStudentCompetition(Guid studentPKey, short year, float? sprint, float? jump, float? @throw, float? middleDistance)
        {
            using (var db = new HonglornDb())
            {
                Student student = db.Student.Find(studentPKey);

                if (student != null)
                {
                    Competition existingCompetition = (from c in student.Competitions
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
                            student.Competitions.Add(new Competition
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

        public static ICollection<IDiscipline> FilteredCompetitionDisciplines(DisciplineType disciplineType)
        {
            using (var db = new HonglornDb())
            {
                return (from d in db.CompetitionDiscipline
                        where d.Type == disciplineType
                        select d).OrderBy(d => d.Name).ToArray();
            }
        }

        public static ICollection<IDiscipline> FilteredTraditionalDisciplines(DisciplineType disciplineType, Sex sex)
        {
            using (var db = new HonglornDb())
            {
                return (from d in db.TraditionalDiscipline
                        where d.Type == disciplineType && d.Sex == sex
                        select d).OrderBy(d => d.Name).ToArray();
            }
        }

        public static ICollection<CompetitionDiscipline> AllCompetitionDisciplines()
        {
            using (var db = new HonglornDb())
            {
                return db.CompetitionDiscipline.ToArray();
            }
        }

        public static void CreateOrUpdateCompetitionDiscipline(Guid disciplinePKey, DisciplineType type, string name, string unit, bool lowIsBetter)
        {
            using (var db = new HonglornDb())
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
                using (var db = new HonglornDb())
                {
                    var discipline = new CompetitionDiscipline
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

            using (var db = new HonglornDb())
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
            using (var db = new HonglornDb())
            {
                IEnumerable<Discipline> disciplines = (from d in new[] { maleSprintPKey, maleJumpPKey, maleThrowPKey, maleMiddleDistancePKey, femaleSprintPKey, femaleJumpPKey, femaleThrowPKey, femaleMiddleDistancePKey }
                                                      select db.Set<Discipline>().Find(d)).ToArray();

                if (disciplines.All(d => d is CompetitionDiscipline) || disciplines.All(d => d is TraditionalDiscipline))
                {
                    DisciplineCollection existingCollection = (from col in db.DisciplineCollection
                                                               where col.ClassName == className && col.Year == year
                                                               select col).SingleOrDefault();

                    if (existingCollection == null)
                    {
                        // Create
                        db.DisciplineCollection.Add(new DisciplineCollection
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
            using (var db = new HonglornDb())
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
            using (var db = new HonglornDb())
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

        #region "Import"

        static readonly Dictionary<string, Sex> SexDictionary = new Dictionary<string, Sex>
        {
            {"W", Sex.Female},
            {"M", Sex.Male}
        };

        //todo: currently only works with a "perfect" Excel sheet
        //todo: test inserting an already existing student

        /// <summary>
        ///     Imports an Excel sheet containing data for multiple students into the database.
        /// </summary>
        /// <param name="filePath">The full path to the Excel file to be imported.</param>
        /// <param name="year">The year in which the imported data is valid (relevant for mapping the courses).</param>
        /// <param name="progress"></param>
        public static async Task<ICollection<ImportedStudentRecord>> ImportStudentCourseExcelSheet(string filePath, short year, IProgress<ProgressReport> progress)
        {
            if (!IsValidYear(year))
            {
                throw new ArgumentException($"{year} is not a valid year.");
            }

            progress.Report(new ProgressReport { Percentage = 0, IsIndeterminate = true, Message = "Lese Daten aus Excel Datei..." });

            ICollection<ImportedStudentRecord> studentsFromExcelSheet = await Task.Factory.StartNew(() => ExcelImporter.GetStudentDataTableFromExcelFile(filePath));

            int currentlyImported = 0;

            progress.Report(new ProgressReport { Percentage = 0, IsIndeterminate = false, Message = "Schreibe Daten in die Datenbank..." });

            foreach (ImportedStudentRecord importStudent in studentsFromExcelSheet)
            {
                if (importStudent.Error == null)
                {
                    Student student = new Student
                    {
                        Forename = importStudent.ImportedForename,
                        Surname = importStudent.ImportedSurname,
                        Sex = SexDictionary[importStudent.ImportedSex],
                        YearOfBirth = short.Parse(importStudent.ImportedYearOfBirth)
                    };

                    await Task.Factory.StartNew(() => ImportSingleStudent(student, importStudent.ImportedCourseName, year));
                }

                currentlyImported++;
                progress.Report(new ProgressReport { Percentage = PercentageValue(currentlyImported, studentsFromExcelSheet.Count), IsIndeterminate = false, Message = "Schreibe Daten in die Datenbank..." });
            }

            progress.Report(new ProgressReport { Percentage = 100, IsIndeterminate = false, Message = "Schreibe Daten in die Datenbank..." });

            return studentsFromExcelSheet;
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

            using (var db = new HonglornDb())
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
                    var newStudent = new Student
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