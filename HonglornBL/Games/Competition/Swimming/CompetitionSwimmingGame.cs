﻿using HonglornBL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HonglornBL
{
    public class CompetitionSwimmingGame : Game<Discipline>
    {
        public override ICollection<IStudentResult> CalculateResults()
        {
            throw new NotImplementedException();
        }
    }
}