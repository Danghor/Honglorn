using System;
using System.Data;
using HonglornBL.Enums;
using HonglornBL.Models.Entities;

namespace HonglornBL.Calculation.Traditional
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
            ushort score;

            if (value == null)
            {
                score = 0;
            }
            else if (discipline.Type == DisciplineType.Sprint || discipline.Type == DisciplineType.MiddleDistance)
            {
                try
                {
                    score = CalculateRunningScore(value.Value, discipline.Distance.Value, discipline.ConstantA, discipline.ConstantC, discipline.Overhead ?? 0);
                }
                catch (InvalidOperationException ex)
                {
                    throw new DataException($"Traditional discipline {discipline} is incorrectly configured.", ex);
                }
            }
            else
            {
                score = CalculateJumpThrowScore(value.Value, discipline.ConstantA, discipline.ConstantC);
            }

            return score;
        }

        static ushort CalculateRunningScore(float seconds, short distance, float constantA, float constantC, float overhead = 0)
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