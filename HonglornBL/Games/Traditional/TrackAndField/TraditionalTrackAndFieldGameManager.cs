using HonglornBL.Games.Traditional.TrackAndField;
using HonglornBL.Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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
                return Game(db).GamePerformances.Select(performance => performance.CalculateResult(db)).ToList();
            }
        }
    }
}