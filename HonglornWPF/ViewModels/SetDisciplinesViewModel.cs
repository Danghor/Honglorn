using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HonglornWPF.ViewModels
{
    class SetDisciplinesViewModel : ViewModel
    {
        public ObservableCollection<string> Courses { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<short> Years { get; set; } = new ObservableCollection<short>();

        string currentCourse;
        short currentYear;
    }
}
