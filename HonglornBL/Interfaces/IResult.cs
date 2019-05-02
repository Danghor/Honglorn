using HonglornBL.Enums;
using HonglornBL.Models.Entities;

namespace HonglornBL
{
    public interface IResult
    {
        ushort TotalScore { get; }
        Certificate Certificate { get; }
        GamePerformance<Discipline> GamePerformance { get; set; }
    }
}