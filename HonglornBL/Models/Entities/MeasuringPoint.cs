using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models.Entities
{
    // Todo: Check whether it makes sense to always save a discipline here, since for a competition, the discipline would rather belong to the evaluationgroup
    public abstract class MeasuringPoint<TDiscipline> : IEntity<IMeasuringPoint> where TDiscipline : Discipline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        [Required]
        public Guid DisciplinePKey { get; set; }

        [ForeignKey(nameof(DisciplinePKey))]
        public virtual TDiscipline Discipline { get; set; }

        public double Measurement { get; set; }

        public void AdoptValues(IMeasuringPoint model)
        {
            DisciplinePKey = model.DisciplinePKey;
            Measurement = model.Measurement;
        }
    }
}