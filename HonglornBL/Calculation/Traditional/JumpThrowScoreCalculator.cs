using System;

namespace HonglornBL.Calculation.Traditional
{
    sealed class JumpThrowScoreCalculator : ScoreCalculator
    {
        public JumpThrowScoreCalculator(float meters, float constantA, float constantC) : base(constantA, constantC, meters) { }

        protected override double CalculateRawScore()
        {
            return (Math.Sqrt(Measurement) - ConstantA) / ConstantC;
        }
    }
}