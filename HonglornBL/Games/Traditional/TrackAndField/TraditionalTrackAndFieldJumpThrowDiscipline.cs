using HonglornBL.Models.Entities;
using System;
using System.Linq;

namespace HonglornBL.Games.Traditional.TrackAndField
{
    public class TraditionalTrackAndFieldJumpThrowDiscipline : TraditionalTrackAndFieldDiscipline
    {
        internal override double CalculateNonNullRawScore(Handicap handicap, double value)
        {
            if (handicap != null)
            {
                double factor = (from h in TraditionalTrackAndFieldDisciplineHandicaps
                                 where h.Handicap == handicap && h.Sex == Sex
                                 select h.Factor).Single();

                value *= factor;
            }

            return (Math.Sqrt(value) - ConstantA) / ConstantC;
        }
    }
}