using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static HonglornBL.Prerequisites;

namespace HonglornWPF.ViewModels
{
    class AssignDisciplinesViewModel : ViewModel
    {
        IDictionary<Game?, RadioButtonGame> GameTypeMap = new Dictionary<Game?, RadioButtonGame>
        {
            { HonglornBL.Prerequisites.Game.Traditional, RadioButtonGame.Traditional },
            { HonglornBL.Prerequisites.Game.Competition, RadioButtonGame.Competition },
        };

        public ObservableCollection<string> Classes { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<short> Years { get; set; } = new ObservableCollection<short>();

        string currentClass;
        short currentYear;
        RadioButtonGame game;

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

                Game? gameFromDb = HonglornBL.Honglorn.GetGameType(CurrentClass, CurrentYear);
                if(gameFromDb == null)
                {
                    Game = RadioButtonGame.Unknown;
                }
                else
                {
                    Game = GameTypeMap[gameFromDb];
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
            }
        }

        void LoadClassNames() => ClearAndFill(Classes, HonglornBL.Honglorn.ValidClassNames(CurrentYear));

        void LoadYears() => ClearAndFill(Years, HonglornBL.Honglorn.YearsWithStudentData());

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
