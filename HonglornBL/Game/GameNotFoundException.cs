using System;

namespace HonglornBL
{
    public class GameNotFoundException : Exception
    {
        public GameNotFoundException(string message) : base(message) { }

        public GameNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}