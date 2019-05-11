﻿using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System.Linq;

namespace HonglornBL.Games.Traditional.TrackAndField
{
    public class TraditionalTrackAndFieldPerformance : GamePerformance<TraditionalTrackAndFieldMeasuringPoint, TraditionalTrackAndFieldDiscipline, TraditionalTrackAndFieldPerformance>
    {
        internal TraditionalTrackAndFieldResult CalculateResult(HonglornDb context)
        {
            var handicap = (from h in Student.StudentHandicaps
                            where h.DateStart >= Game.Date && (h.DateEnd == null || h.DateEnd <= Game.Date)
                            select h.Handicap).SingleOrDefault();

            var totalScore = MeasuringPoints.Select(m => m.CalculateScore(handicap)).OrderByDescending(i => i).Take(3).Sum();

            var studentAge = Game.Date.Year - Student.DateOfBirth.Year;

            var certificateType = (from a in context.TraditionalTrackAndFieldCertificateAssignment
                                   where a.Sex == Student.Sex && a.Age == studentAge
                                   select a.CertificateType).Single();

            return new TraditionalTrackAndFieldResult(totalScore, certificateType, Student);
        }
    }
}