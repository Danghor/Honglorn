using HonglornBL.Models.Entities;

namespace HonglornBL.Game.Competition.TrackAndField
{
    public class CompetitionTrackAndFieldResult
    {
        int TotalScore { get; }
        CertificateType CertificateType { get; }
        Student Student { get; }
    }
}