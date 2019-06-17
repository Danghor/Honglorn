using System;

namespace HonglornBL.MasterData.Course
{
    public interface ICourseModel
    {
        string Name { get; }
        Guid ClassPKey { get; }
    }
}