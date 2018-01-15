using HonglornBL.Models.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using static HonglornBL.Prerequisites;
using static HonglornBL.Honglorn;

namespace HonglornWPF.ViewModels
{
    class AssignDisciplinesViewModel : ViewModel
    {
        readonly IDictionary<Game?, RadioButtonGame> gameTypeMap = new Dictionary<Game?, RadioButtonGame>
        {
            { HonglornBL.Prerequisites.Game.Traditional, RadioButtonGame.Traditional },
            { HonglornBL.Prerequisites.Game.Competition, RadioButtonGame.Competition }
        };

        public ObservableCollection<string> Classes { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<short> Years { get; set; } = new ObservableCollection<short>();
        public ObservableCollection<Discipline> MaleSprintDisciplines { get; set; } = new ObservableCollection<Discipline>();
        public ObservableCollection<Discipline> MaleJumpDisciplines { get; set; } = new ObservableCollection<Discipline>();
        public ObservableCollection<Discipline> MaleThrowDisciplines { get; set; } = new ObservableCollection<Discipline>();
        public ObservableCollection<Discipline> MaleMiddleDistanceDisciplines { get; set; } = new ObservableCollection<Discipline>();
        public ObservableCollection<Discipline> FemaleSprintDisciplines { get; set; } = new ObservableCollection<Discipline>();
        public ObservableCollection<Discipline> FemaleJumpDisciplines { get; set; } = new ObservableCollection<Discipline>();
        public ObservableCollection<Discipline> FemaleThrowDisciplines { get; set; } = new ObservableCollection<Discipline>();
        public ObservableCollection<Discipline> FemaleMiddleDistanceDisciplines { get; set; } = new ObservableCollection<Discipline>();

        string currentClass;
        short currentYear;
        RadioButtonGame game;
        Discipline currentMaleSprintDiscipline;
        Discipline currentMaleJumpDiscipline;
        Discipline currentMaleThrowDiscipline;
        Discipline currentMaleMiddleDistanceDiscipline;
        Discipline currentFemaleSprintDiscipline;
        Discipline currentFemaleJumpDiscipline;
        Discipline currentFemaleThrowDiscipline;
        Discipline currentFemaleMiddleDistanceDiscipline;

        public short CurrentYear
        {
            get { return currentYear; }

            set
            {
                currentYear = value;
                OnPropertyChanged(nameof(CurrentYear));

                string previouslySelectedClass = CurrentClass;

                LoadClassNames();

                int courseIndex = Classes.IndexOf(previouslySelectedClass);
                CurrentClass = courseIndex != -1 ? previouslySelectedClass : Classes.FirstOrDefault();
            }
        }

        public string CurrentClass
        {
            get { return currentClass; }
            set
            {
                currentClass = value;
                OnPropertyChanged(nameof(CurrentClass));

                Game? gameFromDb = GetGameType(CurrentClass, CurrentYear);
                if (gameFromDb == null)
                {
                    Game = RadioButtonGame.Unknown;
                }
                else
                {
                    Game = gameTypeMap[gameFromDb];
                }
            }
        }

        public RadioButtonGame Game
        {
            get { return game; }
            set
            {
                game = value;
                OnPropertyChanged(nameof(Game));

                if (value == RadioButtonGame.Traditional)
                {
                    LoadAllTraditionalDisciplines();
                }
                else if (value == RadioButtonGame.Competition)
                {
                    LoadAllCompetitionDisciplines();
                }

            }
        }

        public Discipline CurrentMaleSprintDiscipline
        {
            get { return currentMaleSprintDiscipline; }
            set
            {
                currentMaleSprintDiscipline = value;
                OnPropertyChanged(nameof(CurrentMaleSprintDiscipline));
            }
        }

        public Discipline CurrentMaleJumpDiscipline
        {
            get { return currentMaleJumpDiscipline; }
            set
            {
                currentMaleJumpDiscipline = value;
                OnPropertyChanged(nameof(CurrentMaleJumpDiscipline));
            }
        }

        public Discipline CurrentMaleThrowDiscipline
        {
            get { return currentMaleThrowDiscipline; }
            set
            {
                currentMaleThrowDiscipline = value;
                OnPropertyChanged(nameof(CurrentMaleThrowDiscipline));
            }
        }

        public Discipline CurrentMaleMiddleDistanceDiscipline
        {
            get { return currentMaleMiddleDistanceDiscipline; }
            set
            {
                currentMaleMiddleDistanceDiscipline = value;
                OnPropertyChanged(nameof(CurrentMaleMiddleDistanceDiscipline));
            }
        }

        public Discipline CurrentFemaleSprintDiscipline
        {
            get { return currentFemaleSprintDiscipline; }
            set
            {
                currentFemaleSprintDiscipline = value;
                OnPropertyChanged(nameof(CurrentFemaleSprintDiscipline));
            }
        }

        public Discipline CurrentFemaleJumpDiscipline
        {
            get { return currentFemaleJumpDiscipline; }
            set
            {
                currentFemaleJumpDiscipline = value;
                OnPropertyChanged(nameof(CurrentFemaleJumpDiscipline));
            }
        }

        public Discipline CurrentFemaleThrowDiscipline
        {
            get { return currentFemaleThrowDiscipline; }
            set
            {
                currentFemaleThrowDiscipline = value;
                OnPropertyChanged(nameof(CurrentFemaleThrowDiscipline));
            }
        }

        public Discipline CurrentFemaleMiddleDistanceDiscipline
        {
            get { return currentFemaleMiddleDistanceDiscipline; }
            set
            {
                currentFemaleMiddleDistanceDiscipline = value;
                OnPropertyChanged(nameof(CurrentFemaleMiddleDistanceDiscipline));
            }
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
            LoadYears();
            if (Years.Any())
            {
                CurrentYear = Years.First();
            }
        }
    }

    public enum RadioButtonGame
    {
        Traditional,
        Competition,
        Unknown
    }
}
