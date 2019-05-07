using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HonglornBL.Models.Framework;

namespace HonglornBL.Models.Entities
{
    public abstract class Game<TDiscipline, TResult> : IGame<TResult> where TDiscipline : Discipline
    {
        internal HonglornDbFactory contextFactory;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual ICollection<GamePerformance<TDiscipline>> GamePerformances { get; set; } = new HashSet<GamePerformance<TDiscipline>>();

        public abstract ICollection<TResult> CalculateResults();
    }
}