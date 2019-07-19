using System;

namespace HonglornBL.Game
{
    public interface IGameModel
    {
        string Name { get; }
        DateTime Date { get; }
    }
}