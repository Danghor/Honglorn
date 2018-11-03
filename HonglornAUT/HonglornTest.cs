using System;
using System.Collections.Generic;
using System.Linq;
using HonglornBL;
using HonglornBL.Import;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HonglornAUT
{
    [TestClass]
    public partial class HonglornTest
    {
        readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["test"].ConnectionString;

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
