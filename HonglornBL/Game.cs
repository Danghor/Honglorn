﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HonglornBL.Models.Entities;

namespace HonglornBL
{
    public abstract class Game<TDiscipline> where TDiscipline : Discipline
    {

        public ICollection<Foo> Foos
        {
            get => default;
            set
            {
            }
        }

        public abstract ICollection<IResult> CalculateResults();
    }
}