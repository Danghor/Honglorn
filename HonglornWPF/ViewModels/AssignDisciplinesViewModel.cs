using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using HonglornBL;
using HonglornBL.Interfaces;
using static HonglornBL.Honglorn;
using static HonglornBL.Prerequisites;

namespace HonglornWPF.ViewModels
{
    class AssignDisciplinesViewModel : ViewModel
    {
        readonly IDictionary<Game?, RadioButtonGame> gameTypeMap = new Dictionary<Game?, RadioButtonGame>
        {
            { Prerequisites.Game.Traditional, RadioButtonGame.Traditional },
            { Prerequisites.Game.Competition, RadioButtonGame.Competition }
        };

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

                int courseIndex = Classes.IndexOf(previouslySelectedClass);
                CurrentClass = courseIndex != -1 ? previouslySelectedClass : Classes.FirstOrDefault();
            }
        }

        string currentClass;
        public string CurrentClass
        {
            get { return currentClass; }
            set
            {
                OnPropertyChanged(out currentClass, value);

                Game? gameFromDb = GetGameType(CurrentClass, CurrentYear);
                Game = gameFromDb == null ? RadioButtonGame.Unknown : gameTypeMap[gameFromDb];
            }
        }

        RadioButtonGame game;
        public RadioButtonGame Game
        {
            get { return game; }
            set
            {
                OnPropertyChanged(out game, value);

                switch (value)
                {
                    case RadioButtonGame.Traditional:
                        LoadAllTraditionalDisciplines();
                        break;
                    case RadioButtonGame.Competition:
                        LoadAllCompetitionDisciplines();
                        break;
                    case RadioButtonGame.Unknown:
                        break;
                    default:
                        throw new InvalidEnumArgumentException(nameof(value), (int)value, typeof(RadioButtonGame));
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
            ClearAndFill(Classes, ValidClassNames(CurrentYear));
        }

        void LoadYears()
        {
            ClearAndFill(Years, YearsWithStudentData());
        }

        void LoadAllCompetitionDisciplines()
        {
            ICollection<IDiscipline> sprintDisciplines = FilteredCompetitionDisciplines(DisciplineType.Sprint);
            ICollection<IDiscipline> jumpDisciplines = FilteredCompetitionDisciplines(DisciplineType.Jump);
            ICollection<IDiscipline> throwDisciplines = FilteredCompetitionDisciplines(DisciplineType.Throw);
            ICollection<IDiscipline> middleDistanceDisciplines = FilteredCompetitionDisciplines(DisciplineType.MiddleDistance);

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
            ClearAndFill(MaleSprintDisciplines, FilteredTraditionalDisciplines(DisciplineType.Sprint, Sex.Male));
            ClearAndFill(MaleJumpDisciplines, FilteredTraditionalDisciplines(DisciplineType.Jump, Sex.Male));
            ClearAndFill(MaleThrowDisciplines, FilteredTraditionalDisciplines(DisciplineType.Throw, Sex.Male));
            ClearAndFill(MaleMiddleDistanceDisciplines, FilteredTraditionalDisciplines(DisciplineType.MiddleDistance, Sex.Male));

            ClearAndFill(FemaleSprintDisciplines, FilteredTraditionalDisciplines(DisciplineType.Sprint, Sex.Female));
            ClearAndFill(FemaleJumpDisciplines, FilteredTraditionalDisciplines(DisciplineType.Jump, Sex.Female));
            ClearAndFill(FemaleThrowDisciplines, FilteredTraditionalDisciplines(DisciplineType.Throw, Sex.Female));
            ClearAndFill(FemaleMiddleDistanceDisciplines, FilteredTraditionalDisciplines(DisciplineType.MiddleDistance, Sex.Female));
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
            CreateOrUpdateDisciplineCollection(CurrentClass, CurrentYear, CurrentMaleSprintDiscipline.PKey, CurrentMaleJumpDiscipline.PKey, CurrentMaleThrowDiscipline.PKey, CurrentMaleMiddleDistanceDiscipline.PKey, CurrentFemaleSprintDiscipline.PKey, CurrentFemaleJumpDiscipline.PKey, CurrentFemaleThrowDiscipline.PKey, CurrentFemaleMiddleDistanceDiscipline.PKey);
        }
    }

    public enum RadioButtonGame
    {
        Traditional,
        Competition,
        Unknown
    }
}
