using static HonglornBL.Prerequisites;

namespace HonglornBL {
  class ImportStudent {
    internal string Surname { get; }
    internal string Forename { get; }
    internal string CourseName { get; }
    internal Sex Sex { get; }
    internal short YearOfBirth { get; }

    /// <summary>
    ///   Initializes a new instance of the <see cref="T:System.Object" /> class.
    /// </summary>
    internal ImportStudent(string surname, string forename, string courseName, Sex sex, short yearOfBirth) {
      Surname = surname;
      Forename = forename;
      CourseName = courseName;
      Sex = sex;
      YearOfBirth = yearOfBirth;
    }
  }
}