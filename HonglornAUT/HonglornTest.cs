using HonglornBL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Common;
using System.Linq;

namespace HonglornAUT
{
    [TestClass]
    [DeploymentItem("EntityFramework.SqlServer.dll")]
    public class HonglornTest
    {
        static DbConnection CreateConnection() => Effort.DbConnectionFactory.CreateTransient();

        public TestContext TestContext { get; set; }

        [TestMethod]
        public void ImportStudentsFromFileAsync_BlessedFile_NoErrors()
        {
            var sut = new Honglorn(CreateConnection());

            sut.CreateTraditionalTrackAndFieldGame("Leichtathletik Wettkampf", DateTime.Parse("1/1/2019"));

            TraditionalTrackAndFieldGameManager game = sut.GetGames().TraditionalTrackAndFieldGames.Single();

            Assert.AreEqual(DateTime.Parse("1/1/2019"), game.GameDate);
            Assert.AreEqual("Leichtathletik Wettkampf", game.GameName);
        }
    }
}