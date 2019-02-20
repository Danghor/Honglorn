using System;

namespace HonglornBL.Calculation.Traditional
{
    abstract class ScoreCalculator : IScoreCalculator
    {
        protected readonly float ConstantA;
        protected readonly float ConstantC;
        protected readonly float Measurement;

        protected ScoreCalculator(float constantA, float constantC, float measurement)
        {
            ConstantA = constantA;
            ConstantC = constantC;
            Measurement = measurement;
        }

        /// <summary>
        /// Sets the score to 0 if negative and cuts off all decimal places.
        /// </summary>
        /// <returns>The score ready to be shown to the user.</returns>
        public ushort CalculateScore()
        {
            double rawScore = CalculateRawScore();
            return CleanScore(rawScore);
        }

        protected abstract double CalculateRawScore();

        static ushort CleanScore(double rawScore)
        {
            return (ushort)Math.Max(0, Math.Floor(rawScore));
        }
    }
}