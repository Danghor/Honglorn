using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HonglornBL.Models.Entities;

namespace HonglornBL.Models.Entities
{
    public class GamePerformance<TDiscipline> : Entity where TDiscipline : Discipline
    {
        public Student Student { get; set; }

        public ICollection<MeasuringPoint<TDiscipline>> MeasuringPoints { get; set; }
    }
}