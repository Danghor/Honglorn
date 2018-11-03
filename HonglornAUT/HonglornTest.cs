using System;
using System.Collections.Generic;
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
        readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["test"].ConnectionString;

        [TestMethod]
        public void ImportSingleStudent_Regular_StudentSuccessfullyAdded()
        {
            var sut = new Honglorn(connectionString);

            sut.ImportSingleStudent("Cave", "Johnson", Sex.Male, 1928, "08B", 2018);

            IEnumerable<IStudentPerformance> studentPerformance = sut.StudentPerformances("08B", 2018);

            Assert.AreEqual(1, studentPerformance.Count());
        }

        [TestMethod]
        public void ImportStudentsFromFile_EmptyFileName_RaisesException()
        {
            var sut = new Honglorn(connectionString);

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
