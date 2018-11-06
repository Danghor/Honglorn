using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using HonglornBL;
using HonglornBL.Enums;
using HonglornBL.Import;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HonglornAUT
{
    [TestClass]
    public class HonglornTest
    {
        static DbConnection CreateConnection() => Effort.DbConnectionFactory.CreateTransient();

        public TestContext TestContext { get; set; }

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
        public void GetResults_TraditionalCompetition_CorrectScoresAndCertificatesCalculated()
        {
            var sut = new Honglorn(CreateConnection());

            sut.ImportSingleStudent("Dave", "Pennington", Sex.Male, 2008, "08C", 2018);
            sut.ImportSingleStudent("Hannah", "Smith", Sex.Female, 2007, "08C", 2018);

            Guid sprintPKey = (from d in sut.FilteredTraditionalDisciplines(DisciplineType.Sprint, Sex.Male)
                               where d.ToString() == "Sprint 100 m (Manual)"
                               select d.PKey).Single();

            Guid jumpPKey = (from d in sut.FilteredTraditionalDisciplines(DisciplineType.Jump, Sex.Male)
                             where d.ToString() == "Weitsprung"
                             select d.PKey).Single();

            Guid throwPKey = (from d in sut.FilteredTraditionalDisciplines(DisciplineType.Throw, Sex.Male)
                              where d.ToString() == "Kugelstoß"
                              select d.PKey).Single();

            Guid middleDistancePKey = (from d in sut.FilteredTraditionalDisciplines(DisciplineType.MiddleDistance, Sex.Male)
                                       where d.ToString() == "Lauf 1000 m"
                                       select d.PKey).Single();

            Guid sprintFPKey = (from d in sut.FilteredTraditionalDisciplines(DisciplineType.Sprint, Sex.Female)
                                where d.ToString() == "Sprint 100 m (Manual)"
                                select d.PKey).Single();

            Guid jumpFPKey = (from d in sut.FilteredTraditionalDisciplines(DisciplineType.Jump, Sex.Female)
                              where d.ToString() == "Hochsprung"
                              select d.PKey).Single();

            Guid throwFPKey = (from d in sut.FilteredTraditionalDisciplines(DisciplineType.Throw, Sex.Female)
                               where d.ToString() == "200-g-Ballwurf"
                               select d.PKey).Single();

            Guid middleDistanceFPKey = (from d in sut.FilteredTraditionalDisciplines(DisciplineType.MiddleDistance, Sex.Female)
                                        where d.ToString() == "Lauf 800 m"
                                        select d.PKey).Single();

            sut.CreateOrUpdateDisciplineCollection("8", 2018, sprintPKey, jumpPKey, throwPKey, middleDistancePKey, sprintFPKey, jumpFPKey, throwFPKey, middleDistanceFPKey);

            IEnumerable<IStudentPerformance> performances = sut.StudentPerformances("08C", 2018).ToList();

            Guid davePKey = performances.Single(p => p.Forename == "Dave").StudentPKey;
            Guid hannahPKey = performances.Single(p => p.Forename == "Hannah").StudentPKey;

            sut.UpdateSingleStudentCompetition(davePKey, 2018, 13.9f, 4.37f, 8.2f, 294);
            sut.UpdateSingleStudentCompetition(hannahPKey, 2018, 14.9f, 1.44f, 32.5f, 234);

            IEnumerable<IResult> results = sut.GetResultsAsync("08C", 2018).Result.ToList();

            IResult daveResult = results.Single(r => r.Forename == "Dave");
            IResult hannahResult = results.Single(r => r.Forename == "Hannah");

            Assert.AreEqual(1428, daveResult.Score);
            Assert.AreEqual(Certificate.Honorary, daveResult.Certificate);

            Assert.AreEqual(1492, hannahResult.Score);
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

        [TestMethod]
        [DeploymentItem("SumTestData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\SumTestData.xml", "Row", DataAccessMethod.Sequential)]
        public void SumTest()
        {
            int a1 = Int32.Parse((string)TestContext.DataRow["A1"]);
            int a2 = Int32.Parse((string)TestContext.DataRow["A2"]);
            int result = Int32.Parse((string)TestContext.DataRow["Result"]);
            ExecSumTest(a1, a2, result);
        }


        static void ExecSumTest(int a1, int a2, int result)
        {
            Assert.AreEqual(a1 + a2, result);
        }
    }
}
