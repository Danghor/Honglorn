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
        bool enabled;


        internal bool Enabled
        {
            get { return enabled; }
            set
            {
                enabled = value;
                CanExecuteChanged?.Invoke(this, null);
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
