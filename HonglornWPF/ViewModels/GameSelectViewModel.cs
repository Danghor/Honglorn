using HonglornBL;
using HonglornBL.Game;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HonglornWPF.ViewModels
{
    class GameSelectViewModel : ViewModel
    {
        public readonly ObservableCollection<IGameWrapper> Wrappers = new ObservableCollection<IGameWrapper>();

        public GameSelectViewModel()
        {
            GameCollection GameCollection = Honglorn.GetGames();

            AddManagers(GameCollection.TraditionalTrackAndFieldGames, m => new TraditionalTrackAndFieldGameWrapper(m));
            AddManagers(GameCollection.CompetitionTrackAndFieldGames, m => new CompetitionTrackAndFieldGameWrapper(m));
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