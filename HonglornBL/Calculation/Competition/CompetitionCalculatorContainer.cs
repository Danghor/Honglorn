using System;
using System.Diagnostics;
using HonglornBL.Enums;

namespace HonglornBL.Calculation.Competition
{
    [DebuggerDisplay("({SprintValue},{SprintScore})({JumpValue},{JumpScore})({ThrowValue},{ThrowScore})({MiddleDistanceValue},{MiddleDistanceScore}) {Rank} {Certificate}")]
    class CompetitionCalculatorContainer : ICompetitionResult
    {
        public Guid Identifier { get; set; }

        public float? SprintValue { get; set; }
        public float? JumpValue { get; set; }
        public float? ThrowValue { get; set; }
        public float? MiddleDistanceValue { get; set; }

        public ushort SprintScore { get; set; }
        public ushort JumpScore { get; set; }
        public ushort ThrowScore { get; set; }
        public ushort MiddleDistanceScore { get; set; }

        public ushort Rank { get; set; }

        public CertificateType Certificate { get; set; }

        internal CompetitionCalculatorContainer(Guid identifier, float? sprintValue, float? jumpValue, float? throwValue, float? middleDistanceValue)
        {
            Identifier = identifier;
            SprintValue = sprintValue;
            JumpValue = jumpValue;
            ThrowValue = throwValue;
            MiddleDistanceValue = middleDistanceValue;
        }

        internal ushort TotalScore => (ushort) (SprintScore + JumpScore + ThrowScore + MiddleDistanceScore);
    }
}