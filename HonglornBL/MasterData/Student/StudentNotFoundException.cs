using System;
using System.Runtime.Serialization;

namespace HonglornBL.MasterData.Student
{
    [Serializable]
    public sealed class StudentNotFoundException : Exception
    {
        public StudentNotFoundException() { }

        public StudentNotFoundException(string message) : base(message) { }

        public StudentNotFoundException(string message, Exception innerException) : base(message, innerException) { }

        StudentNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}