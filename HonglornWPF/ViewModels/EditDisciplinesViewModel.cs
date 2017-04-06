using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using HonglornBL.Models.Entities;
using static HonglornBL.Prerequisites;

namespace HonglornWPF.ViewModels
{
    class EditDisciplinesViewModel : ViewModel
    {
        public static DisciplineType[] DisciplineTypes { get; } = (DisciplineType[]) Enum.GetValues(typeof(DisciplineType));
        public ObservableCollection<CompetitionDiscipline> Disciplines { get; set; } = new ObservableCollection<CompetitionDiscipline>();

        public CompetitionDiscipline currentDiscipline;

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
}
