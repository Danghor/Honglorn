using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using HonglornBL;
using HonglornBL.Models.Entities;
using static HonglornBL.Prerequisites;
using static HonglornBL.Honglorn;

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
        public ObservableCollection<Discipline> MaleSprintDisciplines { get; } = new ObservableCollection<Discipline>();
        public ObservableCollection<Discipline> MaleJumpDisciplines { get; } = new ObservableCollection<Discipline>();
        public ObservableCollection<Discipline> MaleThrowDisciplines { get; } = new ObservableCollection<Discipline>();
        public ObservableCollection<Discipline> MaleMiddleDistanceDisciplines { get; } = new ObservableCollection<Discipline>();
        public ObservableCollection<Discipline> FemaleSprintDisciplines { get; } = new ObservableCollection<Discipline>();
        public ObservableCollection<Discipline> FemaleJumpDisciplines { get; } = new ObservableCollection<Discipline>();
        public ObservableCollection<Discipline> FemaleThrowDisciplines { get; } = new ObservableCollection<Discipline>();
        public ObservableCollection<Discipline> FemaleMiddleDistanceDisciplines { get; } = new ObservableCollection<Discipline>();

        public RelayCommand SaveDisciplineCollectionCommand { get; }

        short currentYear;
        public short CurrentYear
        {
            get { return currentYear; }

            set
            {
                OnPropertyChanged(ref currentYear, value);

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
                OnPropertyChanged(ref currentClass, value);

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
                OnPropertyChanged(ref game, value);

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

        Discipline currentMaleSprintDiscipline;
        public Discipline CurrentMaleSprintDiscipline
        {
            get { return currentMaleSprintDiscipline; }
            set { OnPropertyChanged(ref currentMaleSprintDiscipline, value); }
        }

        Discipline currentMaleJumpDiscipline;
        public Discipline CurrentMaleJumpDiscipline
        {
            get { return currentMaleJumpDiscipline; }
            set { OnPropertyChanged(ref currentMaleJumpDiscipline, value); }
        }

        Discipline currentMaleThrowDiscipline;
        public Discipline CurrentMaleThrowDiscipline
        {
            get { return currentMaleThrowDiscipline; }
            set { OnPropertyChanged(ref currentMaleThrowDiscipline, value); }
        }

        Discipline currentMaleMiddleDistanceDiscipline;
        public Discipline CurrentMaleMiddleDistanceDiscipline
        {
            get { return currentMaleMiddleDistanceDiscipline; }
            set { OnPropertyChanged(ref currentMaleMiddleDistanceDiscipline, value); }
        }

        Discipline currentFemaleSprintDiscipline;
        public Discipline CurrentFemaleSprintDiscipline
        {
            get { return currentFemaleSprintDiscipline; }
            set { OnPropertyChanged(ref currentFemaleSprintDiscipline, value); }
        }

        Discipline currentFemaleJumpDiscipline;
        public Discipline CurrentFemaleJumpDiscipline
        {
            get { return currentFemaleJumpDiscipline; }
            set { OnPropertyChanged(ref currentFemaleJumpDiscipline, value); }
        }

        Discipline currentFemaleThrowDiscipline;
        public Discipline CurrentFemaleThrowDiscipline
        {
            get { return currentFemaleThrowDiscipline; }
            set { OnPropertyChanged(ref currentFemaleThrowDiscipline, value); }
        }

        Discipline currentFemaleMiddleDistanceDiscipline;
        public Discipline CurrentFemaleMiddleDistanceDiscipline
        {
            get { return currentFemaleMiddleDistanceDiscipline; }
            set { OnPropertyChanged(ref currentFemaleMiddleDistanceDiscipline, value); }
        }

        void LoadClassNames() => ClearAndFill(Classes, ValidClassNames(CurrentYear));

        void LoadYears() => ClearAndFill(Years, YearsWithStudentData());

        void LoadAllCompetitionDisciplines()
        {
            ClearAndFill(MaleSprintDisciplines, FilteredCompetitionDisciplines(DisciplineType.Sprint));
            ClearAndFill(MaleJumpDisciplines, FilteredCompetitionDisciplines(DisciplineType.Jump));
            ClearAndFill(MaleThrowDisciplines, FilteredCompetitionDisciplines(DisciplineType.Throw));
            ClearAndFill(MaleMiddleDistanceDisciplines, FilteredCompetitionDisciplines(DisciplineType.MiddleDistance));

            ClearAndFill(FemaleSprintDisciplines, FilteredCompetitionDisciplines(DisciplineType.Sprint));
            ClearAndFill(FemaleJumpDisciplines, FilteredCompetitionDisciplines(DisciplineType.Jump));
            ClearAndFill(FemaleThrowDisciplines, FilteredCompetitionDisciplines(DisciplineType.Throw));
            ClearAndFill(FemaleMiddleDistanceDisciplines, FilteredCompetitionDisciplines(DisciplineType.MiddleDistance));
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
