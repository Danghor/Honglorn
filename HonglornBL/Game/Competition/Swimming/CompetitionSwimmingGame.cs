using HonglornBL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HonglornBL
{
    public class CompetitionSwimmingGame : Game<CompetitionSwimmingDiscipline, CompetitionSwimmingResult>
    {
        public override ICollection<CompetitionSwimmingResult> CalculateResults() => throw new NotImplementedException();
    }
}