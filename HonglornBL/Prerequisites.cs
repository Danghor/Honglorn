using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HonglornBL {
  public static class Prerequisites {
    public enum Discipline {
      Sprint,
      Jump,
      Throw,
      MiddleDistance
    }

    public enum GameType {
      Competition,
      Traditional,
      Unknown
    }

    public enum Sex {
      Male,
      Female
    }

    public const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    readonly static HashSet<char> VALID_CLASSNAMES = new HashSet<char> {'5', '6', '7', '8', '9', 'E'};

    /// <summary>
    ///   Returns true iff the given input year is a value between (including) 1900 and 2099.
    /// </summary>
    /// <param name="year">The year to be validated.</param>
    /// <returns>True iff the given year is a valid year.</returns>
    /// <remarks>Valid Years: 1900 - 2099</remarks>
    public static bool IsValidYear(int year) {
      return Regex.IsMatch(year.ToString(), "(19|20)[0-9]{2}");
    }

    /// <summary>
    ///   Returns true iff the given character is a valid class name that can be used at all in the application.
    /// </summary>
    /// <param name="className">The class name to be validated.</param>
    /// <returns>True iff the given class name is a valid class name.</returns>
    /// <remarks>Valid classnames: 5, 6, 7, 8, 9, E</remarks>
    public static bool IsValidClassName(char className) {
      return VALID_CLASSNAMES.Contains(className);
    }
  }
}