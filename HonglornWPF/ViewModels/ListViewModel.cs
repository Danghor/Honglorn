using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    abstract class ListViewModel<TService, TManager, TDetailViewModel> : ViewModel
    {
        protected TService service;

        public ObservableCollection<TManager> Managers { get; } = new ObservableCollection<TManager>();
        public ICommand NewCommand { get; protected set; }
        public ICommand EditCommand { get; protected set; }
        public ICommand DeleteCommand { get; protected set; }

        TManager currentManager;
        public TManager CurrentManager
        {
            get => currentManager;
            set => OnPropertyChanged(out currentManager, value);
        }

        TDetailViewModel detailViewModel;
        public TDetailViewModel DetailViewModel
        {
            get => detailViewModel;
            set => OnPropertyChanged(out detailViewModel, value);
        }

        bool detailViewIsVisible;
        public bool DetailViewIsVisible
        {
            get => detailViewIsVisible;
            set => OnPropertyChanged(out detailViewIsVisible, value);
        }
    }
}