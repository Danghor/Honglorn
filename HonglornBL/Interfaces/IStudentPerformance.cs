using System;

namespace HonglornBL
{
    public interface IStudentPerformance
    {
        Guid StudentPKey { get; }
        string Forename { get; }
        string Surname { get; }
        float? Sprint { get; }
        float? Jump { get; }
        float? Throw { get; }
        float? MiddleDistance { get; }
    }
}