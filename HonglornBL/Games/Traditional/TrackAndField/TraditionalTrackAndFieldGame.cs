using HonglornBL.Models.Entities;
using System;
using System.Collections.Generic;

namespace HonglornBL.Games.Traditional.TrackAndField
{
    public class TraditionalTrackAndFieldGame : Game<TraditionalTrackAndFieldDiscipline, TraditionalTrackAndFieldResult>
    {
        public override ICollection<TraditionalTrackAndFieldResult> CalculateResults()
        {
            foreach(var performance in GamePerformances)
            {

            }
        }
    }
}