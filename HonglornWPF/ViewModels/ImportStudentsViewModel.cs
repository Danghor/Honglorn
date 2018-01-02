﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    class ImportStudentsViewModel : ViewModel
    {

        short year;
        string path;
        ICommand openFileDialogCommand;

        public short Year
        {
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged(nameof(Year));
            }
        }

        public string Path
        {
            get { return path; }
            set
            {
                path = value;
                OnPropertyChanged(nameof(Path));
            }
        }

        public ICommand OpenFileDialogCommand
        {
            get { return openFileDialogCommand; }
            set
            {
                openFileDialogCommand = value;
                OnPropertyChanged(nameof(OpenFileDialogCommand));
            }
        }

        public ImportStudentsViewModel()
        {
            Year = (short)(DateTime.Now.Year);
            OpenFileDialogCommand = new RelayCommand(OpenFileDialog);
        }

        private void OpenFileDialog()
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                Path = dialog.FileName;
            }
        }
    }
}
