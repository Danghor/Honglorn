using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HonglornBL.Game;

namespace HonglornWPF.ViewModels
{
    class GameSelectViewModel : ViewModel
    {
        public ObservableCollection<IGameWrapper> Wrappers { get; } = new ObservableCollection<IGameWrapper>();

        IGameWrapper currentWrapper;

        public IGameWrapper CurrentWrapper
        {
            get => currentWrapper;
            set => OnPropertyChanged(out currentWrapper, value);
        }

        ICommand selectGameCommand;

        public ICommand SelectGameCommand
        {
            get => selectGameCommand;
            set => OnPropertyChanged(out selectGameCommand, value);
        }

        public GameSelectViewModel(Action<IGameWrapper> selectGameAction)
        {
            GameCollection gameCollection = Honglorn.GetGames();

            AddManagers(gameCollection.TraditionalTrackAndFieldGames, m => new TraditionalTrackAndFieldGameWrapper(m));
            AddManagers(gameCollection.CompetitionTrackAndFieldGames, m => new CompetitionTrackAndFieldGameWrapper(m));

            SelectGameCommand = new RelayCommand(() => selectGameAction(CurrentWrapper));
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