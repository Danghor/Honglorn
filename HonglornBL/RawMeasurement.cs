namespace HonglornBL
{
    class RawMeasurement
    {
        internal float? Sprint { get; }

        internal float? Jump { get; }

        internal float? Throw { get; }

        internal float? MiddleDistance { get; }

        internal RawMeasurement(float? sprint, float? jump, float? @throw, float? middleDistance)
        {
            Sprint = sprint;
            Jump = jump;
            Throw = @throw;
            MiddleDistance = middleDistance;
        }
    }
}
