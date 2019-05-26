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

        public ICommand RefreshCommand { get; }
        public ICommand DeleteCommand { get; }

        public ClassListViewModel()
        {
            RefreshCommand = new RelayCommand(Refresh);
            DeleteCommand = new RelayCommand(Delete);
            service = Honglorn.ClassService();
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