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

            sut.ImportSingleStudent("Dave", "Pennington", Sex.Male, 1998, "08C", 2018);
            sut.ImportSingleStudent("Hannah", "Smith", Sex.Female, 1997, "08C", 2018);


            IEnumerable<IStudentPerformance> studentPerformance = sut.StudentPerformances("08B", 2018);

            Assert.Inconclusive();
        }

        [TestMethod]
        public void ImportStudentsFromFile_EmptyFileName_RaisesException()
        {
            var sut = new Honglorn(CreateConnection());

            try
            {
                ICollection<ImportedStudentRecord> result = sut.ImportStudentsFromFile(string.Empty, 2018, new Progress<ProgressReport>()).Result;
            }
            catch (AggregateException e)
            {
                Assert.IsInstanceOfType(e.InnerExceptions.Single(), typeof(ArgumentException));
            }
        }
    }
}
