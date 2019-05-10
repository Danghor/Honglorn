using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HonglornBL.Models.Entities;

namespace HonglornBL
{
    public abstract class MeasuringPoint<TDiscipline> where TDiscipline : Discipline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        public TDiscipline Discipline { get; set; }

        public double Measurement { get; set; }
    }
}