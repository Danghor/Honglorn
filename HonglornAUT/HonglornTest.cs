using System;
using System.Collections.Generic;
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
            var sut = new Honglorn(CreateConnection());

            sut.ImportSingleStudent("Dave", "Pennington", Sex.Male, 2008, "08C", 2018);
            sut.ImportSingleStudent("Hannah", "Smith", Sex.Female, 2007, "08C", 2018);

            Guid sprintPKey = (from d in sut.FilteredTraditionalDisciplines(DisciplineType.Sprint, Sex.Male)
                               where d.ToString() == GetData("MaleSprintName")
                               select d.PKey).Single();

            Guid jumpPKey = (from d in sut.FilteredTraditionalDisciplines(DisciplineType.Jump, Sex.Male)
                             where d.ToString() == GetData("MaleJumpName")
                             select d.PKey).Single();

            Guid throwPKey = (from d in sut.FilteredTraditionalDisciplines(DisciplineType.Throw, Sex.Male)
                              where d.ToString() == GetData("MaleThrowName")
                              select d.PKey).Single();

            Guid middleDistancePKey = (from d in sut.FilteredTraditionalDisciplines(DisciplineType.MiddleDistance, Sex.Male)
                                       where d.ToString() == GetData("MaleMiddleDistanceName")
                                       select d.PKey).Single();

            Guid sprintFPKey = (from d in sut.FilteredTraditionalDisciplines(DisciplineType.Sprint, Sex.Female)
                                where d.ToString() == GetData("FemaleSprintName")
                                select d.PKey).Single();

            Guid jumpFPKey = (from d in sut.FilteredTraditionalDisciplines(DisciplineType.Jump, Sex.Female)
                              where d.ToString() == GetData("FemaleJumpName")
                              select d.PKey).Single();

            Guid throwFPKey = (from d in sut.FilteredTraditionalDisciplines(DisciplineType.Throw, Sex.Female)
                               where d.ToString() == GetData("FemaleThrowName")
                               select d.PKey).Single();

            Guid middleDistanceFPKey = (from d in sut.FilteredTraditionalDisciplines(DisciplineType.MiddleDistance, Sex.Female)
                                        where d.ToString() == GetData("FemaleMiddleDistanceName")
                                        select d.PKey).Single();

            sut.CreateOrUpdateDisciplineCollection("8", 2018, sprintPKey, jumpPKey, throwPKey, middleDistancePKey, sprintFPKey, jumpFPKey, throwFPKey, middleDistanceFPKey);

            IEnumerable<IStudentPerformance> performances = sut.StudentPerformances("08C", 2018).ToList();

            Guid davePKey = performances.Single(p => p.Forename == "Dave").StudentPKey;
            Guid hannahPKey = performances.Single(p => p.Forename == "Hannah").StudentPKey;

            sut.UpdateSingleStudentCompetition(davePKey, 2018, GetFloat("MaleSprintPerformance"), GetFloat("MaleJumpPerformance"), GetFloat("MaleThrowPerformance"), GetFloat("MaleMiddleDistancePerformance"));
            sut.UpdateSingleStudentCompetition(hannahPKey, 2018, GetFloat("FemaleSprintPerformance"), GetFloat("FemaleJumpPerformance"), GetFloat("FemaleThrowPerformance"), GetFloat("FemaleMiddleDistancePerformance"));

            IEnumerable<IResult> results = sut.GetResultsAsync("08C", 2018).Result.ToList();

            IResult daveResult = results.Single(r => r.Forename == "Dave");
            IResult hannahResult = results.Single(r => r.Forename == "Hannah");

            Assert.AreEqual(ushort.Parse(GetData("ExpectedMaleScore")), daveResult.Score);
            Assert.AreEqual(Enum.Parse(typeof(Certificate), GetData("ExpectedMaleCertificate")), daveResult.Certificate);

            Assert.AreEqual(ushort.Parse(GetData("ExpectedFemaleScore")), hannahResult.Score);
            Assert.AreEqual(Enum.Parse(typeof(Certificate), GetData("ExpectedFemaleCertificate")), hannahResult.Certificate);
        }

        [TestMethod]
        public void GetResults_CompetitionResults_CorrectScoresAndCertificatesCalculated()
        {
            var sut = new Honglorn(CreateConnection());

            sut.ImportSingleStudent("Dave", "Pennington", Sex.Male, 2008, "08C", 2018);
            sut.ImportSingleStudent("Hannah", "Smith", Sex.Female, 2007, "08C", 2018);

            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.Sprint, "A", "s", true);
            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.Jump, "B", "Zonen", false);
            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.Throw, "C", "Zonen", false);
            sut.CreateOrUpdateCompetitionDiscipline(Guid.Empty, DisciplineType.MiddleDistance, "D", "s", true);

            var sprintGuid = sut.FilteredCompetitionDisciplines(DisciplineType.Sprint).Single().PKey;
            var jumpGuid = sut.FilteredCompetitionDisciplines(DisciplineType.Jump).Single().PKey;
            var throwGuid = sut.FilteredCompetitionDisciplines(DisciplineType.Throw).Single().PKey;
            var middleDistanceGuid = sut.FilteredCompetitionDisciplines(DisciplineType.MiddleDistance).Single().PKey;

            sut.CreateOrUpdateDisciplineCollection("8", 2018, sprintGuid, jumpGuid, throwGuid, middleDistanceGuid, sprintGuid, jumpGuid, throwGuid, middleDistanceGuid);

            sut.CreateOrUpdateCompetitionReportMeta(2018, 80, 30, 85, 70, 55, 39, 20);

            IEnumerable<IStudentPerformance> performances = sut.StudentPerformances("08C", 2018).ToList();

            Guid davePKey = performances.Single(p => p.Forename == "Dave").StudentPKey;
            Guid hannahPKey = performances.Single(p => p.Forename == "Hannah").StudentPKey;

            sut.UpdateSingleStudentCompetition(davePKey, 2018, 1, 2, 3, 4);
            sut.UpdateSingleStudentCompetition(hannahPKey, 2018, 1, 2, 3, 4);

            IEnumerable<IResult> results = sut.GetResultsAsync("08C", 2018).Result.ToList();

            IResult daveResult = results.Single(r => r.Forename == "Dave");
            IResult hannahResult = results.Single(r => r.Forename == "Hannah");

            Assert.AreEqual(4, daveResult.Score);
            Assert.AreEqual(Certificate.Honorary, daveResult.Certificate);

            Assert.AreEqual(4, hannahResult.Score);
            Assert.AreEqual(Certificate.Honorary, hannahResult.Certificate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ImportStudentsFromFile_EmptyFileName_RaisesException()
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
