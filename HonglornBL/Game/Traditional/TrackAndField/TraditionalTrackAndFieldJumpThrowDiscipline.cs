using System;

namespace HonglornBL.Game.Traditional.TrackAndField
{
    public abstract class TraditionalTrackAndFieldJumpThrowDiscipline : TraditionalTrackAndFieldDiscipline
    {
        internal override double CalculateNonNullRawScore(double value)
        {
            return (Math.Sqrt(value) - ConstantA) / ConstantC;
        }
    }
}