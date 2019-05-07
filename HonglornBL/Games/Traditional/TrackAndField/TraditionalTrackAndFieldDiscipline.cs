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

        // TODO: need the reference date for the game so we know if the student had a disability at this date or not

        internal int CalculateScore(Student student, double? value)
        {
            return value == null ? 0 : (int)Math.Max(0, Math.Floor(CalculateNonNullRawScore(student, value.Value)));
        }

        internal abstract double CalculateNonNullRawScore(Student student, double value);
    }
}