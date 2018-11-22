using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using HonglornBL;
using HonglornBL.Import;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace HonglornWPF.ViewModels
{
    class ImportStudentsViewModel : ViewModel
    {
        bool isIndeterminate;
        public bool IsIndeterminate
        {
            get { return isIndeterminate; }
            set { OnPropertyChanged(out isIndeterminate, value); }
        }

        int statusPercentage;
        public int StatusPercentage
        {
            get { return statusPercentage; }
            set { OnPropertyChanged(out statusPercentage, value); }
        }

        string statusMessage;
        public string StatusMessage
        {
            get { return statusMessage; }
            set { OnPropertyChanged(out statusMessage, value); }
        }

        short year;
        public short Year
        {
            get { return year; }
            set { OnPropertyChanged(out year, value); }
        }

        string path;
        public string Path
        {
            get { return path; }
            set { OnPropertyChanged(out path, value); }
        }

        public ICommand OpenFileDialogCommand { get; }
        public RelayCommand ImportStudentsAsyncCommand { get; }

        public ImportStudentsViewModel()
        {
            Year = (short) DateTime.Now.Year;
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
            var mainWindow = (MetroWindow) System.Windows.Application.Current.MainWindow;

            try
            {
                ICollection<ImportedStudentRecord> importedStudents = await Honglorn.ImportStudentsFromFile(Path, Year, new Progress<ProgressReport>(OnProgressChanged));
                ICollection<ImportedStudentRecord> unsuccessfullyImported = importedStudents.Where(s => s.Errors != null).ToList();

                var messageBuilder = new StringBuilder($"Successfully imported {importedStudents.Count - unsuccessfullyImported.Count()} of {importedStudents.Count} students.");

                if (unsuccessfullyImported.Any())
                {
                    messageBuilder.AppendLine();
                    messageBuilder.AppendLine("The following students could not be imported: ");
                    foreach (var student in unsuccessfullyImported)
                    {
                        messageBuilder.AppendLine();
                        messageBuilder.AppendLine();
                        messageBuilder.AppendLine($"{student.ImportedForename} {student.ImportedSurname}, {student.ImportedSex}, born in {student.ImportedYearOfBirth}, in Course {student.ImportedCourseName}");

                        foreach (var error in student.Errors)
                        {
                            messageBuilder.AppendLine();
                            messageBuilder.AppendLine($"Fieldname: {error.FieldName}");
                            messageBuilder.AppendLine($"Fieldcontent: {error.FieldContent}");
                            messageBuilder.AppendLine($"Message: {error.Message}");
                        }
                    }
                }

                await mainWindow.ShowMessageAsync("Notification", messageBuilder.ToString());
            }
            catch (Exception ex)
            {
                await mainWindow.ShowMessageAsync("Error", ex.Message);
            }
            finally
            {
                StatusPercentage = 0;
                IsIndeterminate = false;
                StatusMessage = string.Empty;
                ImportStudentsAsyncCommand.Enabled = true;
            }
        }

        void OnProgressChanged(ProgressReport report)
        {
            StatusMessage = report.Message;
            IsIndeterminate = report.IsIndeterminate;
            StatusPercentage = report.Percentage;
        }
    }
}
