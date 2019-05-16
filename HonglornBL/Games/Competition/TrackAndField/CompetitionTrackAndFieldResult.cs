using HonglornBL.Enums;
using HonglornBL.Models.Entities;

namespace HonglornBL.Games.Competition.TrackAndField
{
    public class CompetitionTrackAndFieldResult
    {
        int TotalScore { get; }
        CertificateType CertificateType { get; }
        Student Student { get; }
    }
}