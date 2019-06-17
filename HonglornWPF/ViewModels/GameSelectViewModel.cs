using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HonglornBL.Game;

namespace HonglornWPF.ViewModels
{
    class GameSelectViewModel : ViewModel
    {
        public ObservableCollection<IGameWrapper> Wrappers { get; } = new ObservableCollection<IGameWrapper>();

        public GameSelectViewModel()
        {
            GameCollection gameCollection = Honglorn.GetGames();

            AddManagers(gameCollection.TraditionalTrackAndFieldGames, m => new TraditionalTrackAndFieldGameWrapper(m));
            AddManagers(gameCollection.CompetitionTrackAndFieldGames, m => new CompetitionTrackAndFieldGameWrapper(m));
        }

        void AddManagers<TGameManager, TWrapper>(IEnumerable<TGameManager> gameManagers, Func<TGameManager, TWrapper> createWrapper)
            where TWrapper : IGameWrapper
        {
            foreach (var manager in gameManagers)
            {
                Wrappers.Add(createWrapper(manager));
            }
        }
    }
}