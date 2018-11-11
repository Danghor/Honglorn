using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using HonglornBL;
using HonglornBL.Enums;
using HonglornBL.Import;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HonglornAUT
{
    [TestClass]
    [DeploymentItem(@"EntityFramework.SqlServer.dll")]
    public class HonglornTest
    {
        static DbConnection CreateConnection()
        {
            return Effort.DbConnectionFactory.CreateTransient();
        }

        public TestContext TestContext { get; set; }

        string GetData(string tagName)
        {
            return TestContext.DataRow[tagName] as string;
        }

        float GetFloat(string tagName)
        {
            return float.Parse(GetData(tagName), CultureInfo.InvariantCulture);
        }

        ushort GetUshort(string tagName)
        {
            return ushort.Parse(GetData(tagName), CultureInfo.InvariantCulture);
        }

        short GetShort(string tagName)
        {
            return short.Parse(GetData(tagName), CultureInfo.InvariantCulture);
        }

        bool GetBool(string tagName)
        {
            return bool.Parse(GetData(tagName));
        }

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
        public void EditStudentPerformance_SuccessfullyAddedSaved()
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
                IEnumerable<IResult> result = sut.GetResultsAsync("A", 2000).Result;
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
            const string maleForename = "Dave";
            const string femaleForename = "Hannah";
            const short year = 2018;

            var sut = new Honglorn(CreateConnection());

            sut.ImportSingleStudent(maleForename, "Pennington", Sex.Male, 2008, course, year);
            sut.ImportSingleStudent(femaleForename, "Smith", Sex.Female, 2007, course, year);

            Func<DisciplineType, Sex, string, Guid> getDisciplineKey = (type, sex, name) => sut.FilteredTraditionalDisciplines(type, sex).Single(d => d.ToString() == GetData(name)).PKey;

            Guid maleSprintPKey = getDisciplineKey(DisciplineType.Sprint, Sex.Male, "MaleSprintName");
            Guid maleJumpPKey = getDisciplineKey(DisciplineType.Jump, Sex.Male, "MaleJumpName");
            Guid maleThrowPKey = getDisciplineKey(DisciplineType.Throw, Sex.Male, "MaleThrowName");
            Guid maleMiddleDistancePKey = getDisciplineKey(DisciplineType.MiddleDistance, Sex.Male, "MaleMiddleDistanceName");

            Guid femaleSprintPKey = getDisciplineKey(DisciplineType.Sprint, Sex.Female, "FemaleSprintName");
            Guid femaleJumpPKey = getDisciplineKey(DisciplineType.Jump, Sex.Female, "FemaleJumpName");
            Guid femaleThrowPKey = getDisciplineKey(DisciplineType.Throw, Sex.Female, "FemaleThrowName");
            Guid femaleMiddleDistancePKey = getDisciplineKey(DisciplineType.MiddleDistance, Sex.Female, "FemaleMiddleDistanceName");

            string className = sut.ValidClassNames(year).Single();

            sut.CreateOrUpdateDisciplineCollection(className, year, maleSprintPKey, maleJumpPKey, maleThrowPKey, maleMiddleDistancePKey, femaleSprintPKey, femaleJumpPKey, femaleThrowPKey, femaleMiddleDistancePKey);

            IEnumerable<IStudentPerformance> performances = sut.StudentPerformances(course, year).ToList();

            Guid davePKey = performances.Single(p => p.Forename == maleForename).StudentPKey;
            Guid hannahPKey = performances.Single(p => p.Forename == femaleForename).StudentPKey;

            sut.UpdateSingleStudentCompetition(davePKey, year, GetFloat("MaleSprintPerformance"), GetFloat("MaleJumpPerformance"), GetFloat("MaleThrowPerformance"), GetFloat("MaleMiddleDistancePerformance"));
            sut.UpdateSingleStudentCompetition(hannahPKey, year, GetFloat("FemaleSprintPerformance"), GetFloat("FemaleJumpPerformance"), GetFloat("FemaleThrowPerformance"), GetFloat("FemaleMiddleDistancePerformance"));

            IEnumerable<IResult> results = sut.GetResultsAsync(course, year).Result.ToList();

            IResult daveResult = results.Single(r => r.Forename == maleForename);
            IResult hannahResult = results.Single(r => r.Forename == femaleForename);

            Assert.AreEqual(GetUshort("ExpectedMaleScore"), daveResult.Score);
            Assert.AreEqual(Enum.Parse(typeof(Certificate), GetData("ExpectedMaleCertificate")), daveResult.Certificate);

            Assert.AreEqual(GetUshort("ExpectedFemaleScore"), hannahResult.Score);
            Assert.AreEqual(Enum.Parse(typeof(Certificate), GetData("ExpectedFemaleCertificate")), hannahResult.Certificate);
        }

        [TestMethod]
        [DeploymentItem("CompetitionResults.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\CompetitionResults.xml", "Row", DataAccessMethod.Sequential)]
        public void GetResults_CompetitionResults_CorrectScoresAndCertificatesCalculated()
        {
            const string course = "08D";
            const string maleForename = "Dave";
            const string femaleForename = "Hannah";
            short year = GetShort("Year");

            ICollection<CompetitionStudent> students = new List<CompetitionStudent>();

            foreach (DataRow courseRow in TestContext.DataRow.GetChildRows("Row_Course"))
            {
                var courseName = courseRow["Name"] as string;

                foreach (DataRow student in courseRow.GetChildRows("Course_Student"))
                {
                    var sex = (Sex) Enum.Parse(typeof(Sex), student["Sex"] as string);

                    float sprint = float.Parse(student["Sprint"] as string);
                    float jump = float.Parse(student["Jump"] as string);
                    float @throw = float.Parse(student["Throw"] as string);
                    float middleDistance = float.Parse(student["MiddleDistance"] as string);

                    ushort sprintScore = ushort.Parse(student["SprintScore"] as string);
                    ushort jumpScore = ushort.Parse(student["JumpScore"] as string);
                    ushort throwScore = ushort.Parse(student["ThrowScore"] as string);
                    ushort middleDistanceScore = ushort.Parse(student["MiddleDistanceScore"] as string);

                    var certificate = (Certificate) Enum.Parse(typeof(Certificate), student["Certificate"] as string);

                    students.Add(new CompetitionStudent(courseName, RandomString(), RandomString(), sex, sprint, jump, @throw, middleDistance, sprintScore, jumpScore, throwScore, middleDistanceScore, certificate));
                }
            }

            var sut = new Honglorn(CreateConnection());

            foreach (CompetitionStudent s in students)
            {
                sut.ImportSingleStudent(s.Forename, s.Surname, s.Sex, (short) (DateTime.Now.Year - 10), s.Course, year);
            }

            sut.ImportSingleStudent(maleForename, "Pennington", Sex.Male, 2008, course, year);
            sut.ImportSingleStudent(femaleForename, "Smith", Sex.Female, 2007, course, year);

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

            string className = sut.ValidClassNames(year).Single();

            sut.CreateOrUpdateDisciplineCollection(className, year, maleSprintGuid, maleJumpGuid, maleThrowGuid, maleMiddleDistanceGuid, femaleSprintGuid, femaleJumpGuid, femaleThrowGuid, femaleMiddleDistanceGuid);

            sut.CreateOrUpdateCompetitionReportMeta(year, 80, 30, 85, 70, 55, 39, 20);

            IEnumerable<IStudentPerformance> performances = sut.StudentPerformances(course, year).ToList();

            Guid davePKey = performances.Single(p => p.Forename == maleForename).StudentPKey;
            Guid hannahPKey = performances.Single(p => p.Forename == femaleForename).StudentPKey;

            sut.UpdateSingleStudentCompetition(davePKey, year, 1, 2, 3, 4);
            sut.UpdateSingleStudentCompetition(hannahPKey, year, 1, 2, 3, 4);

            IEnumerable<IResult> results = sut.GetResultsAsync(course, year).Result.ToList();

            IResult daveResult = results.Single(r => r.Forename == maleForename);
            IResult hannahResult = results.Single(r => r.Forename == femaleForename);

            Assert.AreEqual(4, daveResult.Score);
            Assert.AreEqual(Certificate.Honorary, daveResult.Certificate);

            Assert.AreEqual(4, hannahResult.Score);
            Assert.AreEqual(Certificate.Honorary, hannahResult.Certificate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ImportStudentsFromFile_EmptyFileName_ThrowsException()
        {
            var sut = new Honglorn(CreateConnection());

            try
            {
                ICollection<ImportedStudentRecord> result = sut.ImportStudentsFromFile(string.Empty, 2018, new Progress<ProgressReport>()).Result;
            }
            catch (AggregateException e)
            {
                throw e.InnerExceptions.Single();
            }
        }
    }
}
