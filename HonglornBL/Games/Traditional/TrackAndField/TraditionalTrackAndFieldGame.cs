﻿using System;
using HonglornBL.Models.Entities;
using System.Collections.Generic;
using HonglornBL.Models.Framework;

namespace HonglornBL.Games.Traditional.TrackAndField
{
    public class TraditionalTrackAndFieldGame : Game<TraditionalTrackAndFieldDiscipline, TraditionalTrackAndFieldResult>
    {
        public override ICollection<TraditionalTrackAndFieldResult> CalculateResults()
        {
            //using (HonglornDb db = contextFactory.CreateContext())
            //{
            //    foreach (var performance in GamePerformances)
            //    {


            //    }
            //}
            throw new NotImplementedException();
        }
    }
}