using System.Linq;
using HonglornBL.Models.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HonglornAUT
{
    [TestClass]
    public partial class TraditionalCalculatorTest
    {
        readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["test"].ConnectionString;

        [TestMethod]
        public void TestMethod1()
        {
            using (var db = new TestDb(connectionString))
            {
                db.Student.Add(new Student
                {
                    Forename = "Cave",
                    Surname = "Johnson"
                });

                db.SaveChanges();
            }

            using (var db = new TestDb(connectionString))
            {
                Assert.AreEqual(1, db.Student.Count());
            }
        }
    }
}
