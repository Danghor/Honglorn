using System;

namespace HonglornBL.Exceptions
{
    public sealed class DuplicateClassException : Exception
    {
        internal DuplicateClassException() { }

        internal DuplicateClassException(string message) : base(message) { }

        internal DuplicateClassException(string message, Exception innerException) : base(message, innerException) { }
    }
}