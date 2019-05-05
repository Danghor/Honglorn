using HonglornBL.Models.Entities;
using System;
using System.Collections.Generic;

namespace HonglornBL
{
    public abstract class Game<TDiscipline> : Entity, IGame where TDiscipline : Discipline
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public ICollection<GamePerformance<TDiscipline>> GamePerformances { get; set; }

        public abstract ICollection<IStudentResult> CalculateResults();
    }
}