using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    class ClassDetailViewModel : ViewModel
    {
        public enum Mode { Add, Edit }

        string className;

        public string ClassName
        {
            get => className;
            set => OnPropertyChanged(out className, value);
        }

        public ICommand UpdateCommand { get; }

        public ClassDetailViewModel()
        {
            UpdateCommand = new RelayCommand(Update);
        }

        void Update()
        {

        }
    }
}
