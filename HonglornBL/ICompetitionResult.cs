using System;
using HonglornBL.Enums;

namespace HonglornBL
{
    interface ICompetitionResult
    {
        Guid Identifier { get; }
        ushort SprintScore { get; set; }
        ushort JumpScore { get; set; }
        ushort ThrowScore { get; set; }
        ushort MiddleDistanceScore { get; set; }
        ushort Rank { get; set; }
        Certificate Certificate { get; set; }
    }
}
