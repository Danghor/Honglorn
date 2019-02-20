namespace HonglornBL.Calculation.Traditional
{
    sealed class ZeroScoreCalculator : IScoreCalculator
    {
        public ushort CalculateScore() => 0;
    }
}