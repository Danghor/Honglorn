using System;
using System.ComponentModel;
using HonglornBL.Models.Entities;
using static HonglornBL.Prerequisites;

namespace HonglornBL
{
    static class TraditionalCalculator
    {
        /// <summary>
        ///     Calculates the score based on the given discipline and value.
        /// </summary>
        /// <param name="discipline">The traditional discipline that was performed.</param>
        /// <param name="value">The raw value of the performance achieved.</param>
        /// <returns>The score calculated by designated formulas.</returns>
        internal static ushort CalculateScore(TraditionalDiscipline discipline, float? value)
        {
            //discipline null
            if (discipline == null)
            {
                throw new ArgumentNullException(nameof(discipline));
            }

            //Constant C is 0
            if (Math.Abs(discipline.ConstantC) < float.Epsilon)
            {
                throw new ArgumentOutOfRangeException(nameof(discipline.ConstantC), "Invalid value for constant would result in a division by 0.");
            }

            ushort score;

            float cleanedValue = value ?? 0;

            switch (discipline.Type)
            {
                case DisciplineType.Sprint:
                    float overhead = discipline.Measurement == Measurement.Manual ? discipline.Overhead ?? 0 : 0;
                    score = CalculateRunningScore(cleanedValue, CleanedDistance(discipline.Distance), discipline.ConstantA, discipline.ConstantC, overhead);
                    break;
                case DisciplineType.Jump:
                case DisciplineType.Throw:
                    score = CalculateJumpThrowScore(cleanedValue, discipline.ConstantA, discipline.ConstantC);
                    break;
                case DisciplineType.MiddleDistance:
                    score = CalculateRunningScore(cleanedValue, CleanedDistance(discipline.Distance), discipline.ConstantA, discipline.ConstantC);
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(discipline.Type), (int) discipline.Type, typeof(DisciplineType));
            }

            return score;
        }

        static ushort CleanedDistance(short? rawDistance)
        {
            if (rawDistance == null)
            {
                throw new ArgumentNullException(nameof(rawDistance));
            }

            if (rawDistance <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rawDistance));
            }

            return (ushort) rawDistance;
        }

        static ushort CalculateRunningScore(float seconds, ushort distance, float constantA, float constantC, float overhead = 0)
        {
            return CleanScore((distance / (seconds + overhead) - constantA) / constantC);
        }

        static ushort CalculateJumpThrowScore(float meters, float constantA, float constantC)
        {
            return CleanScore((Math.Sqrt(meters) - constantA) / constantC);
        }

        /// <summary>
        /// Sets the score to 0 if negative and cuts off all decimal places.
        /// </summary>
        /// <param name="rawScore">The score that has initially been calculated, without considering the boundaries.</param>
        /// <returns>The score ready to be shown to the user.</returns>
        static ushort CleanScore(double rawScore)
        {
            return (ushort) Math.Max(0, Math.Floor(rawScore));
        }
    }
}