using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HonglornBL.Models.Framework;

namespace HonglornBL.Game.Traditional.TrackAndField
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