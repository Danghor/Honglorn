namespace HonglornBL.Calculation.Traditional
{
    sealed class RunningScoreCalculator : ScoreCalculator
    {
        readonly short distance;
        readonly float overhead;

        public RunningScoreCalculator(float seconds, short distance, float constantA, float constantC, float? overhead) : base(constantA, constantC, seconds)
        {
            this.distance = distance;
            this.overhead = overhead ?? 0;
        }

        protected override double CalculateRawScore()
        {
            return (distance / (Measurement + overhead) - ConstantA) / ConstantC;
        }
    }
}