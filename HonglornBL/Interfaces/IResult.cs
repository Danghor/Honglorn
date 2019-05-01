using HonglornBL.Enums;

namespace HonglornBL
{
    public interface IResult
    {
        string Surname { get; }

        ushort SprintScore { get; }
        ushort ThrowScore { get; }

        ushort Rank { get; }
        ushort TotalScore { get; }
        Certificate Certificate { get; }
    }
}