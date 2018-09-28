using HonglornBL;
using HonglornBL.Import;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace HonglornWPF.ViewModels
{
    class ImportStudentsViewModel : ViewModel
    {
        ProgressBarStyle progressBarStyle;
        public ProgressBarStyle ProgressBarStyle
        {
            get { return progressBarStyle; }
            set { OnPropertyChanged(ref progressBarStyle, value); }
        }

        int status;
        public int Status
        {
            get { return status; }
            set { OnPropertyChanged(ref status, value); }
        }

        string statusMessage;
        public string StatusMessage
        {
            get { return statusMessage; }
            set { OnPropertyChanged(ref statusMessage, value); }
        }

        short year;
        public short Year
        {
            get { return year; }
            set { OnPropertyChanged(ref year, value); }
        }

        string path;
        public string Path
        {
            get { return path; }
            set { OnPropertyChanged(ref path, value); }
        }

        public RelayCommand OpenFileDialogCommand { get; }
        public RelayCommand ImportStudentsAsyncCommand { get; }

        public ImportStudentsViewModel()
        {
            Year = (short)DateTime.Now.Year;
            OpenFileDialogCommand = new RelayCommand(OpenFileDialog);
            ImportStudentsAsyncCommand = new RelayCommand(ImportStudentsAsync);
        }

        void OpenFileDialog()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                Path = dialog.FileName;
            }
        }

        async void ImportStudentsAsync()
        {
            MetroWindow mainWindow = System.Windows.Application.Current.MainWindow as MetroWindow;

            try
            {
                ICollection<ImportedStudentRecord> importedStudents = await Honglorn.ImportStudentCourseExcelSheet(Path, Year, new Progress<ProgressReport>(r => OnProgressChanged(r)));

                int successfullyImported = importedStudents.Count(s => s.Error == null);
                int unsuccessfullyImported = importedStudents.Count(s => s.Error != null);

                await mainWindow.ShowMessageAsync("Notification", $"Successfully imported: {successfullyImported} \r\nFailed to import: {unsuccessfullyImported}");
            }
            catch (Exception ex)
            {
                await mainWindow.ShowMessageAsync("Error", ex.Message);
            }
            finally
            {
                Status = 0;
                ProgressBarStyle = ProgressBarStyle.Continuous;
                StatusMessage = string.Empty;
                ImportStudentsAsyncCommand.Enabled = true;
            }
        }

        void OnProgressChanged(ProgressReport report)
        {
            StatusMessage = report.Message;
            ProgressBarStyle = report.IsIndeterminate ? ProgressBarStyle.Marquee : ProgressBarStyle.Continuous;
            Status = report.Percentage;
        }
    }
}
