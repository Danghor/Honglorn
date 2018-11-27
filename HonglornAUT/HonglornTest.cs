using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using HonglornBL;
using HonglornBL.Enums;
using HonglornBL.Import;
using HonglornBL.Interfaces;
using HonglornBL.Models.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HonglornAUT
{
    [TestClass]
    [DeploymentItem(@"EntityFramework.SqlServer.dll")]
    public class HonglornTest
    {
        static DbConnection CreateConnection() => Effort.DbConnectionFactory.CreateTransient();

        public TestContext TestContext { get; set; }

        string GetData(string tagName) => TestContext.DataRow[tagName] as string;

        float GetFloat(string tagName) => float.Parse(GetData(tagName), CultureInfo.InvariantCulture);

        ushort GetUshort(string tagName) => ushort.Parse(GetData(tagName), CultureInfo.InvariantCulture);

        short GetShort(string tagName) => short.Parse(GetData(tagName), CultureInfo.InvariantCulture);

        bool GetBool(string tagName) => bool.Parse(GetData(tagName));

        static readonly Random Random = new Random();

        static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, 5).Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        [TestMethod]
        public void ImportSingleStudent_Regular_StudentSuccessfullyAdded()
        {
            const string forename = "Cave";
            const string surname = "Johnson";
            const string courseName = "08B";
            const short year = 2018;

            var sut = new Honglorn(CreateConnection());

            sut.ImportSingleStudent(forename, surname, Sex.Male, 1928, courseName, year);

            IStudentPerformance studentPerformance = sut.StudentPerformances(courseName, year).Single();

            Assert.AreEqual(forename, studentPerformance.Forename);
            Assert.AreEqual(surname, studentPerformance.Surname);
            Assert.IsNull(studentPerformance.Sprint);
            Assert.IsNull(studentPerformance.Jump);
            Assert.IsNull(studentPerformance.Throw);
            Assert.IsNull(studentPerformance.MiddleDistance);
        }

        [TestMethod]
        public void UpdateSingleStudentCompetition_CompetitionDataAdded_SuccessfullySaved()
        {
            const string forename = "Cave";
            const string surname = "Johnson";
            const string courseName = "08B";
            const short year = 2018;
            const float sprintPerformance = 12.56f;
            const float throwPerformance = 22.59f;

            var sut = new Honglorn(CreateConnection());

            sut.ImportSingleStudent(forename, surname, Sex.Male, 1928, courseName, year);

            Guid pKey = sut.StudentPerformances(courseName, year).Single().StudentPKey;

            sut.UpdateSingleStudentCompetition(pKey, year, sprintPerformance, null, throwPerformance, null);

            IStudentPerformance studentPerformance = sut.StudentPerformances(courseName, year).Single();

            Assert.AreEqual(forename, studentPerformance.Forename);
            Assert.AreEqual(surname, studentPerformance.Surname);
            Assert.AreEqual(sprintPerformance, studentPerformance.Sprint);
            Assert.IsNull(studentPerformance.Jump);
            Assert.AreEqual(throwPerformance, studentPerformance.Throw);
            Assert.IsNull(studentPerformance.MiddleDistance);
        }

        [TestMethod]
        public void UpdateSingleStudentCompetition_CompetitionDataChanged_SuccessfullyChanged()
        {
            const string forename = "Cave";
            const string surname = "Johnson";
            const string courseName = "08B";
            const short year = 2018;
            const float sprintPerformance = 5;
            const float jumpPerformance = 6;
            const float throwPerformance = 7;
            const float middleDistancePerformance = 8;

            var sut = new Honglorn(CreateConnection());

            sut.ImportSingleStudent(forename, surname, Sex.Male, 1928, courseName, year);

            Guid pKey = sut.StudentPerformances(courseName, year).Single().StudentPKey;

            sut.UpdateSingleStudentCompetition(pKey, year, 1, 2, 3, 4);
            sut.UpdateSingleStudentCompetition(pKey, year, sprintPerformance, jumpPerformance, throwPerformance, middleDistancePerformance);

            IStudentPerformance studentPerformance = sut.StudentPerformances(courseName, year).Single();

            Assert.AreEqual(forename, studentPerformance.Forename);
            Assert.AreEqual(surname, studentPerformance.Surname);
            Assert.AreEqual(sprintPerformance, studentPerformance.Sprint);
            Assert.AreEqual(jumpPerformance, studentPerformance.Jump);
            Assert.AreEqual(throwPerformance, studentPerformance.Throw);
            Assert.AreEqual(middleDistancePerformance, studentPerformance.MiddleDistance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateSingleStudentCompetition_UnknownStudent_ThrowsException()
        {
            var sut = new Honglorn(CreateConnection());
            sut.UpdateSingleStudentCompetition(new Guid(), 2018, 1, 2, 3, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetResults_NoDisciplinesSet_ThrowsException()
        {
            var sut = new Honglorn(CreateConnection());

            try
            {
                IEnumerable<IResult> unused = sut.GetResultsAsync("A", 2000).Result;
            }
            catch (AggregateException e)
            {
                throw e.InnerExceptions.Single();
            }
        }

        [TestMethod]
        [DeploymentItem("TraditionalResults.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\TraditionalResults.xml", "Row", DataAccessMethod.Sequential)]
        public void GetResults_TraditionalCompetition_CorrectScoresAndCertificatesCalculated()
        {
            const string course = "08D";
            var sex = (Sex) Enum.Parse(typeof(Sex), GetData("Sex"));
            short year = GetShort("Year");

            var sut = new Honglorn(CreateConnection());

            sut.ImportSingleStudent("Kim", "Pennington", sex, GetShort("YearOfBirth"), course, year);

            Func<DisciplineType, string, Guid> getDisciplineKey = (type, name) => sut.FilteredTraditionalDisciplines(type, sex).Single(d => d.ToString() == GetData(name)).PKey;

            Guid sprintPKey = getDisciplineKey(DisciplineType.Sprint, "SprintName");
            Guid jumpPKey = getDisciplineKey(DisciplineType.Jump, "JumpName");
            Guid throwPKey = getDisciplineKey(DisciplineType.Throw, "ThrowName");
            Guid middleDistancePKey = getDisciplineKey(DisciplineType.MiddleDistance, "MiddleDistanceName");

            string className = sut.ValidClassNames(year).Single();
            sut.CreateOrUpdateDisciplineCollection(className, year, sprintPKey, jumpPKey, throwPKey, middleDistancePKey, sprintPKey, jumpPKey, throwPKey, middleDistancePKey);

            Guid studentPKey = sut.StudentPerformances(course, year).Single().StudentPKey;
            sut.UpdateSingleStudentCompetition(studentPKey, year, GetFloat("SprintPerformance"), GetFloat("JumpPerformance"), GetFloat("ThrowPerformance"), GetFloat("MiddleDistancePerformance"));

            IResult result = sut.GetResultsAsync(course, year).Result.Single();

            Assert.AreEqual(GetUshort("SprintScore"), result.SprintScore);
            Assert.AreEqual(GetUshort("JumpScore"), result.JumpScore);
            Assert.AreEqual(GetUshort("ThrowScore"), result.ThrowScore);
            Assert.AreEqual(GetUshort("MiddleDistanceScore"), result.MiddleDistanceScore);
            Assert.AreEqual(GetUshort("TotalScore"), result.Score);
            Assert.AreEqual(Enum.Parse(typeof(Certificate), GetData("Certificate")), result.Certificate);
        }

        [TestMethod]
        public void GetResults_TraditionalCompetitionNullValues_ZeroScore()
        {
            const string course = "08D";
            const Sex sex = Sex.Male;
            const short year = 2017;

            var sut = new Honglorn(CreateConnection());

            sut.ImportSingleStudent("Kim", "Pennington", sex, 2008, course, year);

            Func<DisciplineType, string, Guid> getDisciplineKey = (type, name) => sut.FilteredTraditionalDisciplines(type, sex).Single(d => d.ToString() == name).PKey;

            Guid sprintPKey = getDisciplineKey(DisciplineType.Sprint, "Sprint 100 m (Manual)");
            Guid jumpPKey = getDisciplineKey(DisciplineType.Jump, "Weitsprung");
            Guid throwPKey = getDisciplineKey(DisciplineType.Throw, "Kugelstoß");
            Guid middleDistancePKey = getDisciplineKey(DisciplineType.MiddleDistance, "Lauf 1000 m");

            string className = sut.ValidClassNames(year).Single();
            sut.CreateOrUpdateDisciplineCollection(className, year, sprintPKey, jumpPKey, throwPKey, middleDistancePKey, sprintPKey, jumpPKey, throwPKey, middleDistancePKey);

            Guid studentPKey = sut.StudentPerformances(course, year).Single().StudentPKey;
            sut.UpdateSingleStudentCompetition(studentPKey, year, null, null, null, null);

            IResult result = sut.GetResultsAsync(course, year).Result.Single();

            Assert.AreEqual(0, result.SprintScore);
            Assert.AreEqual(0, result.JumpScore);
            Assert.AreEqual(0, result.ThrowScore);
            Assert.AreEqual(0, result.MiddleDistanceScore);
            Assert.AreEqual(0, result.Score);
            Assert.AreEqual(Certificate.Participation, result.Certificate);
        }

        [TestMethod]
        public void AllCompetitionDisciplines_CreateCompetitionDiscipline_SuccessfullyCreated()
        {
            const DisciplineType type = DisciplineType.Sprint;
            const string name = "Run very fast";
            const string unit = "seconds";
            const bool lowIsBetter = true;

            var sut = new Honglorn(CreateConnection());

            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, type, name, unit, lowIsBetter);

            CompetitionDiscipline discipline = sut.AllCompetitionDisciplines().Single();

            Assert.AreEqual(type, discipline.Type);
            Assert.AreEqual(name, discipline.Name);
            Assert.AreEqual(unit, discipline.Unit);
            Assert.AreEqual(lowIsBetter, discipline.LowIsBetter);
        }

        [TestMethod]
        public void DeleteCompetitionDisciplineByPKey_DeleteDiscipline_SuccessfullyDeleted()
        {
            var sut = new Honglorn(CreateConnection());

            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.Sprint, "Run very fast", "seconds", true);

            Guid disciplinePKey = sut.AllCompetitionDisciplines().Single().PKey;
            sut.DeleteCompetitionDisciplineByPKey(disciplinePKey);

            bool competitionDisciplinesExist = sut.AllCompetitionDisciplines().Any();
            Assert.IsFalse(competitionDisciplinesExist);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteCompetitionDisciplineByPKey_UnknownDiscipline_ThrowsException()
        {
            var sut = new Honglorn(CreateConnection());
            sut.DeleteCompetitionDisciplineByPKey(Guid.Empty);
        }

        [TestMethod]
        [DeploymentItem("CompetitionResults.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\CompetitionResults.xml", "Row", DataAccessMethod.Sequential)]
        public void GetResults_CompetitionResults_CorrectScoresAndCertificatesCalculated()
        {
            short year = GetShort("Year");

            ICollection<CompetitionStudent> students = new List<CompetitionStudent>();

            foreach (DataRow courseRow in TestContext.DataRow.GetChildRows("Row_Course"))
            {
                string courseName = courseRow["Name"].ToString();

                foreach (DataRow student in courseRow.GetChildRows("Course_Student"))
                {
                    var sex = (Sex) Enum.Parse(typeof(Sex), student["Sex"].ToString());

                    float sprint = float.Parse(student["Sprint"].ToString(), CultureInfo.InvariantCulture);
                    float jump = float.Parse(student["Jump"].ToString(), CultureInfo.InvariantCulture);
                    float @throw = float.Parse(student["Throw"].ToString(), CultureInfo.InvariantCulture);
                    float middleDistance = float.Parse(student["MiddleDistance"].ToString(), CultureInfo.InvariantCulture);

                    ushort sprintScore = ushort.Parse(student["SprintScore"].ToString());
                    ushort jumpScore = ushort.Parse(student["JumpScore"].ToString());
                    ushort throwScore = ushort.Parse(student["ThrowScore"].ToString());
                    ushort middleDistanceScore = ushort.Parse(student["MiddleDistanceScore"].ToString());

                    var certificate = (Certificate) Enum.Parse(typeof(Certificate), student["Certificate"].ToString());

                    students.Add(new CompetitionStudent(courseName, RandomString(), RandomString(), sex, sprint, jump, @throw, middleDistance, sprintScore, jumpScore, throwScore, middleDistanceScore, certificate));
                }
            }

            var sut = new Honglorn(CreateConnection());

            foreach (CompetitionStudent s in students)
            {
                sut.ImportSingleStudent(s.Forename, s.Surname, s.Sex, (short) (DateTime.Now.Year - 10), s.Course, year);
            }

            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.Sprint, "A", "a", GetBool("SprintLowIsBetterMale"));
            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.Jump, "B", "b", GetBool("JumpLowIsBetterMale"));
            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.Throw, "C", "c", GetBool("ThrowLowIsBetterMale"));
            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.MiddleDistance, "D", "d", GetBool("MiddleDistanceLowIsBetterMale"));

            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.Sprint, "E", "e", GetBool("SprintLowIsBetterFemale"));
            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.Jump, "F", "f", GetBool("JumpLowIsBetterFemale"));
            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.Throw, "G", "g", GetBool("ThrowLowIsBetterFemale"));
            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.MiddleDistance, "H", "h", GetBool("MiddleDistanceLowIsBetterFemale"));

            Guid maleSprintGuid = sut.FilteredCompetitionDisciplines(DisciplineType.Sprint).Single(d => d.ToString() == "A").PKey;
            Guid maleJumpGuid = sut.FilteredCompetitionDisciplines(DisciplineType.Jump).Single(d => d.ToString() == "B").PKey;
            Guid maleThrowGuid = sut.FilteredCompetitionDisciplines(DisciplineType.Throw).Single(d => d.ToString() == "C").PKey;
            Guid maleMiddleDistanceGuid = sut.FilteredCompetitionDisciplines(DisciplineType.MiddleDistance).Single(d => d.ToString() == "D").PKey;

            Guid femaleSprintGuid = sut.FilteredCompetitionDisciplines(DisciplineType.Sprint).Single(d => d.ToString() == "E").PKey;
            Guid femaleJumpGuid = sut.FilteredCompetitionDisciplines(DisciplineType.Jump).Single(d => d.ToString() == "F").PKey;
            Guid femaleThrowGuid = sut.FilteredCompetitionDisciplines(DisciplineType.Throw).Single(d => d.ToString() == "G").PKey;
            Guid femaleMiddleDistanceGuid = sut.FilteredCompetitionDisciplines(DisciplineType.MiddleDistance).Single(d => d.ToString() == "H").PKey;

            foreach (string className in sut.ValidClassNames(year))
            {
                sut.CreateOrUpdateDisciplineCollection(className, year, maleSprintGuid, maleJumpGuid, maleThrowGuid, maleMiddleDistanceGuid, femaleSprintGuid, femaleJumpGuid, femaleThrowGuid, femaleMiddleDistanceGuid);
            }

            foreach (string course in students.Select(s => s.Course).Distinct())
            {
                IEnumerable<IStudentPerformance> performances = sut.StudentPerformances(course, year).ToList();

                foreach (CompetitionStudent student in students.Where(s => s.Course == course))
                {
                    Guid studentKey = performances.Single(p => p.Forename == student.Forename).StudentPKey;
                    sut.UpdateSingleStudentCompetition(studentKey, year, student.Sprint, student.Jump, student.Throw, student.MiddleDistance);
                }
            }

            foreach (string course in students.Select(s => s.Course).Distinct())
            {
                IEnumerable<IResult> results = sut.GetResultsAsync(course, year).Result.ToList();

                foreach (CompetitionStudent student in students.Where(s => s.Course == course))
                {
                    IResult studentResult = results.Single(r => r.Forename == student.Forename && r.Surname == student.Surname);

                    Assert.AreEqual(student.SprintScore + student.JumpScore + student.ThrowScore + student.MiddleDistanceScore, studentResult.Score);
                    Assert.AreEqual(student.Certificate, studentResult.Certificate);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ImportStudentsFromFile_EmptyFileName_ThrowsException()
        {
            var sut = new Honglorn(CreateConnection());

            try
            {
                ICollection<ImportedStudentRecord> unused = sut.ImportStudentsFromFile(string.Empty, 2018, new Progress<ProgressReport>()).Result;
            }
            catch (AggregateException e)
            {
                throw e.InnerExceptions.Single();
            }
        }

        [TestMethod]
        public void GetGameType_EmptyStringAndZero_Null()
        {
            var sut = new Honglorn(CreateConnection());

            Game? gameType = sut.GetGameType(string.Empty, 0);

            Assert.IsNull(gameType);
        }

        [TestMethod]
        public void GetGameType_CompetitionDisciplines_CompetitionGame()
        {
            const string className = "7";
            const int year = 2015;

            var sut = new Honglorn(CreateConnection());

            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.Sprint, "Sprinten", "Sekunden", true);
            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.Jump, "Springen", "Meter", false);
            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.Throw, "Werfen", "Meter", false);
            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.MiddleDistance, "LangLaufen", "Minuten", true);

            Guid sprintKey = sut.FilteredCompetitionDisciplines(DisciplineType.Sprint).Single().PKey;
            Guid jumpKey = sut.FilteredCompetitionDisciplines(DisciplineType.Jump).Single().PKey;
            Guid throwKey = sut.FilteredCompetitionDisciplines(DisciplineType.Throw).Single().PKey;
            Guid middleDistanceKey = sut.FilteredCompetitionDisciplines(DisciplineType.MiddleDistance).Single().PKey;

            sut.CreateOrUpdateDisciplineCollection(className, year, sprintKey, jumpKey, throwKey, middleDistanceKey, sprintKey, jumpKey, throwKey, middleDistanceKey);

            Game? gameType = sut.GetGameType(className, year);

            Assert.AreEqual(Game.Competition, gameType);
        }

        [TestMethod]
        public void GetGameType_TraditionalDisciplines_TraditionalGame()
        {
            const string className = "7";
            const int year = 2015;

            var sut = new Honglorn(CreateConnection());

            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.Sprint, "Sprinten", "Sekunden", true);
            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.Jump, "Springen", "Meter", false);
            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.Throw, "Werfen", "Meter", false);
            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.MiddleDistance, "LangLaufen", "Minuten", true);

            Func<DisciplineType, Sex, Guid> getDiscipline = (t, s) => sut.FilteredTraditionalDisciplines(t, s).First().PKey;

            Guid maleSprintKey = getDiscipline(DisciplineType.Sprint, Sex.Male);
            Guid maleJumpKey = getDiscipline(DisciplineType.Jump, Sex.Male);
            Guid maleThrowKey = getDiscipline(DisciplineType.Throw, Sex.Male);
            Guid malemMiddleDistanceKey = getDiscipline(DisciplineType.MiddleDistance, Sex.Male);

            Guid femaleSprintKey = getDiscipline(DisciplineType.Sprint, Sex.Female);
            Guid femaleJumpKey = getDiscipline(DisciplineType.Jump, Sex.Female);
            Guid femaleThrowKey = getDiscipline(DisciplineType.Throw, Sex.Female);
            Guid femalemMddleDistanceKey = getDiscipline(DisciplineType.MiddleDistance, Sex.Female);

            sut.CreateOrUpdateDisciplineCollection(className, year, maleSprintKey, maleJumpKey, maleThrowKey, malemMiddleDistanceKey, femaleSprintKey, femaleJumpKey, femaleThrowKey, femalemMddleDistanceKey);

            Game? gameType = sut.GetGameType(className, year);

            Assert.AreEqual(Game.Traditional, gameType);
        }

        [TestMethod]
        public void ValidCourseNames_StudentInserted_CourseNowValid()
        {
            short year = 2019;
            string courseName = "6D";

            var sut = new Honglorn(CreateConnection());

            sut.ImportSingleStudent("Cave", "Johnson", Sex.Male, 1980, "6D", year);

            var validCourse = sut.ValidCourseNames(year).Single();

            Assert.AreEqual(courseName, validCourse);
        }

        [TestMethod]
        public void YearsWithStudentDate_StudentInserted_YearReturned()
        {
            short year = 2019;

            var sut = new Honglorn(CreateConnection());

            sut.ImportSingleStudent("Cave", "Johnson", Sex.Male, 1980, "6D", year);

            var yearWithStudentData = sut.YearsWithStudentData().Single();

            Assert.AreEqual(year, yearWithStudentData);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_NoProviderName_ThrowsException()
        {
            var settings = new ConnectionStringSettings("Foo", "Bar");
            var unused = new Honglorn(settings);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_NoConnectionString_ThrowsException()
        {
            var settings = new ConnectionStringSettings
            {
                ProviderName = "Foobar"
            };

            var unused = new Honglorn(settings);
        }

        [TestMethod]
        public void AssignedDisciplines_CompetitionDisciplines_AssignedCorrectly()
        {
            const string className = "7";
            const int year = 2015;

            var sut = new Honglorn(CreateConnection());

            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.Sprint, "Sprinten", "Sekunden", true);
            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.Jump, "Springen", "Meter", false);
            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.Throw, "Werfen", "Meter", false);
            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.MiddleDistance, "LangLaufen", "Minuten", true);

            Guid sprintKey = sut.FilteredCompetitionDisciplines(DisciplineType.Sprint).Single().PKey;
            Guid jumpKey = sut.FilteredCompetitionDisciplines(DisciplineType.Jump).Single().PKey;
            Guid throwKey = sut.FilteredCompetitionDisciplines(DisciplineType.Throw).Single().PKey;
            Guid middleDistanceKey = sut.FilteredCompetitionDisciplines(DisciplineType.MiddleDistance).Single().PKey;

            sut.CreateOrUpdateDisciplineCollection(className, year, sprintKey, jumpKey, throwKey, middleDistanceKey, sprintKey, jumpKey, throwKey, middleDistanceKey);

            IDisciplineCollection assignedDisciplines = sut.AssignedDisciplines(className, year);

            Assert.AreEqual(sprintKey, assignedDisciplines.MaleSprintPKey);
            Assert.AreEqual(jumpKey, assignedDisciplines.MaleJumpPKey);
            Assert.AreEqual(throwKey, assignedDisciplines.MaleThrowPKey);
            Assert.AreEqual(middleDistanceKey, assignedDisciplines.MaleMiddleDistancePKey);
            Assert.AreEqual(sprintKey, assignedDisciplines.FemaleSprintPKey);
            Assert.AreEqual(jumpKey, assignedDisciplines.FemaleJumpPKey);
            Assert.AreEqual(throwKey, assignedDisciplines.FemaleThrowPKey);
            Assert.AreEqual(middleDistanceKey, assignedDisciplines.FemaleMiddleDistancePKey);
        }

        [TestMethod]
        [ExpectedException(typeof(DataException))]
        public void GetResults_NoDisciplinesConfigured_ThrowsException()
        {
            var sut = new Honglorn(CreateConnection());

            try
            {
                IEnumerable<IResult> unused = sut.GetResultsAsync("6A", 2014).Result;
            }
            catch (AggregateException ex)
            {
                throw ex.InnerExceptions.Single();
            }
        }
    }
}
