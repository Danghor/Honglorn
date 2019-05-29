using System.Collections.ObjectModel;

namespace HonglornWPF.ViewModels
{
    abstract class ListViewModel<TService, TManager> : ViewModel
    {
        protected TService service;

        public ObservableCollection<TManager> ClassManagers { get; } = new ObservableCollection<TManager>();

        TManager currentManager;

        public TManager CurrentManager
        {
            get => currentManager;
            set => OnPropertyChanged(out currentManager, value);
        }
    }
}