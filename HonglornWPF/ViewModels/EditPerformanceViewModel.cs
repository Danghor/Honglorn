using System.Collections.ObjectModel;
using System.Linq;
using HonglornBL;

namespace HonglornWPF.ViewModels
{
    class EditPerformanceViewModel : ViewModel
    {
        public ObservableCollection<string> Courses { get; } = new ObservableCollection<string>();
        public ObservableCollection<short> Years { get; } = new ObservableCollection<short>();
        public ObservableCollection<StudentPerformance> StudentCompetitions { get; } = new ObservableCollection<StudentPerformance>();

        string currentCourse;
        short currentYear;
        StudentPerformance currentStudentCompetition;

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

        public StudentPerformance CurrentStudentCompetition
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
            ClearAndFill(StudentCompetitions, Honglorn.StudentPerformances(CurrentCourse, CurrentYear).Select(i => new StudentPerformance(i)));
        }

        void SaveCompetition(IStudentPerformance sc)
        {
            if (sc != null)
            {
                Honglorn.UpdateSingleStudentCompetition(sc.StudentPKey, CurrentYear, sc.Sprint, sc.Jump, sc.Throw, sc.MiddleDistance);
            }
        }
    }
}