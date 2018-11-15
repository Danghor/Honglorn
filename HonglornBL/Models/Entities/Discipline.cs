using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HonglornBL.Enums;
using HonglornBL.Interfaces;

namespace HonglornBL.Models.Entities
{
    public abstract class Discipline : IDiscipline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

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