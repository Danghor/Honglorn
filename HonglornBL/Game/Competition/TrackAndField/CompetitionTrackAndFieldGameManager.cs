using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HonglornBL.Game;
using HonglornBL.Games.Competition.TrackAndField;
using HonglornBL.Models.Framework;

namespace HonglornBL
{
    public class CompetitionTrackAndFieldGameManager : GameManager<CompetitionTrackAndFieldGame, CompetitionTrackAndFieldPerformance>
    {
        internal CompetitionTrackAndFieldGameManager(Guid pKey, HonglornDbFactory contextFactory) : base(pKey, contextFactory) { }

        protected override DbSet<CompetitionTrackAndFieldGame> GetDbSet(HonglornDb db)
        {
            return db.CompetitionTrackAndFieldGame;
        }

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