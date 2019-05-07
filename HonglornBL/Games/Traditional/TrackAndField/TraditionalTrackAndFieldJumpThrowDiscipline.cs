using HonglornBL.Models.Entities;
using System;

namespace HonglornBL.Games.Traditional.TrackAndField
{
    public class TraditionalTrackAndFieldJumpThrowDiscipline : TraditionalTrackAndFieldDiscipline
    {
        internal override double CalculateNonNullRawScore(Handicap handicap, double value)
        {
            return (Math.Sqrt(value) - ConstantA) / ConstantC;
        }
    }
}