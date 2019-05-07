using HonglornBL.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace HonglornBL.Games.Traditional.TrackAndField
{
    public class TraditionalTrackAndFieldSprintDiscipline : TraditionalTrackAndFieldDiscipline
    {
        [Required]
        public Measurement Measurement { get; set; }

        [Required]
        public short Distance { get; set; }

        public float? Overhead { get; set; }

        internal override double CalculateNonNullRawScore(Handicap handicap, double value)
        {
            return (Distance / (value + (Overhead ?? 0)) - ConstantA) / ConstantC;
        }
    }
}