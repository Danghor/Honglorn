using System;
using HonglornBL.APIInterfaces;

namespace HonglornBL.APIClasses {
  class StudentCompetitionData : IStudentCompetitionData {
    /// <summary>
    ///   Initializes a new instance of the <see cref="T:System.Object" /> class.
    /// </summary>
    internal StudentCompetitionData(Guid pKey, string surname, string forename, Prerequisites.Sex sex, float? sprint, float? jump, float? @throw, float? middleDistance) {
      PKey = pKey;
      Surname = surname;
      Forename = forename;
      Sex = sex;
      Sprint = sprint;
      Jump = jump;
      Throw = @throw;
      MiddleDistance = middleDistance;
    }

    public Guid PKey { get; }
    public string Surname { get; }
    public string Forename { get; }
    public Prerequisites.Sex Sex { get; }
    public float? Sprint { get; }
    public float? Jump { get; }
    public float? Throw { get; }
    public float? MiddleDistance { get; }
  }
}