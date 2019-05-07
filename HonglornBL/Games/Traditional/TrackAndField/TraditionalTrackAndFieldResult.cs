using HonglornBL.Enums;

namespace HonglornBL.Games.Traditional.TrackAndField
{
    public class TraditionalTrackAndFieldResult
    {
        int TotalScore { get; }
        CertificateType CertificateType { get; }

        public TraditionalTrackAndFieldResult(int totalScore, CertificateType certificateType)
        {
            TotalScore = totalScore;
            CertificateType = certificateType;
        }
    }
}