using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HonglornBL.Models.Entities;
using HonglornWPF.Views;
using MahApps.Metro.Controls.Dialogs;

namespace HonglornWPF.ViewModels
{
    class EditDisciplinesViewModel : ViewModel
    {
        public ObservableCollection<CompetitionDiscipline> Disciplines { get; } = new ObservableCollection<CompetitionDiscipline>();

        public ICommand ShowCreateCompetitionDisciplineViewCommand { get; }

        readonly IDialogCoordinator dialogCoordinator;

        CompetitionDiscipline currentDiscipline;
        public CompetitionDiscipline CurrentDiscipline
        {
            get { return currentDiscipline; }
            set { OnPropertyChanged(out currentDiscipline, value); }
        }

        public EditDisciplinesViewModel(IDialogCoordinator dialogCoordinator)
        {
            this.dialogCoordinator = dialogCoordinator;
            ShowCreateCompetitionDisciplineViewCommand = new RelayCommand(ShowCreateCompetitionDisciplineView);
            LoadDisciplines();
        }

        async void ShowCreateCompetitionDisciplineView()
        {
            var customDialog = new CustomDialog
            {
                Title = "Custom Dialog",
                Content = new CreateCompetitionDisciplineView()
            };

            //var customDialogExampleContent = new CustomDialogExampleContent(instance =>
            //{
            //    _dialogCoordinator.HideMetroDialogAsync(this, customDialog);
            //    System.Diagnostics.Debug.WriteLine(instance.FirstName);
            //});

            await dialogCoordinator.ShowMetroDialogAsync(this, customDialog);
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
