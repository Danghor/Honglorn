using HonglornBL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    class ImportStudentsViewModel : ViewModel
    {
        readonly BackgroundWorker importWorker;
        short year;
        string path;

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

        public ICommand OpenFileDialogCommand { get; }
        public ICommand ImportStudentsAsynCommand { get; }

        public ImportStudentsViewModel()
        {
            Year = (short) DateTime.Now.Year;
            OpenFileDialogCommand = new RelayCommand(OpenFileDialog);
            ImportStudentsAsynCommand = new RelayCommand(ImportStudentsAsync);

            importWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true
            };
            importWorker.DoWork += ImportStudents;
            importWorker.ProgressChanged += ProgressChanged;
        }

        void OpenFileDialog()
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                Path = dialog.FileName;
            }
        }

        void ImportStudentsAsync()
        {
            importWorker.RunWorkerAsync();
        }

        void ImportStudents(object sender, DoWorkEventArgs e)
        {
            HonglornBL.Honglorn.ImportStudentCourseExcelSheet(Path, Year, importWorker);
        }

        void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            IProgressInformer informer = e.UserState as IProgressInformer;
            Console.WriteLine(informer.StatusMessage);
        }
    }
}
