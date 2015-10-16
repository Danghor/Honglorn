using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HonglornBL {
  public static class Prerequisites {
    static readonly HashSet<char> VALID_CLASSNAMES = new HashSet<char> {'5', '6', '7', '8', '9', 'E'};

    /// <summary>
    ///   Returns true iff the given character is a valid class name that can be used at all in the application.
    /// </summary>
    /// <param name="className">The class name to be validated.</param>
    /// <returns>True iff the given class name is a valid class name.</returns>
    /// <remarks>Valid classnames: 5, 6, 7, 8, 9, E</remarks>
    public static bool IsValidClassName(char className) {
      return VALID_CLASSNAMES.Contains(className);
    }

    /// <summary>
    ///   Returns true iff the given input year is a value between (including) 1900 and 2099.
    /// </summary>
    /// <param name="year">The year to be validated.</param>
    /// <returns>True iff the given year is a valid year.</returns>
    /// <remarks>Valid Years: 1900 - 2099</remarks>
    public static bool IsValidYear(uint year) {
      return (year >= 1900 && year <= 2099);
    }

    public static char GetClassName(string courseName) {
      char className;

      if (Regex.IsMatch(courseName, "0[5-9][A-Za-z]")) {
        className = Convert.ToChar(courseName[1]);
      } else if (Regex.IsMatch(courseName, "[5-9][A-Za-z]")) {
        className = Convert.ToChar(courseName[0]);
      } else if (Regex.IsMatch(courseName, "(E|e)(0[1-9]|[1-9][0-9])")) {
        className = 'E';
      } else {
        throw new ArgumentException($"Invalid course name: {courseName}. Automatic mapping to class name failed.");
      }

      return className;
    }

    public enum Discipline {
      Sprint,
      Jump,
      Throw,
      MiddleDistance
    }

    public enum GameType {
      Competition,
      Traditional,
      Unspecified
    }

    public enum Sex {
      Male,
      Female
    }
  }
}