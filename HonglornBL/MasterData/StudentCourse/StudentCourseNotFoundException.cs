using System;
using System.Runtime.Serialization;

namespace HonglornBL.MasterData.StudentCourse
{
    [Serializable]
    public sealed class StudentCourseNotFoundException : Exception
    {
        public StudentCourseNotFoundException() { }

        public StudentCourseNotFoundException(string message) : base(message) { }

        public StudentCourseNotFoundException(string message, Exception innerException) : base(message, innerException) { }

        StudentCourseNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}