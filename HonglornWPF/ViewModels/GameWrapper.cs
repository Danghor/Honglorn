using System;

namespace HonglornWPF.ViewModels
{
    abstract class GameWrapper<TGameManager> : IGameWrapper
    {
        protected readonly TGameManager manager;

        protected GameWrapper(TGameManager manager)
        {
            this.manager = manager;
        }

        public abstract string Name { get; }
        public abstract DateTime Date { get; }

        public abstract ViewModel CreateViewModel();
    }
}