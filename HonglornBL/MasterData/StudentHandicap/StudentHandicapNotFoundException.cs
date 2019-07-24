using System;
using System.Runtime.Serialization;

namespace HonglornBL.MasterData.StudentHandicap
{
    [Serializable]
    public class StudentHandicapNotFoundException : Exception
    {
        public StudentHandicapNotFoundException() { }

        public StudentHandicapNotFoundException(string message) : base(message) { }

        public StudentHandicapNotFoundException(string message, Exception innerException) : base(message, innerException) { }

        StudentHandicapNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}