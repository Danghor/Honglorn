using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using HonglornBL.Games.Traditional.TrackAndField;
using HonglornBL.Models.Framework;

namespace HonglornBL
{
    public class TraditionalTrackAndFieldGameManager : IGameManager<TraditionalTrackAndFieldResult>
    {
        internal HonglornDbFactory ContextFactory { get; set; }

        Guid GamePKey { get; }

        internal TraditionalTrackAndFieldGameManager(Guid gamePKey, HonglornDbFactory contextFactory)
        {
            GamePKey = gamePKey;
            ContextFactory = contextFactory;
        }

        TraditionalTrackAndFieldGame Game(HonglornDb db)
        {
            TraditionalTrackAndFieldGame game = db.TraditionalTrackAndFieldGame.Find(GamePKey);

            if (game == null)
            {
                throw new GameNotFoundException($"No game with key {GamePKey} found.");
            }

            return game;
        }

        public string GameName
        {
            get
            {
                using (HonglornDb db = ContextFactory.CreateContext())
                {
                    return Game(db).Name;
                }
            }

            set
            {
                using (HonglornDb db = ContextFactory.CreateContext())
                {
                    Game(db).Name = value;
                    db.SaveChanges();
                }
            }
        }

        public ICollection<TraditionalTrackAndFieldResult> CalculateResults()
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                TraditionalTrackAndFieldGame game = Game(db);

                var results = new List<TraditionalTrackAndFieldResult>();

                foreach (var performance in game.GamePerformances)
                {

                }

                return null;
            }
        }
    }
}