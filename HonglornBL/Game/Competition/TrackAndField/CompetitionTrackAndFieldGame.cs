using System;
using System.Collections.Generic;
using HonglornBL.Models.Entities;

namespace HonglornBL.Game.Competition.TrackAndField
{
    public class CompetitionTrackAndFieldGame : Game<CompetitionTrackAndFieldPerformance>
    {
        public CompetitionTrackAndFieldGame() { }

        public CompetitionTrackAndFieldGame(string name, DateTime date) : base(name, date) { }

        public ICollection<CompetitionTrackAndFieldEvaluationGroup> EvaluationGroups { get; set; } = new HashSet<CompetitionTrackAndFieldEvaluationGroup>();
    }
}