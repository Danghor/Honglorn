using System;
using HonglornBL.Interfaces;

namespace HonglornBL.APIClasses {
  public class StudentCompetitionData : IStudentCompetitionData {
    public Guid PKey { get; set; }
    public string Surname { get; set; }
    public string Forename { get; set; }
    public Prerequisites.Sex Sex { get; set; }
    public float? Sprint { get; set; }
    public float? Jump { get; set; }
    public float? Throw { get; set; }
    public float? MiddleDistance { get; set; }
  }
}