using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using HonglornBL;

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
                OnPropertyChanged(nameof(CurrentYear));

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
                OnPropertyChanged(nameof(CurrentCourse));

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

        void LoadCourseNames()
        {
            Courses.Clear();

            ICollection<string> courseNames = Honglorn.ValidCourseNames(CurrentYear);

            foreach (string courseName in courseNames)
            {
                Courses.Add(courseName);
            }
        }

        void LoadYears()
        {
            Years.Clear();

            ICollection<short> years = Honglorn.YearsWithStudentData();

            foreach (short year in years)
            {
                Years.Add(year);
            }
        }

        void LoadResults()
        {
            Results.Clear();

            ICollection<Result> results = Honglorn.GetResults(CurrentCourse, CurrentYear);

            foreach (Result result in results)
            {
                Results.Add(result);
            }
        }
    }
}
