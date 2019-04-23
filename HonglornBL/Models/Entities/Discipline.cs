using HonglornBL.Enums;
using HonglornBL.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace HonglornBL.Models.Entities
{
    public abstract class Discipline : Entity, IDiscipline
    {
        [Required]
        public DisciplineType Type { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        [Required]
        [StringLength(25)]
        public string Unit { get; set; }

        public override string ToString() => Name;
    }
}