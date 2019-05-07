using HonglornBL.Models.Entities;
using System;

namespace HonglornBL.Games.Traditional.TrackAndField
{
    public class TraditionalTrackAndFieldJumpThrowDiscipline : TraditionalTrackAndFieldDiscipline
    {
        internal override double CalculateNonNullRawScore(Student student, double value)
        {
            return (Math.Sqrt(value) - ConstantA) / ConstantC;
        }
    }
}