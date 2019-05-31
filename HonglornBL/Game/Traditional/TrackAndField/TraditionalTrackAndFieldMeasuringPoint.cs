using HonglornBL.Models.Entities;

namespace HonglornBL.Games.Traditional.TrackAndField
{
    public class TraditionalTrackAndFieldMeasuringPoint : MeasuringPoint<TraditionalTrackAndFieldDiscipline>
    {
        internal int CalculateScore(Handicap handicap)
        {
            return Discipline.CalculateScore(handicap, Measurement);
        }
    }
}