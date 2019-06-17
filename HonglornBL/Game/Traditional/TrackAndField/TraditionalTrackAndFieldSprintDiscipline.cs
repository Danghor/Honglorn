using System.ComponentModel.DataAnnotations;

namespace HonglornBL.Game.Traditional.TrackAndField
{
    public class TraditionalTrackAndFieldSprintDiscipline : TraditionalTrackAndFieldRunningDiscipline
    {
        [Required]
        public Measurement Measurement { get; set; }

        public float? Overhead { get; set; }

        internal override double CalculateNonNullRawScore(double value)
        {
            return (Distance / (value + (Overhead ?? 0)) - ConstantA) / ConstantC;
        }
    }
}