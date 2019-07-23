using System;

namespace HonglornBL.MasterData.StudentCourse
{
    public class StudentCourseNotFoundException : Exception
    {
        public StudentCourseNotFoundException() { }

        public StudentCourseNotFoundException(string message) : base(message) { }

        public StudentCourseNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}