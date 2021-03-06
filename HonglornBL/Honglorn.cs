using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HonglornBL.Calculation.Competition;
using HonglornBL.Calculation.Traditional;
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
            using (HonglornDb db = ContextFactory.CreateContext())
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
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return (from s in db.Student
                        where s.StudentCourseRel.Any(rel => rel.Year == year && rel.CourseName == course)
                        orderby s.Surname, s.Forename, s.YearOfBirth descending
                        select s).Include(s => s.Competitions).ToArray();
            }
        }

        public Task<IEnumerable<IResult>> GetResultsAsync(string course, short year)
        {
            return Task.Factory.StartNew(() => GetResults(course, year));
        }

        IEnumerable<IResult> GetResults(string course, short year)
        {
            IEnumerable<IResult> results;

            IEnumerable<Student> students = GetStudents(course, year);
            string className = GetClassName(course);

            using (HonglornDb db = ContextFactory.CreateContext())
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

            using (HonglornDb db = ContextFactory.CreateContext())
            {
                IEnumerable<string> classes = (from s in students
                                               join rel in db.StudentCourseRel on s.PKey equals rel.StudentPKey
                                               where rel.Year == year
                                               select GetClassName(rel.CourseName)).Distinct();

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
                        var maleCalculator = new CompetitionCalculator(disciplineCollection.MaleSprint.LowIsBetter, disciplineCollection.MaleJump.LowIsBetter, disciplineCollection.MaleThrow.LowIsBetter, disciplineCollection.MaleMiddleDistance.LowIsBetter);

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
                        var femaleCalculator = new CompetitionCalculator(disciplineCollection.FemaleSprint.LowIsBetter, disciplineCollection.FemaleJump.LowIsBetter, disciplineCollection.FemaleThrow.LowIsBetter, disciplineCollection.FemaleMiddleDistance.LowIsBetter);

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
                   select new Result(s.Forename, s.Surname, c.SprintScore, c.JumpScore, c.ThrowScore, c.MiddleDistanceScore, c.Rank, (ushort)(c.SprintScore + c.JumpScore + c.ThrowScore + c.MiddleDistanceScore), c.Certificate);
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

                var scores = new List<ushort>();

                var disciplineValuePairs = new Dictionary<TraditionalDiscipline, float?>
                {
                    { disciplines[0], competition.Sprint },
                    { disciplines[1], competition.Jump },
                    { disciplines[2], competition.Throw },
                    { disciplines[3], competition.MiddleDistance }
                };

                foreach (var pair in disciplineValuePairs)
                {
                    var calculator = new TraditionalCalculator(pair.Key, pair.Value);
                    scores.Add(calculator.CalculateScore());
                }

                var totalScore = (ushort)scores.OrderByDescending(s => s).Take(3).Sum(s => s);

                int studentAge = year - student.YearOfBirth;

                results.Add(new Result(student.Forename, student.Surname, scores[0], scores[1], scores[2], scores[3], 0, totalScore, DetermineTraditionalCertificate(student.Sex, studentAge, totalScore)));
            }

            return results;
        }

        Certificate DetermineTraditionalCertificate(Sex sex, int age, ushort totalScore)
        {
            Certificate result;

            using (HonglornDb db = ContextFactory.CreateContext())
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
            using (HonglornDb db = ContextFactory.CreateContext())
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
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return (from d in db.CompetitionDiscipline
                        where d.Type == disciplineType
                        select d).OrderBy(d => d.Name).ToArray();
            }
        }

        public ICollection<IDiscipline> FilteredTraditionalDisciplines(DisciplineType disciplineType, Sex sex)
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return (from d in db.TraditionalDiscipline
                        where d.Type == disciplineType && d.Sex == sex
                        select d).OrderBy(d => d.Name).ToArray();
            }
        }

        public ICollection<CompetitionDiscipline> AllCompetitionDisciplines()
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return db.CompetitionDiscipline.ToArray();
            }
        }

        public IDisciplineCollection AssignedDisciplines(string className, short year)
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return (from col in db.DisciplineCollection
                        where col.ClassName == className && col.Year == year
                        select col).SingleOrDefault();
            }
        }

        public void CreateCompetitionDiscipline(DisciplineType type, string name, string unit, bool lowIsBetter)
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                db.CompetitionDiscipline.Add(new CompetitionDiscipline
                {
                    Type = type,
                    Name = name,
                    Unit = unit,
                    LowIsBetter = lowIsBetter
                });

                db.SaveChanges();
            }
        }

        public void UpdateCompetitionDiscipline(Guid disciplinePKey, DisciplineType type, string name, string unit, bool lowIsBetter)
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                CompetitionDiscipline competition = db.CompetitionDiscipline.Find(disciplinePKey);

                if (competition == null)
                {
                    throw new ArgumentException($"A {nameof(CompetitionDiscipline)} with PKey {disciplinePKey} does not exist in the database.", nameof(disciplinePKey));
                }

                competition.Type = type;
                competition.Name = name;
                competition.Unit = unit;
                competition.LowIsBetter = lowIsBetter;

                db.SaveChanges();
            }
        }

        public void DeleteCompetitionDiscipline(Guid disciplinePKey)
        {
            try
            {
                using (HonglornDb db = ContextFactory.CreateContext())
                {
                    var discipline = new CompetitionDiscipline
                    {
                        PKey = disciplinePKey
                    };

                    db.Entry(discipline).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ArgumentException($"A {nameof(CompetitionDiscipline)} with PKey {disciplinePKey} does not exist in the database.", nameof(disciplinePKey), ex);
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

            using (HonglornDb db = ContextFactory.CreateContext())
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
            using (HonglornDb db = ContextFactory.CreateContext())
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
            using (HonglornDb db = ContextFactory.CreateContext())
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
            using (HonglornDb db = ContextFactory.CreateContext())
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
        public async Task<ICollection<ImportedStudentRecord>> ImportStudentsFromFileAsync(string filePath, short year, IProgress<ProgressReport> progress)
        {
            if (!IsValidYear(year))
            {
                throw new ArgumentException($"{year} is not a valid year.");
            }

            progress.Report(new ProgressReport(0, "Lese Daten aus Datei...", true));

            ICollection<ImportedStudentRecord> studentsFromExcelSheet = await Task.Factory.StartNew(() => GetImporter(filePath).ReadStudentsFromFile(filePath));

            var currentlyImported = 0;

            progress.Report(new ProgressReport(0, "Schreibe Daten in die Datenbank...", false));

            foreach (ImportedStudentRecord importStudent in studentsFromExcelSheet)
            {
                if (importStudent.Errors == null)
                {
                    var student = new Student
                    {
                        Forename = importStudent.ImportedForename,
                        Surname = importStudent.ImportedSurname,
                        Sex = SexDictionary[importStudent.ImportedSex],
                        YearOfBirth = short.Parse(importStudent.ImportedYearOfBirth)
                    };

                    await Task.Factory.StartNew(() => ImportSingleStudent(student.Forename, student.Surname, student.Sex, student.YearOfBirth, importStudent.ImportedCourseName, year));
                }

                currentlyImported++;
                progress.Report(new ProgressReport(PercentageValue(currentlyImported, studentsFromExcelSheet.Count), "Schreibe Daten in die Datenbank...", false));
            }

            progress.Report(new ProgressReport(100, "Schreibe Daten in die Datenbank...", false));

            return studentsFromExcelSheet;
        }

        static readonly IDictionary<string, Func<IStudentImporter>> ExtensionImporterMap = new Dictionary<string, Func<IStudentImporter>>
        {
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
                throw new NotSupportedException($"Importing students from a file with the extension {extension} is not supported. Supported are {string.Join(", ", ExtensionImporterMap.Keys)}", e);
            }
        }

        //todo: make this method private and create new public method that performs validation
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

            using (HonglornDb db = ContextFactory.CreateContext())
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
    }
}