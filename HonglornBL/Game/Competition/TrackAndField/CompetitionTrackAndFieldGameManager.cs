using System;
using System.Collections.Generic;
using System.Linq;
using HonglornBL.Games.Competition.TrackAndField;
using HonglornBL.Models.Framework;

namespace HonglornBL
{
    public class CompetitionTrackAndFieldGameManager : IGameManager<CompetitionTrackAndFieldResult>
    {
        internal HonglornDbFactory ContextFactory { get; set; }

        Guid GamePKey { get; }

        internal CompetitionTrackAndFieldGameManager(Guid gamePKey, HonglornDbFactory contextFactory)
        {
            GamePKey = gamePKey;
            ContextFactory = contextFactory;
        }

        CompetitionTrackAndFieldGame Game(HonglornDb db)
        {
            CompetitionTrackAndFieldGame game = db.CompetitionTrackAndFieldGame.Find(GamePKey);

            if (game == null)
            {
                throw new GameNotFoundException($"No game with key {GamePKey} found.");
            }

            return game;
        }

        public ICollection<CompetitionTrackAndFieldResult> CalculateResults()
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return Game(db).EvaluationGroups.Select(group => group.CalculateResult(db)).ToList();
            }
        }
    }
}