using HonglornBL.Enums;
using HonglornBL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HonglornBL.Games.Competition.TrackAndField
{
    public class CompetitionTrackAndFieldResult
    {
        int TotalScore { get; }
        CertificateType CertificateType { get; }
        Student Student { get; }
    }
}