namespace HonglornBL
{
    class RawMeasurement
    {
        public float? Sprint { get; }

        public float? Jump { get; }

        public float? Throw { get; }

        public float? MiddleDistance { get; }

        internal RawMeasurement(float? sprint, float? jump, float? @throw, float? middleDistance)
        {
            Sprint = sprint;
            Jump = jump;
            Throw = @throw;
            MiddleDistance = middleDistance;
        }
    }
}
