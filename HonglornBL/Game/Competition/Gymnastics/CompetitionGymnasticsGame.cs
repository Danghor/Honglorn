using HonglornBL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HonglornBL
{
    public class CompetitionGymnasticsGame : Game<CompetitionGymnasticsDiscipline, CompetitionGymnasticsResult>
    {
        public override ICollection<CompetitionGymnasticsResult> CalculateResults() => throw new NotImplementedException();
    }
}