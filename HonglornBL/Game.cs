using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HonglornBL.Models.Entities;

namespace HonglornBL
{
    public abstract class Game<TDiscipline> : Entity, IGame where TDiscipline : Discipline
    {

        public ICollection<GamePerformance<TDiscipline>> GamePerformances
        {
            get => default;
            set
            {
            }
        }

        public abstract ICollection<IStudentResult> CalculateResults();
    }
}