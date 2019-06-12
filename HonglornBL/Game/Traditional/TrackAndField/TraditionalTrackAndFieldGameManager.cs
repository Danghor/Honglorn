using HonglornBL.Game;
using HonglornBL.Games.Traditional.TrackAndField;
using HonglornBL.Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HonglornBL
{
    public class TraditionalTrackAndFieldGameManager : GameManager<TraditionalTrackAndFieldGame, TraditionalTrackAndFieldPerformance>
    {
        internal TraditionalTrackAndFieldGameManager(Guid pKey, HonglornDbFactory contextFactory) : base(pKey, contextFactory) { }

        protected override Exception CreateNotFoundException(string message)
        {
            return new GameNotFoundException(message);
        }

        protected override DbSet<TraditionalTrackAndFieldGame> GetDbSet(HonglornDb db)
        {
            return db.TraditionalTrackAndFieldGame;
        }

        public ICollection<TraditionalTrackAndFieldResult> CalculateResults()
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return Entity(db).GamePerformances.Select(performance => performance.CalculateResult(db)).ToList();
            }
        }
    }
}