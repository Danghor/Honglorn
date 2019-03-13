using System;

namespace HonglornBL
{
    class RawMeasurement
    {
        internal Guid Id { get; }
        internal float? Sprint { get; }
        internal float? Jump { get; }
        internal float? Throw { get; }
        internal float? MiddleDistance { get; }

        internal RawMeasurement(Guid id, float? sprint, float? jump, float? @throw, float? middleDistance)
        {
            Id = id;
            Sprint = sprint;
            Jump = jump;
            Throw = @throw;
            MiddleDistance = middleDistance;
        }
    }
}