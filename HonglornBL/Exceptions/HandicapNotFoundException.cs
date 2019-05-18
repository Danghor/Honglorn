using System;
using System.Runtime.Serialization;

namespace HonglornBL
{
    [Serializable]
    internal class HandicapNotFoundException : Exception
    {
        public HandicapNotFoundException() { }

        public HandicapNotFoundException(string message) : base(message) { }

        public HandicapNotFoundException(string message, Exception innerException) : base(message, innerException) { }

        protected HandicapNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}