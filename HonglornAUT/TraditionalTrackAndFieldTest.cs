using HonglornBL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Common;
using System.Linq;

namespace HonglornAUT
{
    [TestClass]
    [DeploymentItem("EntityFramework.SqlServer.dll")]
    public class TraditionalTrackAndFieldTest
    {
        static DbConnection CreateConnection() => Effort.DbConnectionFactory.CreateTransient();

        public TestContext TestContext { get; set; }

        const string GameName = "Leichtathletik Wettkampf";
        readonly DateTime gameDate = DateTime.Parse("1/1/2019");

        TraditionalTrackAndFieldGameManager CreateGameManager()
        {
            var sut = new Honglorn(CreateConnection());

            sut.CreateTraditionalTrackAndFieldGame(GameName, gameDate);

            return sut.GetGames().TraditionalTrackAndFieldGames.Single();
        }

        [TestMethod]
        public void CreateGameShouldSaveNameAndDate()
        {
            var sut = new Honglorn(CreateConnection());

            sut.CreateTraditionalTrackAndFieldGame(GameName, gameDate);

            TraditionalTrackAndFieldGameManager game = sut.GetGames().TraditionalTrackAndFieldGames.Single();

            Assert.AreEqual(GameName, game.GameName);
            Assert.AreEqual(gameDate, game.GameDate);
        }
    }
}