using HonglornBL.Properties;
using System;

namespace HonglornBL
{
    static class Prerequisites
    {
        /// <summary>
        ///     Calculates the fraction of x and y in percentage.
        /// </summary>
        /// <param name="x">The numerator.</param>
        /// <param name="y">The denominator.</param>
        /// <returns>The rounded fraction in percentage.</returns>
        internal static byte PercentageValue(int x, int y) => (byte)Math.Round(100d * x / y);

        /// <summary>
        ///     Returns true iff the given input year is valid based on the lower and upper bounds defined in the settings.
        /// </summary>
        /// <param name="year">The year to be validated.</param>
        /// <returns>True iff the given year is a valid year.</returns>
        internal static bool IsValidYear(short year)
        {
            return year >= Settings.Default.MinValidYear && year <= Settings.Default.MaxValidYear;
        }
    }
}