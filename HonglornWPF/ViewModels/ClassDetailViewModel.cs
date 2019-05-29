using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    class ClassDetailViewModel : ViewModel
    {
        string className;

        public string ClassName
        {
            get => className;
            set => OnPropertyChanged(out className, value);
        }

        ICommand acceptCommand;

        public ICommand AcceptCommand
        {
            get => acceptCommand;
            set => OnPropertyChanged(out acceptCommand, value);
        }

        public ICommand CancelCommand { get; }

        internal ClassDetailViewModel(ICommand cancelCommand)
        {
            CancelCommand = cancelCommand;
        }
    }
}