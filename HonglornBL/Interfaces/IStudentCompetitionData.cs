using System;

namespace HonglornBL.Interfaces {
  public interface IStudentCompetitionData {
    Guid PKey { get; set; }
    string Surname { get; set; }
    string Forename { get; set; }
    Prerequisites.Sex Sex { get; set; }
    float? Sprint { get; set; }
    float? Jump { get; set; }
    float? Throw { get; set; }
    float? MiddleDistance { get; set; }
  }
}