using System;

namespace HonglornBL.Game
{
    public interface IGameManager
    {
        string Name { get; }
        DateTime Date { get; }
    }
}