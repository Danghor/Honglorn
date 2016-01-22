using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HonglornBL.Properties;

namespace HonglornBL {
  public static class Prerequisites {
    internal static string GetClassName(string courseName) {
      string className;

      if (Regex.IsMatch(courseName, "0[5-9][A-Za-z]")) {
        className = courseName[1].ToString();
      } else if (Regex.IsMatch(courseName, "[5-9][A-Za-z]")) {
        className = courseName[0].ToString();
      } else if (Regex.IsMatch(courseName, "(E|e)(0[1-9]|[1-9][0-9])")) {
        className = "E";
      } else {
        throw new ArgumentException($"Invalid course name: {courseName}. Automatic mapping to class name failed.");
      }

      return className;
    }

    /// <summary>
    ///   Calculates the fraction of x and y in percentage.
    /// </summary>
    /// <param name="x">The numerator.</param>
    /// <param name="y">The denominator.</param>
    /// <returns>The rounded fraction in percentage.</returns>
    internal static int PercentageValue(int x, int y) => (int) Math.Round(100d * x / y);

    #region Validation
    static readonly HashSet<char> VALID_CLASSNAMES = new HashSet<char> { '5', '6', '7', '8', '9', 'E' };

    /// <summary>
    ///   Returns true iff the given character is a valid class name that can be used at all in the application.
    /// </summary>
    /// <param name="className">The class name to be validated.</param>
    /// <returns>True iff the given class name is a valid class name.</returns>
    /// <remarks>Valid classnames: 5, 6, 7, 8, 9, E</remarks>
    internal static bool IsValidClassName(char className) => VALID_CLASSNAMES.Contains(className);

    /// <summary>
    ///   Returns true iff the given input year is a value between (including) 1900 and 2099.
    /// </summary>
    /// <param name="year">The year to be validated.</param>
    /// <returns>True iff the given year is a valid year.</returns>
    internal static bool IsValidYear(short year) {
      return (year >= Settings.Default.MinValidYear && year <= Settings.Default.MaxValidYear);
    }
    #endregion

    #region Enums
    public enum Certificate {
      Honorary = 0,
      Victory = 1,
      Participation = 2
    }

    public enum DisciplineType {
      Sprint = 0,
      Jump = 1,
      Throw = 2,
      MiddleDistance = 3
    }

    public enum GameType {
      Traditional = 0,
      Competition = 1
    }

    public enum Measurement {
      Manual = 0,
      Electronic = 1
    }

    public enum Sex {
      Male = 0,
      Female = 1
    }
    #endregion
  }
}