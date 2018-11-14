using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HonglornBL.Enums;
using HonglornBL.Import;
using HonglornBL.Interfaces;
using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using static HonglornBL.Prerequisites;

namespace HonglornBL
{
    public class Honglorn
    {
        HonglornDbFactory ContextFactory { get; }

        public Honglorn(System.Configuration.ConnectionStringSettings connectionStringSettings)
        {
            if (string.IsNullOrWhiteSpace(connectionStringSettings.ProviderName))
            {
                throw new ArgumentException(nameof(connectionStringSettings.ProviderName));
            }

            if (string.IsNullOrWhiteSpace(connectionStringSettings.ConnectionString))
            {
                throw new ArgumentException(nameof(connectionStringSettings.ConnectionString));
            }

            ContextFactory = new HonglornDbFactory(connectionStringSettings);
        }

        public Honglorn(DbConnection connection)
        {
            ContextFactory = new HonglornDbFactory(connection);
        }

        public IEnumerable<IStudentPerformance> StudentPerformances(string course, short year)
        {
            using (var db = ContextFactory.CreateContext())
            {
                var result = new List<IStudentPerformance>();

                IQueryable<Student> relevantStudents = (from s in db.Student
                                                        where s.StudentCourseRel.Any(rel => rel.Year == year && rel.CourseName == course)
                                                        orderby s.Surname, s.Forename, s.YearOfBirth descending
                                                        select s).Include(s => s.Competitions);

                foreach (Student student in relevantStudents)
                {
                    Competition competition = student.Competitions.SingleOrDefault(c => c.Year == year);

                    result.Add(new StudentPerformance(student.PKey, student.Forename, student.Surname, competition?.Sprint, competition?.Jump, competition?.Throw, competition?.MiddleDistance));
                }

                return result;
            }
        }

        ICollection<Student> GetStudents(string course, short year)
        {
            using (var db = ContextFactory.CreateContext())
            {
                return (from s in db.Student
                        where s.StudentCourseRel.Any(rel => rel.Year == year && rel.CourseName == course)
                        orderby s.Surname, s.Forename, s.YearOfBirth descending
                        select s).Include(s => s.Competitions).ToArray();
            }
        }

        public async Task<IEnumerable<IResult>> GetResultsAsync(string course, short year)
        {
            return await Task.Factory.StartNew(() => GetResults(course, year));
        }

        IEnumerable<IResult> GetResults(string course, short year)
        {
            IEnumerable<IResult> results;

            IEnumerable<Student> students = GetStudents(course, year);
            string className = GetClassName(course);

            using (var db = ContextFactory.CreateContext())
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

        IEnumerable<IResult> CalculateCompetitionResults(IEnumerable<Student> students, short year, CompetitionDisciplineContainer disciplineCollection)
        {
            var competitionResults = new List<ICompetitionResult>();

            using (var db = ContextFactory.CreateContext())
            {
                IEnumerable<string> classes = (from s in students
                                               join rel in db.StudentCourseRel on s.PKey equals rel.StudentPKey
                                               where rel.Year == year
                                               select GetClassName(rel.CourseName)).Distinct();

                var meta = (from m in db.CompetitionReportMeta
                            where m.Year == year
                            select new { m.HonoraryCertificatePercentage, m.VictoryCertificatePercentage }).Single();

                foreach (string @class in classes)
                {
                    IEnumerable<Student> maleStudents = (from s in db.Student
                                                         join rel in db.StudentCourseRel on s.PKey equals rel.StudentPKey
                                                         where s.Sex == Sex.Male && rel.Year == year
                                                         select new { s, rel.CourseName }).AsEnumerable().Where(i => GetClassName(i.CourseName) == @class).Select(i => i.s).ToList();

                    IEnumerable<Student> femaleStudents = (from s in db.Student
                                                           join rel in db.StudentCourseRel on s.PKey equals rel.StudentPKey
                                                           where s.Sex == Sex.Female && rel.Year == year
                                                           select new { s, rel.CourseName }).AsEnumerable().Where(i => GetClassName(i.CourseName) == @class).Select(i => i.s).ToList();

                    if (maleStudents.Any())
                    {
                        var maleCalculator = new CompetitionCalculator(disciplineCollection.MaleSprint.LowIsBetter, disciplineCollection.MaleJump.LowIsBetter, disciplineCollection.MaleThrow.LowIsBetter, disciplineCollection.MaleMiddleDistance.LowIsBetter, meta.HonoraryCertificatePercentage, meta.VictoryCertificatePercentage);

                        foreach (Student maleStudent in maleStudents)
                        {
                            Competition competition = (from sc in maleStudent.Competitions
                                                          where sc.Year == year
                                                          select sc).SingleOrDefault() ?? new Competition();

                            maleCalculator.AddStudentMeasurement(maleStudent.PKey, competition.Sprint, competition.Jump, competition.Throw, competition.MiddleDistance);
                        }

                        competitionResults.AddRange(maleCalculator.Results());
                    }

                    if (femaleStudents.Any())
                    {
                        var femaleCalculator = new CompetitionCalculator(disciplineCollection.FemaleSprint.LowIsBetter, disciplineCollection.FemaleJump.LowIsBetter, disciplineCollection.FemaleThrow.LowIsBetter, disciplineCollection.FemaleMiddleDistance.LowIsBetter, meta.HonoraryCertificatePercentage, meta.VictoryCertificatePercentage);

                        foreach (Student femaleStudent in femaleStudents)
                        {
                            Competition competition = (from sc in femaleStudent.Competitions
                                                          where sc.Year == year
                                                          select sc).SingleOrDefault() ?? new Competition();

                            femaleCalculator.AddStudentMeasurement(femaleStudent.PKey, competition.Sprint, competition.Jump, competition.Throw, competition.MiddleDistance);
                        }

                        competitionResults.AddRange(femaleCalculator.Results());
                    }
                }
            }

            return from c in competitionResults
                   join s in students on c.Identifier equals s.PKey
                   orderby s.Surname, s.Forename, s.YearOfBirth descending
                   select new Result(s.Forename, s.Surname, c.SprintScore, c.JumpScore, c.ThrowScore, c.MiddleDistanceScore, (ushort) (c.SprintScore + c.JumpScore + c.ThrowScore + c.MiddleDistanceScore), c.Certificate);
        }

        IEnumerable<IResult> CalculateTraditionalResults(IEnumerable<Student> students, short year, TraditionalDisciplineContainer disciplineCollection)
        {
            ICollection<IResult> results = new List<IResult>();

            foreach (Student student in students)
            {
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

                ushort[] scores =
                {
                    TraditionalCalculator.CalculateScore(disciplines[0], competition.Sprint),
                    TraditionalCalculator.CalculateScore(disciplines[1], competition.Jump),
                    TraditionalCalculator.CalculateScore(disciplines[2], competition.Throw),
                    TraditionalCalculator.CalculateScore(disciplines[3], competition.MiddleDistance)
                };

                var totalScore = (ushort) scores.OrderByDescending(s => s).Take(3).Sum(s => s);

                int studentAge = year - student.YearOfBirth;

                results.Add(new Result(student.Forename, student.Surname, scores[0], scores[1], scores[2], scores[3], totalScore, DetermineTraditionalCertificate(student.Sex, studentAge, totalScore)));
            }

            return results;
        }

        Certificate DetermineTraditionalCertificate(Sex sex, int age, ushort totalScore)
        {
            Certificate result;

            using (var db = ContextFactory.CreateContext())
            {
                //bug: exception when students are too young to be in this list
                var scoreBoundaries = (from meta in db.TraditionalReportMeta
                                       where meta.Sex == sex
                                             && meta.Age <= age
                                       orderby meta.Age descending
                                       select new { meta.Age, meta.HonoraryCertificateScore, meta.VictoryCertificateScore }).First();

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

        public void UpdateSingleStudentCompetition(Guid studentPKey, short year, float? sprint, float? jump, float? @throw, float? middleDistance)
        {
            using (var db = ContextFactory.CreateContext())
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

        public ICollection<IDiscipline> FilteredCompetitionDisciplines(DisciplineType disciplineType)
        {
            using (var db = ContextFactory.CreateContext())
            {
                return (from d in db.CompetitionDiscipline
                        where d.Type == disciplineType
                        select d).OrderBy(d => d.Name).ToArray();
            }
        }

        public ICollection<IDiscipline> FilteredTraditionalDisciplines(DisciplineType disciplineType, Sex sex)
        {
            using (var db = ContextFactory.CreateContext())
            {
                return (from d in db.TraditionalDiscipline
                        where d.Type == disciplineType && d.Sex == sex
                        select d).OrderBy(d => d.Name).ToArray();
            }
        }

        public ICollection<CompetitionDiscipline> AllCompetitionDisciplines()
        {
            using (var db = ContextFactory.CreateContext())
            {
                return db.CompetitionDiscipline.ToArray();
            }
        }

        public IDisciplineCollection AssignedDisciplines(string className, short year)
        {
            using (var db = ContextFactory.CreateContext())
            {
                return (from col in db.DisciplineCollection
                        where col.ClassName == className && col.Year == year
                        select col).SingleOrDefault();
            }
        }

        public void CreateOrUpdateCompetitionDiscipline(Guid disciplinePKey, DisciplineType type, string name, string unit, bool lowIsBetter)
        {
            using (var db = ContextFactory.CreateContext())
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

        public void DeleteCompetitionDisciplineByPKey(Guid pKey)
        {
            try
            {
                using (var db = ContextFactory.CreateContext())
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
        public Game? GetGameType(string className, short year)
        {
            Game? result = null;

            using (var db = ContextFactory.CreateContext())
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

        public void CreateOrUpdateDisciplineCollection(string className, short year, Guid maleSprintPKey, Guid maleJumpPKey, Guid maleThrowPKey, Guid maleMiddleDistancePKey, Guid femaleSprintPKey, Guid femaleJumpPKey, Guid femaleThrowPKey, Guid femaleMiddleDistancePKey)
        {
            using (var db = ContextFactory.CreateContext())
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
        public ICollection<short> YearsWithStudentData()
        {
            using (var db = ContextFactory.CreateContext())
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
        public ICollection<string> ValidCourseNames(short year)
        {
            using (var db = ContextFactory.CreateContext())
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
        public ICollection<string> ValidClassNames(short year)
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
        public async Task<ICollection<ImportedStudentRecord>> ImportStudentsFromFile(string filePath, short year, IProgress<ProgressReport> progress)
        {
            if (!IsValidYear(year))
            {
                throw new ArgumentException($"{year} is not a valid year.");
            }

            progress.Report(new ProgressReport { Percentage = 0, IsIndeterminate = true, Message = "Lese Daten aus Excel Datei..." });

            ICollection<ImportedStudentRecord> studentsFromExcelSheet = await Task.Factory.StartNew(() => GetImporter(filePath).ReadStudentsFromFile(filePath));

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

                    await Task.Factory.StartNew(() => ImportSingleStudent(student.Forename, student.Surname, student.Sex, student.YearOfBirth, importStudent.ImportedCourseName, year));
                }

                currentlyImported++;
                progress.Report(new ProgressReport { Percentage = PercentageValue(currentlyImported, studentsFromExcelSheet.Count), IsIndeterminate = false, Message = "Schreibe Daten in die Datenbank..." });
            }

            progress.Report(new ProgressReport { Percentage = 100, IsIndeterminate = false, Message = "Schreibe Daten in die Datenbank..." });

            return studentsFromExcelSheet;
        }

        static readonly IDictionary<string, Func<IStudentImporter>> ExtensionImporterMap = new Dictionary<string, Func<IStudentImporter>>
        {
            { ".xls", () => new ExcelImporter() },
            { ".xlsx", () => new ExcelImporter() },
            { ".csv", () => new CsvImporter() }
        };

        static IStudentImporter GetImporter(string filePath)
        {
            string extension = Path.GetExtension(filePath);

            if (string.IsNullOrWhiteSpace(extension))
            {
                throw new ArgumentException($"The file {filePath} has no extension.", filePath);
            }

            try
            {
                return ExtensionImporterMap[extension]();
            }
            catch (KeyNotFoundException e)
            {
                throw new NotSupportedException($"Importing students from a file with the extension {extension} is not supported.", e);
            }
        }

        /// <summary>
        /// Adds a single student to the database
        /// </summary>
        /// <param name="forename">The student's forename.</param>
        /// <param name="surname">The student's surname.</param>
        /// <param name="courseName">The name of the course this student is part of, for the given year.</param>
        /// <param name="sex">The student's gender.</param>
        /// <param name="yearOfBirth">The year the student was born in.</param>
        /// <param name="year">The year this record is valid in. This is usually the current year.</param>
        public void ImportSingleStudent(string forename, string surname, Sex sex, short yearOfBirth, string courseName, short year)
        {
            //todo: handle exception
            GetClassName(courseName); //check whether the course name can be mapped to a class name

            //todo: verify year

            using (var db = ContextFactory.CreateContext())
            {
                IQueryable<Student> studentQuery = from s in db.Student
                                                   where s.Forename == forename
                                                         && s.Surname == surname
                                                         && s.Sex == sex
                                                         && s.YearOfBirth == yearOfBirth
                                                   select s;

                Student existingStudent = studentQuery.SingleOrDefault();

                if (existingStudent == null)
                {
                    var newStudent = new Student(forename, surname, sex, yearOfBirth);

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

        public void CreateOrUpdateCompetitionReportMeta(short year, byte honoraryCertificatePercentage, byte victoryCertificatePercentage, byte grade1Percentage, byte grade2Percentage, byte grade3Percentage, byte grade4Percentage, byte grade5Percentage)
        {
            //todo: validation

            using (var db = ContextFactory.CreateContext())
            {
                CompetitionReportMeta existingMeta = db.CompetitionReportMeta.SingleOrDefault(m => m.Year == year);

                if (existingMeta == null)
                {
                    db.CompetitionReportMeta.Add(new CompetitionReportMeta
                    {
                        Year = year,
                        HonoraryCertificatePercentage = honoraryCertificatePercentage,
                        VictoryCertificatePercentage = victoryCertificatePercentage,
                        Grade1Percentage = grade1Percentage,
                        Grade2Percentage = grade2Percentage,
                        Grade3Percentage = grade3Percentage,
                        Grade4Percentage = grade4Percentage,
                        Grade5Percentage = grade5Percentage
                    });
                }
                else
                {
                    existingMeta.HonoraryCertificatePercentage = honoraryCertificatePercentage;
                    existingMeta.VictoryCertificatePercentage = victoryCertificatePercentage;
                    existingMeta.Grade1Percentage = grade1Percentage;
                    existingMeta.Grade2Percentage = grade2Percentage;
                    existingMeta.Grade3Percentage = grade3Percentage;
                    existingMeta.Grade4Percentage = grade4Percentage;
                    existingMeta.Grade5Percentage = grade5Percentage;
                }

                db.SaveChanges();
            }
        }
    }
}