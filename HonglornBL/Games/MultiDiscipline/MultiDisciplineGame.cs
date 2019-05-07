using HonglornBL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HonglornBL
{
    public class MultiDisciplineGame : Game<MultiDisciplineGameDiscipline, MultiDisciplineGameResult>
    {
        public override ICollection<MultiDisciplineGameResult> CalculateResults() => throw new NotImplementedException();
    }
}