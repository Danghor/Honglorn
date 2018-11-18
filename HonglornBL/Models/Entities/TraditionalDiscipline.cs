using System.ComponentModel.DataAnnotations;
using HonglornBL.Enums;

namespace HonglornBL.Models.Entities
{
    public class TraditionalDiscipline : Discipline
    {
        [Required]
        public Sex Sex { get; set; }

        public short? Distance { get; set; }

        public float? Overhead { get; set; }

        public float ConstantA { get; set; }

        public float ConstantC { get; set; }

        public Measurement? Measurement { get; set; }

        public override string ToString()
        {
            return Type == DisciplineType.Sprint ? $"{base.ToString()} ({Measurement})" : base.ToString();
        }
    }
}