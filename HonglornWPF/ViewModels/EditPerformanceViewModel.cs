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
        public ObservableCollection<StudentCompetition> StudentCompetitions { get; set; } = new ObservableCollection<StudentCompetition>();
        public ObservableCollection<Competition> Competitions { get; set; } = new ObservableCollection<Competition>();

        string currentCourse;
        short currentYear;
        StudentCompetition currentStudentCompetition;

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

        public StudentCompetition CurrentStudentCompetition
        {
            get { return currentStudentCompetition; }
            set
            {
                currentStudentCompetition = value;
                OnPropertyChanged(nameof(CurrentStudentCompetition));
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
            StudentCompetitions.Clear();

            ICollection<Student> students = HonglornBL.Honglorn.GetStudents(CurrentCourse, CurrentYear);

            foreach (Student student in students)
            {
                Competition competition = (from sc in student.Competition
                                           where sc.Year == currentYear
                                           select sc).SingleOrDefault() ?? new Competition();

                StudentCompetitions.Add(new StudentCompetition
                {
                    StudentPKey = student.PKey,
                    Surname = student.Surname,
                    Forename = student.Forename,
                    Sprint = competition.Sprint,
                    Jump = competition.Jump,
                    Throw = competition.Throw,
                    MiddleDistance = competition.MiddleDistance
                });
            }
        }

        void SaveCompetition(StudentCompetition sc)
        {
            HonglornBL.Honglorn.UpdateSingleStudentCompetition(sc.StudentPKey, CurrentYear, sc.Sprint, sc.Jump, sc.Throw, sc.MiddleDistance);
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}