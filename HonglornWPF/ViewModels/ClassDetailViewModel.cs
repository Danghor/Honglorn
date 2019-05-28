using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    class ClassDetailViewModel : ViewModel
    {
        public enum Mode { Add, Edit }

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
