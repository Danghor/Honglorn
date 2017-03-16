using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using HonglornBL.Models.Entities;

namespace HonglornWPF.ViewModels
{
    class EditPerformanceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event Action CoursesLoaded;
        public event Action YearsLoaded;

        public ObservableCollection<string> Courses { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<short> Years { get; set; } = new ObservableCollection<short>();
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();
        public ObservableCollection<Competition> Competitions { get; set; } = new ObservableCollection<Competition>();

        string currentCourse;
        short currentYear;
        Student currentStudent;
        Competition currentCompetition;

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

                LoadStudents();
            }
        }

        public EditPerformanceViewModel()
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

            ICollection<string> courseNames = HonglornBL.Honglorn.ValidCourseNames(CurrentYear);

            foreach (string courseName in courseNames)
            {
                Courses.Add(courseName);
            }

            CoursesLoaded?.Invoke();
        }

        void LoadYears()
        {
            Years.Clear();

            ICollection<short> years = HonglornBL.Honglorn.YearsWithStudentData();

            foreach (short year in years)
            {
                Years.Add(year);
            }

            YearsLoaded?.Invoke();
        }

        void LoadStudents()
        {
            Students.Clear();

            ICollection<Student> students = HonglornBL.Honglorn.GetStudents(CurrentCourse, CurrentYear);

            foreach (Student student in students)
            {
                Students.Add(student);
            }
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}