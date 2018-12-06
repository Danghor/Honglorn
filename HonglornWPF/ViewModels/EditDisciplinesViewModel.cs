using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HonglornBL.Models.Entities;

namespace HonglornWPF.ViewModels
{
    class EditDisciplinesViewModel : ViewModel
    {
        public ObservableCollection<CompetitionDiscipline> Disciplines { get; } = new ObservableCollection<CompetitionDiscipline>();

        public ICommand ShowCreateCompetitionDisciplineViewCommand { get; }

        CompetitionDiscipline currentDiscipline;
        public CompetitionDiscipline CurrentDiscipline
        {
            get { return currentDiscipline; }
            set { OnPropertyChanged(out currentDiscipline, value); }
        }

        public EditDisciplinesViewModel()
        {
            ShowCreateCompetitionDisciplineViewCommand = new RelayCommand(ShowCreateCompetitionDisciplineView);
            LoadDisciplines();
        }

        void ShowCreateCompetitionDisciplineView()
        {
            throw new NotImplementedException();
        }

        void LoadDisciplines() => ClearAndFill(Disciplines, Honglorn.AllCompetitionDisciplines());

        void SaveDiscipline(CompetitionDiscipline discipline)
        {
            if (discipline != null)
            {
                Honglorn.UpdateCompetitionDiscipline(discipline.PKey, discipline.Type, discipline.Name, discipline.Unit, discipline.LowIsBetter);
            }
        }
    }

    public class DisciplineTypesList : List<string>
    {
        public DisciplineTypesList()
        {
            AddRange(new[] { "Sprint", "Jump", "Throw", "MiddleDistance" });
        }
    }
}
