using System;
using System.Windows.Input;
using HonglornBL.Enums;

namespace HonglornWPF.ViewModels
{
    class CreateCompetitionDisciplineViewModel : ViewModel
    {
        public ICommand AcceptCommand { get; }
        public ICommand AbortCommand { get; }

        string name;
        public string Name
        {
            get { return name; }
            set { OnPropertyChanged(out name, value); }
        }

        DisciplineType type;
        public DisciplineType Type
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

        public CreateCompetitionDisciplineViewModel(Action<CreateCompetitionDisciplineViewModel> acceptHandle, Action<CreateCompetitionDisciplineViewModel> abortHandle)
        {
            AcceptCommand = new RelayCommand(() => acceptHandle(this));
            AbortCommand = new RelayCommand(() => abortHandle(this));
        }
    }
}
