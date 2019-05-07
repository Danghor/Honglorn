using HonglornBL.Enums;
using HonglornBL.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace HonglornBL.Games.Traditional.TrackAndField
{
    public abstract class TraditionalTrackAndFieldDiscipline : Discipline
    {
        [Required]
        public Sex Sex { get; set; }

        [Required]
        public float ConstantA { get; set; }

        [Required]
        public float ConstantC { get; set; }

        internal int CalculateScore(Handicap handicap, double? value)
        {
            return value == null ? 0 : CleanScore(CalculateNonNullRawScore(handicap, value.Value));
        }

        static int CleanScore(double rawScore)
        {
            return (int)Math.Max(0, Math.Floor(rawScore));
        }

        internal abstract double CalculateNonNullRawScore(Handicap handicap, double value);
    }
}