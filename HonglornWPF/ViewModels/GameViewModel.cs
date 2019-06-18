using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    class GameViewModel : ViewModel
    {
        ICommand gameSelectCommand;

        public ICommand GameSelectCommand
        {
            get => gameSelectCommand;
            set => OnPropertyChanged(out gameSelectCommand, value);
        }

        ViewModel currentViewModel;

        public ViewModel CurrentViewModel
        {
            get => currentViewModel;
            set => OnPropertyChanged(out currentViewModel, value);
        }

        public GameViewModel()
        {
            var gameSelectViewModel = new GameSelectViewModel(wrapper => CurrentViewModel = wrapper.CreateViewModel());
            GameSelectCommand = new RelayCommand(() => CurrentViewModel = gameSelectViewModel);
            CurrentViewModel = gameSelectViewModel;
        }
    }
}