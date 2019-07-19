using HonglornBL.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models.Entities
{
    public abstract class Game<TGamePerformance> : IEntity<IGameModel>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual ICollection<TGamePerformance> GamePerformances { get; set; } = new HashSet<TGamePerformance>();

        protected Game() { }

        protected Game(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }

        public void AdoptValues(IGameModel model)
        {
            Name = model.Name;
            Date = model.Date;
        }
    }
}