using HonglornBL;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    class ClassListViewModel : ViewModel
    {
        public ObservableCollection<ClassManager> ClassManagers { get; } = new ObservableCollection<ClassManager>();

        public ICommand RefreshCommand { get; }

        public ClassListViewModel()
        {
            RefreshCommand = new RelayCommand(Refresh);
        }

        void Refresh()
        {
            ClassService classService = Honglorn.ClassService();
            var classManagers = classService.GetManagers();

            ClearAndFill(ClassManagers, classManagers);
        }
    }
}