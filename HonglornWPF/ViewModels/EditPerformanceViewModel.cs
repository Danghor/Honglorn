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

        short currentYear;
        public short CurrentYear
        {
            get { return currentYear; }

            set
            {
                SaveCompetition();
                OnPropertyChanged(ref currentYear, value);

                string previouslySelectedCourse = CurrentCourse;

                LoadCourseNames();

                int courseIndex = Courses.IndexOf(previouslySelectedCourse);
                CurrentCourse = courseIndex != -1 ? previouslySelectedCourse : Courses.FirstOrDefault();
            }
        }

        string currentCourse;
        public string CurrentCourse
        {
            get { return currentCourse; }
            set
            {
                SaveCompetition();
                OnPropertyChanged(ref currentCourse, value);

                LoadStudentsCompetitionsTuples();
            }
        }

        StudentPerformance currentStudentCompetition;
        public StudentPerformance CurrentStudentCompetition
        {
            get { return currentStudentCompetition; }
            set
            {
                SaveCompetition();
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

        void SaveCompetition()
        {
            if (currentStudentCompetition != null)
            {
                Honglorn.UpdateSingleStudentCompetition(currentStudentCompetition.StudentPKey, CurrentYear, currentStudentCompetition.Sprint, currentStudentCompetition.Jump, currentStudentCompetition.Throw, currentStudentCompetition.MiddleDistance);
            }
        }
    }
}