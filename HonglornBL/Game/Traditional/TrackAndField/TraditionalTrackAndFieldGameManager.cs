using HonglornBL.Games.Traditional.TrackAndField;
using HonglornBL.Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HonglornBL
{
    public class TraditionalTrackAndFieldGameManager : IGameManager<TraditionalTrackAndFieldResult>
    {
        HonglornDbFactory ContextFactory { get; }

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
                return GetValue(g => g.Name);
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

        public DateTime GameDate
        {
            get
            {
                return GetValue(g => g.Date);
            }

            set
            {
                using (HonglornDb db = ContextFactory.CreateContext())
                {
                    Game(db).Date = value;
                    db.SaveChanges();
                }
            }
        }

        T GetValue<T>(Func<TraditionalTrackAndFieldGame, T> getValue)
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return getValue(Game(db));
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