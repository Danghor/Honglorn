using System;

namespace HonglornBL.MasterData.Class
{
    public sealed class DuplicateClassException : Exception
    {
        internal DuplicateClassException() { }

        internal DuplicateClassException(string message) : base(message) { }

        internal DuplicateClassException(string message, Exception innerException) : base(message, innerException) { }
    }
}