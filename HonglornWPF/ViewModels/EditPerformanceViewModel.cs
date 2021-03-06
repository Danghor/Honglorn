﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    class EditPerformanceViewModel : ViewModel
    {
        public ObservableCollection<string> Courses { get; } = new ObservableCollection<string>();
        public ObservableCollection<short> Years { get; } = new ObservableCollection<short>();
        public ObservableCollection<StudentPerformance> StudentCompetitions { get; } = new ObservableCollection<StudentPerformance>();

        public ICommand RefreshYears { get; }

        short currentYear;
        public short CurrentYear
        {
            get => currentYear;

            set
            {
                SaveCompetition();
                OnPropertyChanged(out currentYear, value);

                string previouslySelectedCourse = CurrentCourse;

                LoadCourseNames();

                CurrentCourse = Courses.Contains(previouslySelectedCourse) ? previouslySelectedCourse : Courses.FirstOrDefault();
            }
        }

        string currentCourse;
        public string CurrentCourse
        {
            get => currentCourse;
            set
            {
                SaveCompetition();
                OnPropertyChanged(out currentCourse, value);

                LoadStudentsCompetitionsTuples();
            }
        }

        StudentPerformance currentStudentCompetition;
        public StudentPerformance CurrentStudentCompetition
        {
            get => currentStudentCompetition;
            set
            {
                SaveCompetition();
                OnPropertyChanged(out currentStudentCompetition, value);
            }
        }

        public EditPerformanceViewModel()
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