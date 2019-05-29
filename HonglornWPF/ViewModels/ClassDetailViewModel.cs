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

        public ClassDetailViewModel(ICommand cancelCommand) : base(cancelCommand) { }

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