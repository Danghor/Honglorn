using System;
using System.Runtime.Serialization;

namespace HonglornBL.MasterData.Class
{
    [Serializable]
    public sealed class ClassNotFoundException : Exception
    {
        public ClassNotFoundException() { }

        public ClassNotFoundException(string message) : base(message) { }

        public ClassNotFoundException(string message, Exception innerException) : base(message, innerException) { }

        ClassNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}