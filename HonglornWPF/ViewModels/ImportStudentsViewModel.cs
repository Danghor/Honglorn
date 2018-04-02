using System;
using System.ComponentModel;
using System.Windows.Forms;
using HonglornBL;
using HonglornBL.Interfaces;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using Microsoft;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using HonglornBL.Import;
using System.Collections.Generic;
using System.Linq;

namespace HonglornWPF.ViewModels
{
    class ImportStudentsViewModel : ViewModel
    {
        short year;
        string path;
        ProgressBarStyle progressBarStyle;

        public ProgressBarStyle ProgressBarStyle
        {
            get { return progressBarStyle; }
            set
            {
                progressBarStyle = value;
                OnPropertyChanged();
            }
        }

        public int Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged();
            }
        }

        public string StatusMessage
        {
            get { return statusMessage; }
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
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged();
            }
        }

        public string Path
        {
            get { return path; }
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
            Year = (short)DateTime.Now.Year;
            OpenFileDialogCommand = new RelayCommand(OpenFileDialog);
            ImportStudentsAsyncCommand = new RelayCommand(ImportStudentsAsync);
        }

        void OpenFileDialog()
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                Path = dialog.FileName;
            }
        }

        async void ImportStudentsAsync()
        {
            var mainWindow = System.Windows.Application.Current.MainWindow as MetroWindow;

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
