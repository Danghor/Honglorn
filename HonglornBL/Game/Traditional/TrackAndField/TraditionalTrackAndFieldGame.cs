using System;
using HonglornBL.Models.Entities;

namespace HonglornBL.Game.Traditional.TrackAndField
{
    public class TraditionalTrackAndFieldGame : Game<TraditionalTrackAndFieldPerformance>
    {
        public TraditionalTrackAndFieldGame() { }

        public TraditionalTrackAndFieldGame(string name, DateTime date) : base(name, date) { }
    }
}