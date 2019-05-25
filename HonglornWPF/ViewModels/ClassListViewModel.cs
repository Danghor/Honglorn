using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using HonglornBL;

namespace HonglornWPF.ViewModels
{
    class ClassListViewModel : ViewModel
    {
        public ObservableCollection<ClassManager> ClassManagers { get; } = new ObservableCollection<ClassManager>();
    }
}
