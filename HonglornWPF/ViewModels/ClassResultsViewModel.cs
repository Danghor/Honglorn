using HonglornBL;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    class ClassResultsViewModel : ViewModel
    {
        public ObservableCollection<string> Courses { get; } = new ObservableCollection<string>();
        public ObservableCollection<short> Years { get; } = new ObservableCollection<short>();
        public ObservableCollection<IResult> Results { get; } = new ObservableCollection<IResult>();

        public ICommand RefreshYears { get; }

        bool isLoading;
        public bool IsLoading
        {
            get { return isLoading; }
            private set
            {
                OnPropertyChanged(out isLoading, value);
            }
        }

        string message;
        public string Message
        {
            get { return message; }
            private set
            {
                OnPropertyChanged(out message, value);
            }
        }

        short currentYear;
        public short CurrentYear
        {
            get { return currentYear; }

            set
            {
                OnPropertyChanged(out currentYear, value);

                string previouslySelectedCourse = CurrentCourse;

                LoadCourseNames();

                //todo: move to superclass
                CurrentCourse = Courses.Contains(previouslySelectedCourse) ? previouslySelectedCourse : Courses.FirstOrDefault();
            }
        }

        string currentCourse;
        public string CurrentCourse
        {
            get { return currentCourse; }
            set
            {
                OnPropertyChanged(out currentCourse, value);

                if (CurrentCourse != null)
                {
                    LoadResults();
                }
            }
        }

        public ClassResultsViewModel()
        {
            RefreshYears = new RelayCommand(RefreshYearsFromDb);
            RefreshYearsFromDb();
        }

        void RefreshYearsFromDb()
        {
            short previouslySelectedYear = CurrentYear;
            LoadYears();
            CurrentYear = Years.Contains(previouslySelectedYear) ? previouslySelectedYear : Years.FirstOrDefault();
        }

        void LoadCourseNames() => ClearAndFill(Courses, Honglorn.ValidCourseNames(CurrentYear));

        void LoadYears() => ClearAndFill(Years, Honglorn.YearsWithStudentData());

        async void LoadResults()
        {
            Message = null;
            IsLoading = true;

            try
            {
                ClearAndFill(Results, await Honglorn.GetResultsAsync(CurrentCourse, CurrentYear));
            }
            catch (DataException ex)
            {
                Message = ex.Message;
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}