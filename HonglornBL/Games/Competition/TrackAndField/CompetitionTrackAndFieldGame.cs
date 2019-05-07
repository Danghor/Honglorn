using HonglornBL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HonglornBL.Games.Competition.TrackAndField;

namespace HonglornBL
{
    public class CompetitionTrackAndFieldGame : Game<CompetitionTrackAndFieldDiscipline, CompetitionTrackAndFieldResult>
    {
        public override ICollection<CompetitionTrackAndFieldResult> CalculateResults() => throw new NotImplementedException();
    }
}