using System;
using System.Collections.Generic;
using System.Linq;
using HonglornBL;
using HonglornBL.Enums;
using HonglornBL.Import;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;

namespace HonglornAUT
{
    [TestClass]
    public class HonglornTest
    {
        [TestMethod]
        public void ImportSingleStudent_Regular_StudentSuccessfullyAdded()
        {
            DbConnection connection = Effort.DbConnectionFactory.CreateTransient();

            var sut = new Honglorn(connection);

            sut.ImportSingleStudent("Cave", "Johnson", Sex.Male, 1928, "08B", 2018);

            IEnumerable<IStudentPerformance> studentPerformance = sut.StudentPerformances("08B", 2018);

            Assert.AreEqual(1, studentPerformance.Count());
        }

        [TestMethod]
        public void ImportSingleStudent_Regular_StudentSuccessfullyAdded2()
        {
            DbConnection connection = Effort.DbConnectionFactory.CreateTransient();

            var sut = new Honglorn(connection);

            sut.ImportSingleStudent("Cave", "Johnson", Sex.Male, 1928, "08C", 2018);

            IEnumerable<IStudentPerformance> studentPerformance = sut.StudentPerformances("08B", 2018);

            Assert.AreEqual(0, studentPerformance.Count());
        }

        [TestMethod]
        public void ImportStudentsFromFile_EmptyFileName_RaisesException()
        {
            DbConnection connection = Effort.DbConnectionFactory.CreateTransient();

            var sut = new Honglorn(connection);

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
