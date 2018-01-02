using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    class RelayCommand : ICommand
    {
        Action Action { get; }

        public event EventHandler CanExecuteChanged;

        internal RelayCommand(Action action)
        {
            Action = action;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            Action?.Invoke();
        }
    }
}
