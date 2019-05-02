using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HonglornBL.Models.Entities;

namespace HonglornBL
{
    public class GamePerformance<TDiscipline> where TDiscipline : Discipline
    {
        public Student Student
        {
            get => default;
            set
            {
            }
        }

        public ICollection<MeasuringPoint<TDiscipline>> MeasuringPoints
        {
            get => default;
            set
            {
            }
        }
    }
}