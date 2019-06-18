namespace HonglornWPF.ViewModels
{
    class GameViewModel : ViewModel
    {
        ViewModel currentViewModel;

        public ViewModel CurrentViewModel
        {
            get => currentViewModel;
            set => OnPropertyChanged(out currentViewModel, value);
        }

        public GameViewModel()
        {
            CurrentViewModel = new GameSelectViewModel();
        }
    }
}