using System;
using System.Runtime.Serialization;

namespace HonglornBL.MasterData.Course
{
    [Serializable]
    public sealed class CourseNotFoundException : Exception
    {
        internal CourseNotFoundException() { }

        internal CourseNotFoundException(string message) : base(message) { }

        internal CourseNotFoundException(string message, Exception innerException) : base(message, innerException) { }

        CourseNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}