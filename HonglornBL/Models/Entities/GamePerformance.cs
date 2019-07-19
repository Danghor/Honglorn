using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models.Entities
{
    public abstract class GamePerformance<TMeasuringPoint, TDiscipline, TGamePerformance> : IEntity
        where TMeasuringPoint : MeasuringPoint<TDiscipline>
        where TDiscipline : Discipline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        [Required]
        [Index("UniqueStudentGame", 1, IsUnique = true)]
        public Guid StudentPKey { get; set; }

        [ForeignKey(nameof(StudentPKey))]
        public virtual Student Student { get; set; }

        [Required]
        [Index("UniqueStudentGame", 2, IsUnique = true)]
        public Guid GamePKey { get; set; }

        [ForeignKey(nameof(GamePKey))]
        public virtual Game<TGamePerformance> Game { get; set; }

        public virtual ICollection<TMeasuringPoint> MeasuringPoints { get; set; }
    }
}