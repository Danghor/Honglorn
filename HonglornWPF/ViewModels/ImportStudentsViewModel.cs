using HonglornBL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    class ImportStudentsViewModel : ViewModel
    {
        readonly BackgroundWorker importWorker;
        short year;
        string path;
        ProgressBarStyle progressBarStyle;

        public ProgressBarStyle ProgressBarStyle
        {
            get { return progressBarStyle; }
            set
            {
                progressBarStyle = value;
                OnPropertyChanged(nameof(ProgressBarStyle));
            }
        }

        public int Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public string StatusMessage
        {
            get { return statusMessage; }
            set
            {
                statusMessage = value;
                OnPropertyChanged(nameof(StatusMessage));
            }
        }

        int status;
        string statusMessage;

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

        public RelayCommand OpenFileDialogCommand { get; }
        public RelayCommand ImportStudentsAsyncCommand { get; }

        public ImportStudentsViewModel()
        {
            Year = (short) DateTime.Now.Year;
            OpenFileDialogCommand = new RelayCommand(OpenFileDialog);
            ImportStudentsAsyncCommand = new RelayCommand(ImportStudentsAsync);

            importWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true
            };
            importWorker.DoWork += ImportStudents;
            importWorker.ProgressChanged += OnProgressChanged;
            importWorker.RunWorkerCompleted += OnRunWorkerCompleted;
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
            ImportStudentsAsyncCommand.Enabled = false;

            try
            {
                importWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                ImportStudentsAsyncCommand.Enabled = true;
            }
        }

        void ImportStudents(object sender, DoWorkEventArgs e)
        {
            HonglornBL.Honglorn.ImportStudentCourseExcelSheet(Path, Year, importWorker);
        }

        void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            IProgressInformer informer = e.UserState as IProgressInformer;
            StatusMessage = informer.StatusMessage;
            ProgressBarStyle = informer.Style;

            Status = e.ProgressPercentage;
        }

        void OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Status = 0;
            ProgressBarStyle = ProgressBarStyle.Continuous;
            StatusMessage = string.Empty;
            ImportStudentsAsyncCommand.Enabled = true;
        }
    }
}
