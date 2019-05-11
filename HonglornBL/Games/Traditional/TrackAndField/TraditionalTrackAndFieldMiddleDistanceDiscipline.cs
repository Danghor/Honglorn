namespace HonglornBL.Games.Traditional.TrackAndField
{
    public class TraditionalTrackAndFieldMiddleDistanceDiscipline : TraditionalTrackAndFieldRunningDiscipline
    {
        internal override double CalculateNonNullRawScore(double value)
        {
            return (Distance / value - ConstantA) / ConstantC;
        }
    }
}