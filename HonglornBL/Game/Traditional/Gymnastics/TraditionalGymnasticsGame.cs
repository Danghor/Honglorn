using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HonglornBL.Models.Entities;

namespace HonglornBL
{
    public class TraditionalGymnasticsGame : Game<TraditionalGymnasticsDiscipline, TraditionalGymnasticsResult>
    {
        public override ICollection<TraditionalGymnasticsResult> CalculateResults() => throw new NotImplementedException();
    }
}