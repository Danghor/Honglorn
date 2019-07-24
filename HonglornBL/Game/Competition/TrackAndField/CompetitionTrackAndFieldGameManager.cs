using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HonglornBL.Models.Framework;

namespace HonglornBL.Game.Competition.TrackAndField
{
    public class CompetitionTrackAndFieldGameManager : GameManager<CompetitionTrackAndFieldGame, CompetitionTrackAndFieldPerformance>
    {
        internal CompetitionTrackAndFieldGameManager(Guid pKey, HonglornDbFactory contextFactory, Func<HonglornDb, DbSet<CompetitionTrackAndFieldGame>> getDbSet) : base(pKey, contextFactory, getDbSet) { }

        protected override Exception CreateNotFoundException(string message)
        {
            return new GameNotFoundException(message);
        }

        public ICollection<CompetitionTrackAndFieldResult> CalculateResults()
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return Entity(db).EvaluationGroups.Select(group => group.CalculateResult(db)).ToList();
            }
        }
    }
}