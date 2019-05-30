using System;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    abstract class DetailViewModel<TModel> : ViewModel
    {
        ICommand acceptCommand;

        public ICommand AcceptCommand
        {
            get => acceptCommand;
            set => OnPropertyChanged(out acceptCommand, value);
        }

        public ICommand CancelCommand { get; }

        internal DetailViewModel(Action cancelAction)
        {
            CancelCommand = new RelayCommand(cancelAction);
        }

        internal abstract void Clear();

        internal abstract void CopyValues(TModel model);
    }
}