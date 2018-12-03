using HonglornBL.Enums;

namespace HonglornBL
{
    public interface IResult
    {
        string Forename { get; }
        string Surname { get; }

        ushort SprintScore { get; }
        ushort JumpScore { get; }
        ushort ThrowScore { get; }
        ushort MiddleDistanceScore { get; }

        ushort Rank { get; }
        ushort TotalScore { get; }
        Certificate Certificate { get; }
    }
}