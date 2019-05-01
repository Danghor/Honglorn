using HonglornBL.Enums;

namespace HonglornBL
{
    public interface IResult
    {

        ushort Rank { get; }
        ushort TotalScore { get; }
        Certificate Certificate { get; }
    }
}