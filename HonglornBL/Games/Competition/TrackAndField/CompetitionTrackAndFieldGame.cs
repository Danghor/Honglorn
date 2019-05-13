using HonglornBL.Games.Competition.TrackAndField;
using HonglornBL.Models.Entities;
using System;

namespace HonglornBL
{
    public class CompetitionTrackAndFieldGame : Game<CompetitionTrackAndFieldPerformance>
    {
        public CompetitionTrackAndFieldGame() { }

        public CompetitionTrackAndFieldGame(string name, DateTime date) : base(name, date) { }
    }
}