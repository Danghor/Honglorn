using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HonglornBL.Models.Entities;

namespace HonglornBL
{
    public class TraditionalTrackAndFieldGame : Game<TraditionalTrackAndFieldDiscipline>
    {
        public override ICollection<IStudentResult> CalculateResults() => throw new NotImplementedException();
    }
}