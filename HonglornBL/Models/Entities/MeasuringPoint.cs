using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HonglornBL.Models.Entities;

namespace HonglornBL
{
    // Todo: Check whether it makes sense to always save a discipline here, since for a competition, the discipline would rather belong to the evaluationgroup
    public abstract class MeasuringPoint<TDiscipline> : IEntity where TDiscipline : Discipline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        public TDiscipline Discipline { get; set; }

        public double Measurement { get; set; }
    }
}