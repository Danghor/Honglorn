using System;
using static HonglornBL.Prerequisites;

namespace HonglornBL {
  class Student {
    internal string Surname { get; }
    internal string Forename { get; }
    internal uint YearOfBirth { get; }
    internal Sex Sex { get; }
    internal string CourseName { get; }

    /// <summary>
    ///   Initializes a new instance of the <see cref="T:System.Object" /> class.
    /// </summary>
    internal Student(string surname, string forename, uint yearOfBirth, Sex sex, string courseName) {
      if (IsValidYear(yearOfBirth)) {
        YearOfBirth = yearOfBirth;
      } else {
        throw new ArgumentOutOfRangeException($"{yearOfBirth} is not a valid year.");
      }

      Surname = surname;
      Forename = forename;
      YearOfBirth = yearOfBirth;
      Sex = sex;
      CourseName = courseName;
    }
  }
}