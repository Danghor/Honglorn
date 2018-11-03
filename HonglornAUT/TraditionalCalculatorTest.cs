using System.Linq;
using HonglornBL.Models.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HonglornAUT
{
    [TestClass]
    public partial class TraditionalCalculatorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var db = new TestDb())
            {
                db.Student.Add(new Student
                {
                    Forename = "Cave",
                    Surname = "Johnson"
                });

                db.SaveChanges();
            }

            using (var db = new TestDb())
            {
                Assert.AreEqual(1, db.Student.Count());
            }
        }
    }
}
