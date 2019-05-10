using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HonglornBL.Models.Framework;

namespace HonglornBL.Models.Entities
{
    public abstract class Game<TResult, TGamePerformance> : IGame<TResult>
    {
        internal HonglornDbFactory contextFactory;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual ICollection<TGamePerformance> GamePerformances { get; set; } = new HashSet<TGamePerformance>();

        public abstract ICollection<TResult> CalculateResults();
    }
}