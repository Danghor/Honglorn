using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models.Entities
{
    public abstract class Game<TDiscipline> : IGame where TDiscipline : Discipline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public ICollection<GamePerformance<TDiscipline>> GamePerformances { get; set; }

        public abstract ICollection<IStudentResult> CalculateResults();
    }
}