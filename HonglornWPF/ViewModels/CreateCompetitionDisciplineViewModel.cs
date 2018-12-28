using HonglornBL.Models.Entities;
using System;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    class CreateCompetitionDisciplineViewModel : ViewModel
    {
        public CompetitionDiscipline CurrentDiscipline { get; }
        public ICommand AcceptCommand { get; }
        public ICommand AbortCommand { get; }

        public CreateCompetitionDisciplineViewModel(Action<CreateCompetitionDisciplineViewModel> acceptHandle, Action<CreateCompetitionDisciplineViewModel> abortHandle, CompetitionDiscipline discipline = null)
        {
            AcceptCommand = new RelayCommand(() => acceptHandle(this));
            AbortCommand = new RelayCommand(() => abortHandle(this));

            CurrentDiscipline = discipline ?? new CompetitionDiscipline();
        }
    }
}