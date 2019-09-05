using HonglornBL;
using System;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    abstract class TabViewModel : NotifyPropertyChangedInformer
    {
        public ICommand CloseCommand { get; }

        internal event EventHandler OnCloseButtonPressed;

        protected TabViewModel()
        {
            CloseCommand = new RelayCommand(() => OnCloseButtonPressed?.Invoke(this, EventArgs.Empty));
        }
    }
}