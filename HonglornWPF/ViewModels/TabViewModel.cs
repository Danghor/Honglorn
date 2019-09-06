using HonglornBL;
using System;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    abstract class TabViewModel : NotifyPropertyChangedInformer
    {
        string tabTitle;

        public string TabTitle
        {
            get => tabTitle;
            set => OnPropertyChanged(out tabTitle, value);
        }

        public ICommand CloseCommand { get; }

        internal event EventHandler OnCloseButtonPressed;

        protected TabViewModel()
        {
            CloseCommand = new RelayCommand(() => OnCloseButtonPressed?.Invoke(this, EventArgs.Empty));
            TabTitle = ToString();
        }
    }
}