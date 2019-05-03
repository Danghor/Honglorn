using HonglornBL.Enums;

namespace HonglornBL
{
    public class Result : IStudentResult
    {
        public string Forename { get; }
        public string Surname { get; }

        public ushort SprintScore { get; }
        public ushort JumpScore { get; }
        public ushort ThrowScore { get; }
        public ushort MiddleDistanceScore { get; }

        public ushort Rank { get; }
        public ushort TotalScore { get; }
        public CertificateType CertificateType { get; }

        internal Result(string forename, string surname, ushort sprintScore, ushort jumpScore, ushort throwScore, ushort middleDistanceScore, ushort rank, ushort totalScore, CertificateType certificate)
        {
            Forename = forename;
            Surname = surname;
            SprintScore = sprintScore;
            JumpScore = jumpScore;
            ThrowScore = throwScore;
            MiddleDistanceScore = middleDistanceScore;
            Rank = rank;
            TotalScore = totalScore;
            CertificateType = certificate;
        }
    }
}