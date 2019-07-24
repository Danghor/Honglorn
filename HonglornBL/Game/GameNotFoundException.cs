using System;
using System.Runtime.Serialization;

namespace HonglornBL.Game
{
    [Serializable]
    public sealed class GameNotFoundException : Exception
    {
        public GameNotFoundException() { }

        public GameNotFoundException(string message) : base(message) { }

        public GameNotFoundException(string message, Exception innerException) : base(message, innerException) { }

        GameNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}