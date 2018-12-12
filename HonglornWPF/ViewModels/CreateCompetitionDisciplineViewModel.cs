using System;
using System.Windows.Input;
using HonglornBL.Enums;

namespace HonglornWPF.ViewModels
{
    class CreateCompetitionDisciplineViewModel : ViewModel
    {
        public ICommand CloseCommand { get; }

        string name;
        public string Name
        {
            get { return name; }
            set { OnPropertyChanged(out name, value); }
        }

        DisciplineType type;
        DisciplineType Type
        {
            get { return type; }
            set { OnPropertyChanged(out type, value); }
        }

        string unit;
        public string Unit
        {
            get { return unit; }
            set { OnPropertyChanged(out unit, value); }
        }

        bool lowIsBetter;
        public bool LowIsBetter
        {
            get { return lowIsBetter; }
            set { OnPropertyChanged(out lowIsBetter, value); }
        }

        public CreateCompetitionDisciplineViewModel(Action<CreateCompetitionDisciplineViewModel> closeHandler)
        {
            CloseCommand = new RelayCommand(() => closeHandler(this));
        }
    }
}
