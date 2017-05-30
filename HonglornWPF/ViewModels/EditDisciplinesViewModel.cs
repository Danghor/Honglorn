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
        public ObservableCollection<DisciplineType> DisciplineTypes { get; set; } = new ObservableCollection<DisciplineType>();
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
            LoadDisciplineTypes();
        }

        void LoadDisciplines() => ClearAndFill(Disciplines, HonglornBL.Honglorn.AllCompetitionDisciplines());
        void LoadDisciplineTypes() => ClearAndFill(DisciplineTypes, HonglornBL.Honglorn.DisciplineTypes());

        static void SaveDiscipline(CompetitionDiscipline discipline)
        {
            if (discipline != null)
            {
                HonglornBL.Honglorn.CreateOrUpdateCompetitionDiscipline(discipline.PKey, discipline.Type, discipline.Name, discipline.Unit, discipline.LowIsBetter);
            }
        }
    }
}
