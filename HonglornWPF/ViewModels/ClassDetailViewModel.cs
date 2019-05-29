using HonglornBL.Interfaces;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    class ClassDetailViewModel : DetailViewModel<IClassModel>, IClassModel
    {
        string name;

        public string Name
        {
            get => name;
            set => OnPropertyChanged(out name, value);
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

        internal override void Clear()
        {
            Name = string.Empty;
        }

        internal override void CopyValues(IClassModel model)
        {
            Name = model.Name;
        }
    }
}