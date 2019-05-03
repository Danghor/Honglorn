using HonglornBL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HonglornBL
{
    public class MeasuringPoint<TDiscipline> : Entity where TDiscipline : Discipline
    {
        public TDiscipline Discipline
        {
            get => default;
            set
            {
            }
        }

        public double Measurement
        {
            get => default;
            set
            {
            }
        }
    }
}