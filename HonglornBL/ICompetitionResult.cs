using System;

namespace HonglornBL
{
    interface ICompetitionResult
    {
        Guid Identifier { get; }
        ushort SprintScore { get; set; }
        ushort JumpScore { get; set; }
        ushort ThrowScore { get; set; }
        ushort MiddleDistanceScore { get; set; }
    }
}
