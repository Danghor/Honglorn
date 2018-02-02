using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HonglornBL
{
    class CompetitionResult
    {
        Guid Identifier { get; }
        internal ushort SprintScore { get; set; } = 0;
        internal ushort JumpScore { get; set; } = 0;
        internal ushort ThrowScore { get; set; } = 0;
        internal ushort MiddleDistanceScore { get; set; } = 0;

        internal CompetitionResult(Guid identifier)
        {
            Identifier = identifier;
        }
    }
}
