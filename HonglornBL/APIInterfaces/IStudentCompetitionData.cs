using System;

namespace HonglornBL.APIInterfaces {
  public interface IStudentCompetitionData {
    Guid PKey { get; }
    string Surname { get; }
    string Forename { get; }
    Prerequisites.Sex Sex { get; }
    float? Sprint { get; }
    float? Jump { get; }
    float? Throw { get; }
    float? MiddleDistance { get; }
  }
}