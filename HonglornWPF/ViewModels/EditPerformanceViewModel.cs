using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HonglornBL;
using HonglornBL.Models.Entities;

namespace HonglornWPF.ViewModels
{
    class EditPerformanceViewModel : ViewModel
    {
        public ObservableCollection<string> Courses { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<short> Years { get; set; } = new ObservableCollection<short>();
        public ObservableCollection<StudentCompetition> StudentCompetitions { get; set; } = new ObservableCollection<StudentCompetition>();

        string currentCourse;
        short currentYear;
        StudentCompetition currentStudentCompetition;

        public short CurrentYear
        {
            get { return currentYear; }

            set
            {
                SaveCompetition(currentStudentCompetition);
                OnPropertyChanged(ref currentYear, value);

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
                SaveCompetition(currentStudentCompetition);
                OnPropertyChanged(ref currentCourse, value);

                LoadStudentsCompetitionsTuples();
            }
        }

        public StudentCompetition CurrentStudentCompetition
        {
            get { return currentStudentCompetition; }
            set
            {
                SaveCompetition(currentStudentCompetition);
                OnPropertyChanged(ref currentStudentCompetition, value);
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

        void LoadCourseNames() => ClearAndFill(Courses, Honglorn.ValidCourseNames(CurrentYear));

        void LoadYears() => ClearAndFill(Years, Honglorn.YearsWithStudentData());

        void LoadStudentsCompetitionsTuples()
        {
            StudentCompetitions.Clear();

            ICollection<Student> students = Honglorn.GetStudents(CurrentCourse, CurrentYear);

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
            if (sc != null)
            {
                Honglorn.UpdateSingleStudentCompetition(sc.StudentPKey, CurrentYear, sc.Sprint, sc.Jump, sc.Throw, sc.MiddleDistance);
            }
        }
    }
}