using HonglornBL.Enums;
using HonglornBL.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace HonglornBL
{
    public abstract class TraditionalTrackAndFieldDiscipline : Discipline
    {
        [Required]
        public Sex Sex { get; set; }

        internal int CalculateScore(Student student, double? value)
        {
            return value == null ? 0 : CalculateNonNullScore(student, value.Value);
        }

        internal abstract int CalculateNonNullScore(Student student, double value);
    }
}