using HonglornBL.Enums;
using HonglornBL.Models.Entities;

namespace HonglornBL.Calculation.Traditional
{
    class TraditionalCalculator
    {
        readonly TraditionalDiscipline discipline;
        readonly float? value;

        public TraditionalCalculator(TraditionalDiscipline discipline, float? value)
        {
            this.discipline = discipline;
            this.value = value;
        }

        /// <summary>
        ///     Calculates the score based on the given discipline and value.
        /// </summary>
        /// <returns>The score calculated by designated formulas.</returns>
        internal ushort CalculateScore()
        {
            IScoreCalculator calculator = GetCalculator();
            return calculator.CalculateScore();
        }

        IScoreCalculator GetCalculator()
        {
            IScoreCalculator calculator;

            if (value == null)
            {
                calculator = new ZeroScoreCalculator();
            }
            else if (discipline.Type == DisciplineType.Sprint || discipline.Type == DisciplineType.MiddleDistance)
            {
                calculator = new RunningScoreCalculator(value.Value, discipline.Distance.Value, discipline.ConstantA, discipline.ConstantC, discipline.Overhead);
            }
            else
            {
                calculator = new JumpThrowScoreCalculator(value.Value, discipline.ConstantA, discipline.ConstantC);
            }

            return calculator;
        }
    }
}