using System;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    class RelayCommand : ICommand
    {
        Action Action { get; }
        bool enabled;

        internal bool Enabled
        {
            get => enabled;
            set
            {
                enabled = value;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler CanExecuteChanged;

        internal RelayCommand(Action action)
        {
            Action = action;
            Enabled = true;
        }

        public bool CanExecute(object parameter) => Enabled;

        public void Execute(object parameter)
        {
            Action?.Invoke();
        }
    }
}