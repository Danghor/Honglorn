using HonglornBL;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    class ClassListViewModel : ViewModel
    {
        readonly ClassService service;

        public ObservableCollection<ClassManager> ClassManagers { get; } = new ObservableCollection<ClassManager>();

        ClassManager currentClassManager;
        public ClassManager CurrentClassManager
        {
            get => currentClassManager;
            set => OnPropertyChanged(out currentClassManager, value);
        }

        bool editIsOpen;
        public bool EditIsOpen
        {
            get => editIsOpen;
            set => OnPropertyChanged(out editIsOpen, value);
        }

        public ICommand NewCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand RefreshCommand { get; }
        public ICommand DeleteCommand { get; }

        public ClassListViewModel()
        {
            NewCommand = new RelayCommand(New);
            EditCommand = new RelayCommand(Edit);
            RefreshCommand = new RelayCommand(Refresh);
            DeleteCommand = new RelayCommand(Delete);
            service = Honglorn.ClassService();
        }

        void New()
        {
            EditIsOpen = true;
        }

        void Edit()
        {
            EditIsOpen = true;
        }

        void Delete()
        {
            service.Delete(currentClassManager);
            Refresh();
        }

        void Refresh()
        {
            var classManagers = service.GetManagers();
            ClearAndFill(ClassManagers, classManagers);
        }
    }
}