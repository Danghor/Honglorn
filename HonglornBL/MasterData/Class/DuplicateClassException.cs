using System;
using System.Runtime.Serialization;

namespace HonglornBL.MasterData.Class
{
    [Serializable]
    public sealed class DuplicateClassException : Exception
    {
        internal DuplicateClassException() { }

        internal DuplicateClassException(string message) : base(message) { }

        internal DuplicateClassException(string message, Exception innerException) : base(message, innerException) { }

        DuplicateClassException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}