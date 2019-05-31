using HonglornBL.Models.Entities;
using System;

namespace HonglornBL.Games.Traditional.TrackAndField
{
    public class TraditionalTrackAndFieldGame : Game<TraditionalTrackAndFieldPerformance>
    {
        public TraditionalTrackAndFieldGame() { }

        public TraditionalTrackAndFieldGame(string name, DateTime date) : base(name, date) { }
    }
}