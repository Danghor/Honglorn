using System;

namespace HonglornBL.Game
{
    public class GameNotFoundException : Exception
    {
        public GameNotFoundException() { }

        public GameNotFoundException(string message) : base(message) { }

        public GameNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}