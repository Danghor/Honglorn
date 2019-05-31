using HonglornBL.Models.Entities;
using System;
using System.Collections.Generic;

namespace HonglornBL
{
    public class TraditionalSwimmingGame : Game<TraditionalSwimmingDiscipline, TraditionalSwimmingResult>
    {
        public override ICollection<TraditionalSwimmingResult> CalculateResults() => throw new NotImplementedException();
    }
}