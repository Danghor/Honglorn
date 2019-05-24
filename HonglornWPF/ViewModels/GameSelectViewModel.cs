using HonglornBL;

namespace HonglornWPF.ViewModels
{
    class GameSelectViewModel : ViewModel
    {
        GameCollection gameCollection;

        public GameCollection GameCollection
        {
            get => gameCollection;
            set => OnPropertyChanged(out gameCollection, value);
        }

    }
}