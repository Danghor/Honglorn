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
        public ObservableCollection<Tuple<Student, Competition>> Students { get; set; } = new ObservableCollection<Tuple<Student, Competition>>(); //todo: rename
        public ObservableCollection<Competition> Competitions { get; set; } = new ObservableCollection<Competition>();

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

                LoadStudentsCompetitionsTuples();
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

        void LoadStudentsCompetitionsTuples()
        {
            Students.Clear();

            ICollection<Student> students = HonglornBL.Honglorn.GetStudents(CurrentCourse, CurrentYear);

            foreach (Student student in students)
            {
                Competition competition = (from sc in student.Competition
                                           where sc.Year == currentYear
                                           select sc).SingleOrDefault() ?? new Competition();

                Students.Add(new Tuple<Student, Competition>(student, competition));
            }
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}