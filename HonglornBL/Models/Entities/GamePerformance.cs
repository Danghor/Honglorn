using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HonglornBL.Models.Entities
{
    public abstract class GamePerformance<TMeasuringPoint, TDiscipline> where TMeasuringPoint : MeasuringPoint<TDiscipline> where TDiscipline : Discipline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        public Student Student { get; set; }

        public ICollection<TMeasuringPoint> MeasuringPoints { get; set; }
    }
}