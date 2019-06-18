namespace HonglornWPF.ViewModels
{
    class GameViewModel : ViewModel
    {
        ViewModel gameSelectViewModel;

        public ViewModel GameSelectViewModel
        {
            get => gameSelectViewModel;
            set => OnPropertyChanged(out gameSelectViewModel, value);
        }

        ViewModel currentGameViewModel;

        public ViewModel CurrentGameViewModel
        {
            get => currentGameViewModel;
            set => OnPropertyChanged(out currentGameViewModel, value);
        }
    }
}