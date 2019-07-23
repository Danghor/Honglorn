using System;

namespace HonglornBL.MasterData.StudentHandicap
{
    public class StudentHandicapNotFoundException : Exception
    {
        public StudentHandicapNotFoundException() { }

        public StudentHandicapNotFoundException(string message) : base(message) { }

        public StudentHandicapNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}