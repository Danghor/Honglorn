using System;
using System.Collections.ObjectModel;
using System.Linq;
using HonglornBL;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;

namespace HonglornWPF.ViewModels
{
    class ClassResultsViewModel : ViewModel
    {
        public ObservableCollection<string> Courses { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<short> Years { get; set; } = new ObservableCollection<short>();
        public ObservableCollection<Result> Results { get; set; } = new ObservableCollection<Result>();

        string currentCourse;
        short currentYear;

        public short CurrentYear
        {
            get { return currentYear; }

            set
            {
                currentYear = value;
                OnPropertyChanged();

                string previouslySelectedCourse = CurrentCourse;

                LoadCourseNames();

                int courseIndex = Courses.IndexOf(previouslySelectedCourse);
                CurrentCourse = courseIndex != -1 ? previouslySelectedCourse : Courses.FirstOrDefault();
            }
        }

        public string CurrentCourse
        {
            get { return currentCourse; }
            set
            {
                currentCourse = value;
                OnPropertyChanged();

                LoadResults();
            }
        }

        public ClassResultsViewModel()
        {
            LoadYears();
            if (Years.Any())
            {
                CurrentYear = Years.First();
            }
        }

        void LoadCourseNames() => ClearAndFill(Courses, Honglorn.ValidCourseNames(CurrentYear));

        void LoadYears() => ClearAndFill(Years, Honglorn.YearsWithStudentData());

        async void LoadResults()
        {
            try
            {
                ClearAndFill(Results, await Honglorn.GetResultsAsync(CurrentCourse, CurrentYear));
            }
            catch (Exception ex)
            {
                var mainWindow = Application.Current.MainWindow as MetroWindow;
                await mainWindow.ShowMessageAsync("Error", ex.Message);
            }
        }
    }
}
