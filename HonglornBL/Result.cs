using HonglornBL.Enums;

namespace HonglornBL
{
    public class Result : IResult
    {
        public string Forename { get; }
        public string Surname { get; }

        public ushort SprintScore { get; }
        public ushort JumpScore { get; }
        public ushort ThrowScore { get; }
        public ushort MiddleDistanceScore { get; }

        public ushort Score { get; }
        public Certificate Certificate { get; }

        internal Result(string forename, string surname, ushort sprintScore, ushort jumpScore, ushort throwScore, ushort middleDistanceScore, ushort score, Certificate certificate)
        {
            Forename = forename;
            Surname = surname;
            SprintScore = sprintScore;
            JumpScore = jumpScore;
            ThrowScore = throwScore;
            MiddleDistanceScore = middleDistanceScore;
            Score = score;
            Certificate = certificate;
        }
    }
}
