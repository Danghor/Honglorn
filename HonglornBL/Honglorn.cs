using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using HonglornBL.Enums;
using HonglornBL.Exceptions;
using HonglornBL.Import;
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

        //ICollection<Student> GetStudents(string course, short year)
        //{
        //    using (HonglornDb db = ContextFactory.CreateContext())
        //    {
        //        return (from s in db.Student
        //                where s.StudentCourseRel.Any(rel => rel.DateStart == year && rel.Course.Name == course)
        //                orderby s.Surname, s.Forename, s.DateOfBirth descending
        //                select s).Include(s => s.Competitions).ToArray();
        //    }
        //}

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
        //public async Task<ICollection<ImportedStudentRecord>> ImportStudentsFromFileAsync(string filePath, short year, IProgress<ProgressReport> progress)
        //{
        //    if (!IsValidYear(year))
        //    {
        //        throw new ArgumentException($"{year} is not a valid year.");
        //    }

        //    progress.Report(new ProgressReport(0, "Lese Daten aus Datei...", true));

        //    ICollection<ImportedStudentRecord> studentsFromExcelSheet = await Task.Factory.StartNew(() => GetImporter(filePath).ReadStudentsFromFile(filePath));

        //    var currentlyImported = 0;

        //    progress.Report(new ProgressReport(0, "Schreibe Daten in die Datenbank...", false));

        //    foreach (ImportedStudentRecord importStudent in studentsFromExcelSheet)
        //    {
        //        if (importStudent.Errors == null)
        //        {
        //            var student = new Student
        //            {
        //                Forename = importStudent.ImportedForename,
        //                Surname = importStudent.ImportedSurname,
        //                Sex = SexDictionary[importStudent.ImportedSex],
        //                DateOfBirth = short.Parse(importStudent.ImportedYearOfBirth)
        //            };

        //            await Task.Factory.StartNew(() => ImportSingleStudent(student.Forename, student.Surname, student.Sex, student.DateOfBirth, importStudent.ImportedCourseName, year));
        //        }

        //        currentlyImported++;
        //        progress.Report(new ProgressReport(PercentageValue(currentlyImported, studentsFromExcelSheet.Count), "Schreibe Daten in die Datenbank...", false));
        //    }

        //    progress.Report(new ProgressReport(100, "Schreibe Daten in die Datenbank...", false));

        //    return studentsFromExcelSheet;
        //}

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
        //public void ImportSingleStudent(string forename, string surname, Sex sex, short yearOfBirth, string courseName, short year)
        //{
        //    //todo: verify year

        //    using (HonglornDb db = ContextFactory.CreateContext())
        //    {
        //        try
        //        {
        //            Course course = db.Course.Single(c => c.Name == courseName);

        //            IQueryable<Student> studentQuery = from s in db.Student
        //                                               where s.Forename == forename
        //                                                     && s.Surname == surname
        //                                                     && s.Sex == sex
        //                                                     && s.DateOfBirth == yearOfBirth
        //                                               select s;

        //            Student existingStudent = studentQuery.SingleOrDefault();

        //            if (existingStudent == null)
        //            {
        //                var newStudent = new Student(forename, surname, sex, yearOfBirth);

        //                newStudent.AddStudentCourseRel(year, course);
        //                db.Student.Add(newStudent);
        //            }
        //            else
        //            {
        //                IEnumerable<StudentCourse> courseInformationQuery = from r in existingStudent.StudentCourseRel
        //                                                                    where r.DateStart == year
        //                                                                    select r;

        //                StudentCourse existingCourseInformation = courseInformationQuery.SingleOrDefault();

        //                if (existingCourseInformation == null)
        //                {
        //                    existingStudent.AddStudentCourseRel(year, course);
        //                }
        //                else
        //                {
        //                    existingCourseInformation.Course = course;
        //                }
        //            }

        //            db.SaveChanges();
        //        }
        //        catch (InvalidOperationException ex)
        //        {
        //            throw new CourseNotFoundException($"Course {courseName} is not present in the database.", ex);
        //        }
        //    }
        //}

        public GameCollection GetGames()
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                var collection = new GameCollection
                {
                    TraditionalTrackAndFieldGames = db.TraditionalTrackAndFieldGame.ToList(),
                    CompetitionTrackAndFieldGames = db.CompetitionTrackAndFieldGame.ToList()
                };

                AttachContextFactory(collection.TraditionalTrackAndFieldGames, ContextFactory);
                AttachContextFactory(collection.CompetitionTrackAndFieldGames, ContextFactory);

                return collection;
            }
        }

        static void AttachContextFactory<TDiscipline, TResult>(IEnumerable<Game<TDiscipline, TResult>> games, HonglornDbFactory contextFactory) where TDiscipline : Models.Entities.Discipline
        {
            foreach (var game in games)
            {
                game.contextFactory = contextFactory;
            }
        }
    }
}