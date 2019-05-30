using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    abstract class ListViewModel<TService, TManager, TDetailViewModel> : ViewModel
    {
        protected TService service;

        public ObservableCollection<TManager> ClassManagers { get; } = new ObservableCollection<TManager>();

        TManager currentManager;

        public TManager CurrentManager
        {
            get => currentManager;
            set => OnPropertyChanged(out currentManager, value);
        }

        public ICommand NewCommand { get; protected set; }
        public ICommand EditCommand { get; protected set; }
        public ICommand DeleteCommand { get; protected set; }

        TDetailViewModel detailViewModel;

        public TDetailViewModel DetailViewModel
        {
            get => detailViewModel;
            set => OnPropertyChanged(out detailViewModel, value);
        }
    }
}