using HonglornBL.Enums;
using HonglornBL.Models.Entities;

namespace HonglornBL.Games.Traditional.TrackAndField
{
    public class TraditionalTrackAndFieldResult
    {
        int TotalScore { get; }
        CertificateType CertificateType { get; }
        Student Student { get; }

        public TraditionalTrackAndFieldResult(int totalScore, CertificateType certificateType, Student student)
        {
            TotalScore = totalScore;
            CertificateType = certificateType;
            Student = student;
        }
    }
}