using static HonglornBL.Prerequisites;

namespace HonglornBL
{
    public interface IResult
    {
        string Forename { get; }
        string Surname { get; }
        ushort Score { get; }
        Certificate Certificate { get; }
    }
}