using HonglornBL;
using HonglornWPF.Properties;
using Microsoft.Win32;
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
        public ICommand Print { get; }

        bool isLoading;
        public bool IsLoading
        {
            get => isLoading;
            private set => OnPropertyChanged(out isLoading, value);
        }

        string message;
        public string Message
        {
            get => message;
            private set => OnPropertyChanged(out message, value);
        }

        short currentYear;
        public short CurrentYear
        {
            get => currentYear;

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
            get => currentCourse;
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
            Print = new RelayCommand(PrintReport);
            RefreshYearsFromDb();
        }

        void RefreshYearsFromDb()
        {
            short previouslySelectedYear = CurrentYear;
            LoadYears();
            CurrentYear = Years.Contains(previouslySelectedYear) ? previouslySelectedYear : Years.FirstOrDefault();
        }

        async void PrintReport()
        {
            var dialog = new SaveFileDialog
            {
                Filter = "PDF (*.pdf)|*.pdf",
                Title = "Bericht"
            };

            if (dialog.ShowDialog() == true)
            {
                await Honglorn.PrintReportAsync(dialog.FileName, Settings.Default.SchoolName, CurrentCourse, CurrentYear);
            }
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