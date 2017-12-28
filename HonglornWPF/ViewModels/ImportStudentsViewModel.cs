using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HonglornWPF.ViewModels
{
    class ImportStudentsViewModel : ViewModel
    {

        short year;

        public short Year
        {
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged(nameof(Year));
            }
        }

        public ImportStudentsViewModel()
        {
            Year = (short)(DateTime.Now.Year);
        }
    }
}
