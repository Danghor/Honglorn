using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using HonglornBL.Models.Entities;

namespace HonglornBL.Models.Entities
{
    public class GamePerformance<TDiscipline> where TDiscipline : Discipline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        public Student Student { get; set; }

        public ICollection<MeasuringPoint<TDiscipline>> MeasuringPoints { get; set; }
    }
}