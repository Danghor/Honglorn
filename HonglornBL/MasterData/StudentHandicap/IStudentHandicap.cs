using System;

namespace HonglornBL.MasterData.StudentHandicap
{
    public interface IStudentHandicapModel
    {
        Guid StudentPKey { get; }
        Guid HandicapPKey { get; }
        DateTime DateStart { get; }
        DateTime? DateEnd { get; }
    }
}