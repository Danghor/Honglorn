using System;
using System.ComponentModel;
using System.Windows.Forms;
using HonglornBL;
using HonglornBL.Interfaces;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

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
            get => progressBarStyle;
            set
            {
                progressBarStyle = value;
                OnPropertyChanged();
            }
        }

        public int Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged();
            }
        }

        public string StatusMessage
        {
            get => statusMessage;
            set
            {
                statusMessage = value;
                OnPropertyChanged();
            }
        }

        int status;
        string statusMessage;

        public short Year
        {
            get => year;
            set
            {
                year = value;
                OnPropertyChanged();
            }
        }

        public string Path
        {
            get => path;
            set
            {
                path = value;
                OnPropertyChanged();
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
            var dialog = new OpenFileDialog();

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
            Honglorn.ImportStudentCourseExcelSheet(Path, Year, importWorker);
        }

        void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var informer = e.UserState as IProgressInformer;
            if (informer != null)
            {
                StatusMessage = informer.StatusMessage;
                ProgressBarStyle = informer.Style;
            }
            else
            {
                StatusMessage = "Error: Cannot display progress.";
                ProgressBarStyle = ProgressBarStyle.Marquee;
            }

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
