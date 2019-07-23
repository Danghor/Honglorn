using System;

namespace HonglornBL.MasterData.Student
{
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException() { }

        public StudentNotFoundException(string message) : base(message) { }

        public StudentNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}