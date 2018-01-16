using System.Collections.Generic;
using System.Collections.ObjectModel;
using HonglornBL.Models.Entities;

namespace HonglornWPF.ViewModels
{
    class EditDisciplinesViewModel : ViewModel
    {
        public ObservableCollection<CompetitionDiscipline> Disciplines { get; set; } = new ObservableCollection<CompetitionDiscipline>();

        CompetitionDiscipline currentDiscipline;

        public CompetitionDiscipline CurrentDiscipline
        {
            get { return currentDiscipline; }
            set
            {
                SaveDiscipline(currentDiscipline);
                currentDiscipline = value;
                OnPropertyChanged(nameof(CurrentDiscipline));
            }
        }

        public EditDisciplinesViewModel()
        {
            LoadDisciplines();
        }

        void LoadDisciplines() => ClearAndFill(Disciplines, HonglornBL.Honglorn.AllCompetitionDisciplines());

        static void SaveDiscipline(CompetitionDiscipline discipline)
        {
            if (discipline != null)
            {
                HonglornBL.Honglorn.CreateOrUpdateCompetitionDiscipline(discipline.PKey, discipline.Type, discipline.Name, discipline.Unit, discipline.LowIsBetter);
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
