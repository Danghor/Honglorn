using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models.Entities
{
    public abstract class GamePerformance<TMeasuringPoint, TDiscipline, TGamePerformance> : IEntity where TMeasuringPoint : MeasuringPoint<TDiscipline> where TDiscipline : Discipline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        [Required]
        public Guid StudentPKey { get; set; }

        [ForeignKey(nameof(StudentPKey))]
        public virtual Student Student { get; set; }

        [Required]
        public Guid GamePKey { get; set; }

        [ForeignKey(nameof(GamePKey))]
        public virtual Game<TGamePerformance> Game { get; set; }

        public ICollection<TMeasuringPoint> MeasuringPoints { get; set; }
    }
}