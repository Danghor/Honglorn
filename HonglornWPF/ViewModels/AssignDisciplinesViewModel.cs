using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HonglornBL.Enums;
using HonglornBL.Interfaces;

namespace HonglornWPF.ViewModels
{
    class AssignDisciplinesViewModel : ViewModel
    {
        public ObservableCollection<string> Classes { get; } = new ObservableCollection<string>();
        public ObservableCollection<short> Years { get; } = new ObservableCollection<short>();
        public ObservableCollection<IDiscipline> MaleSprintDisciplines { get; } = new ObservableCollection<IDiscipline>();
        public ObservableCollection<IDiscipline> MaleJumpDisciplines { get; } = new ObservableCollection<IDiscipline>();
        public ObservableCollection<IDiscipline> MaleThrowDisciplines { get; } = new ObservableCollection<IDiscipline>();
        public ObservableCollection<IDiscipline> MaleMiddleDistanceDisciplines { get; } = new ObservableCollection<IDiscipline>();
        public ObservableCollection<IDiscipline> FemaleSprintDisciplines { get; } = new ObservableCollection<IDiscipline>();
        public ObservableCollection<IDiscipline> FemaleJumpDisciplines { get; } = new ObservableCollection<IDiscipline>();
        public ObservableCollection<IDiscipline> FemaleThrowDisciplines { get; } = new ObservableCollection<IDiscipline>();
        public ObservableCollection<IDiscipline> FemaleMiddleDistanceDisciplines { get; } = new ObservableCollection<IDiscipline>();

        public RelayCommand SaveDisciplineCollectionCommand { get; }

        short currentYear;
        public short CurrentYear
        {
            get { return currentYear; }

            set
            {
                OnPropertyChanged(out currentYear, value);

                string previouslySelectedClass = CurrentClass;

                LoadClassNames();

                CurrentClass = Classes.Contains(previouslySelectedClass) ? previouslySelectedClass : Classes.FirstOrDefault();
            }
        }

        string currentClass;
        public string CurrentClass
        {
            get { return currentClass; }
            set
            {
                OnPropertyChanged(out currentClass, value);

                Game = Honglorn.GetGameType(CurrentClass, CurrentYear);
            }
        }

        Game? game;
        public Game? Game
        {
            get { return game; }
            set
            {
                OnPropertyChanged(out game, value);

                switch (value)
                {
                    case HonglornBL.Enums.Game.Traditional:
                        LoadAllTraditionalDisciplines();
                        SelectSavedDisiciplines();
                        break;
                    case HonglornBL.Enums.Game.Competition:
                        LoadAllCompetitionDisciplines();
                        SelectSavedDisiciplines();
                        break;
                    case null:
                        SetSelectedDisciplinesToNull();
                        break;
                }
            }
        }

        IDiscipline currentMaleSprintDiscipline;
        public IDiscipline CurrentMaleSprintDiscipline
        {
            get { return currentMaleSprintDiscipline; }
            set { OnPropertyChanged(out currentMaleSprintDiscipline, value); }
        }

        IDiscipline currentMaleJumpDiscipline;
        public IDiscipline CurrentMaleJumpDiscipline
        {
            get { return currentMaleJumpDiscipline; }
            set { OnPropertyChanged(out currentMaleJumpDiscipline, value); }
        }

        IDiscipline currentMaleThrowDiscipline;
        public IDiscipline CurrentMaleThrowDiscipline
        {
            get { return currentMaleThrowDiscipline; }
            set { OnPropertyChanged(out currentMaleThrowDiscipline, value); }
        }

        IDiscipline currentMaleMiddleDistanceDiscipline;
        public IDiscipline CurrentMaleMiddleDistanceDiscipline
        {
            get { return currentMaleMiddleDistanceDiscipline; }
            set { OnPropertyChanged(out currentMaleMiddleDistanceDiscipline, value); }
        }

        IDiscipline currentFemaleSprintDiscipline;
        public IDiscipline CurrentFemaleSprintDiscipline
        {
            get { return currentFemaleSprintDiscipline; }
            set { OnPropertyChanged(out currentFemaleSprintDiscipline, value); }
        }

        IDiscipline currentFemaleJumpDiscipline;
        public IDiscipline CurrentFemaleJumpDiscipline
        {
            get { return currentFemaleJumpDiscipline; }
            set { OnPropertyChanged(out currentFemaleJumpDiscipline, value); }
        }

        IDiscipline currentFemaleThrowDiscipline;
        public IDiscipline CurrentFemaleThrowDiscipline
        {
            get { return currentFemaleThrowDiscipline; }
            set { OnPropertyChanged(out currentFemaleThrowDiscipline, value); }
        }

        IDiscipline currentFemaleMiddleDistanceDiscipline;
        public IDiscipline CurrentFemaleMiddleDistanceDiscipline
        {
            get { return currentFemaleMiddleDistanceDiscipline; }
            set { OnPropertyChanged(out currentFemaleMiddleDistanceDiscipline, value); }
        }

        void LoadClassNames()
        {
            ClearAndFill(Classes, Honglorn.ValidClassNames(CurrentYear));
        }

        void LoadYears()
        {
            ClearAndFill(Years, Honglorn.YearsWithStudentData());
        }

        void LoadAllCompetitionDisciplines()
        {
            ICollection<IDiscipline> sprintDisciplines = Honglorn.FilteredCompetitionDisciplines(DisciplineType.Sprint);
            ICollection<IDiscipline> jumpDisciplines = Honglorn.FilteredCompetitionDisciplines(DisciplineType.Jump);
            ICollection<IDiscipline> throwDisciplines = Honglorn.FilteredCompetitionDisciplines(DisciplineType.Throw);
            ICollection<IDiscipline> middleDistanceDisciplines = Honglorn.FilteredCompetitionDisciplines(DisciplineType.MiddleDistance);

            ClearAndFill(MaleSprintDisciplines, sprintDisciplines);
            ClearAndFill(MaleJumpDisciplines, jumpDisciplines);
            ClearAndFill(MaleThrowDisciplines, throwDisciplines);
            ClearAndFill(MaleMiddleDistanceDisciplines, middleDistanceDisciplines);

            ClearAndFill(FemaleSprintDisciplines, sprintDisciplines);
            ClearAndFill(FemaleJumpDisciplines, jumpDisciplines);
            ClearAndFill(FemaleThrowDisciplines, throwDisciplines);
            ClearAndFill(FemaleMiddleDistanceDisciplines, middleDistanceDisciplines);
        }

        void LoadAllTraditionalDisciplines()
        {
            ClearAndFill(MaleSprintDisciplines, Honglorn.FilteredTraditionalDisciplines(DisciplineType.Sprint, Sex.Male));
            ClearAndFill(MaleJumpDisciplines, Honglorn.FilteredTraditionalDisciplines(DisciplineType.Jump, Sex.Male));
            ClearAndFill(MaleThrowDisciplines, Honglorn.FilteredTraditionalDisciplines(DisciplineType.Throw, Sex.Male));
            ClearAndFill(MaleMiddleDistanceDisciplines, Honglorn.FilteredTraditionalDisciplines(DisciplineType.MiddleDistance, Sex.Male));

            ClearAndFill(FemaleSprintDisciplines, Honglorn.FilteredTraditionalDisciplines(DisciplineType.Sprint, Sex.Female));
            ClearAndFill(FemaleJumpDisciplines, Honglorn.FilteredTraditionalDisciplines(DisciplineType.Jump, Sex.Female));
            ClearAndFill(FemaleThrowDisciplines, Honglorn.FilteredTraditionalDisciplines(DisciplineType.Throw, Sex.Female));
            ClearAndFill(FemaleMiddleDistanceDisciplines, Honglorn.FilteredTraditionalDisciplines(DisciplineType.MiddleDistance, Sex.Female));
        }

        void SelectSavedDisiciplines()
        {
            IDisciplineCollection disciplineCollection = Honglorn.AssignedDisciplines(CurrentClass, CurrentYear);

            if (disciplineCollection == null)
            {
                SetSelectedDisciplinesToNull();
            }
            else
            {
                CurrentMaleSprintDiscipline = MaleSprintDisciplines.SingleOrDefault(d => d.PKey == disciplineCollection.MaleSprintPKey);
                CurrentMaleJumpDiscipline = MaleJumpDisciplines.SingleOrDefault(d => d.PKey == disciplineCollection.MaleJumpPKey);
                CurrentMaleThrowDiscipline = MaleThrowDisciplines.SingleOrDefault(d => d.PKey == disciplineCollection.MaleThrowPKey);
                CurrentMaleMiddleDistanceDiscipline = MaleMiddleDistanceDisciplines.SingleOrDefault(d => d.PKey == disciplineCollection.MaleMiddleDistancePKey);

                CurrentFemaleSprintDiscipline = FemaleSprintDisciplines.SingleOrDefault(d => d.PKey == disciplineCollection.FemaleSprintPKey);
                CurrentFemaleJumpDiscipline = FemaleJumpDisciplines.SingleOrDefault(d => d.PKey == disciplineCollection.FemaleJumpPKey);
                CurrentFemaleThrowDiscipline = FemaleThrowDisciplines.SingleOrDefault(d => d.PKey == disciplineCollection.FemaleThrowPKey);
                CurrentFemaleMiddleDistanceDiscipline = FemaleMiddleDistanceDisciplines.SingleOrDefault(d => d.PKey == disciplineCollection.FemaleMiddleDistancePKey);
            }
        }

        void SetSelectedDisciplinesToNull()
        {
            CurrentMaleSprintDiscipline = null;
            CurrentMaleJumpDiscipline = null;
            CurrentMaleThrowDiscipline = null;
            CurrentMaleMiddleDistanceDiscipline = null;

            CurrentFemaleSprintDiscipline = null;
            CurrentFemaleJumpDiscipline = null;
            CurrentFemaleThrowDiscipline = null;
            CurrentFemaleMiddleDistanceDiscipline = null;
        }

        public AssignDisciplinesViewModel()
        {
            SaveDisciplineCollectionCommand = new RelayCommand(SaveDisciplineCollection);

            LoadYears();
            if (Years.Any())
            {
                CurrentYear = Years.First();
            }
        }

        void SaveDisciplineCollection()
        {
            Honglorn.CreateOrUpdateDisciplineCollection(CurrentClass, CurrentYear, CurrentMaleSprintDiscipline.PKey, CurrentMaleJumpDiscipline.PKey, CurrentMaleThrowDiscipline.PKey, CurrentMaleMiddleDistanceDiscipline.PKey, CurrentFemaleSprintDiscipline.PKey, CurrentFemaleJumpDiscipline.PKey, CurrentFemaleThrowDiscipline.PKey, CurrentFemaleMiddleDistanceDiscipline.PKey);
        }
    }
}
