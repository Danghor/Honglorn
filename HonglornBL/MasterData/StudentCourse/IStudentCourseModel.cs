using System;

namespace HonglornBL.MasterData.StudentCourse
{
    public interface IStudentCourseModel
    {
        Guid StudentPKey { get; }
        Guid CoursePKey { get; }
        DateTime DateStart { get; }
        DateTime DateEnd { get; }
    }
}