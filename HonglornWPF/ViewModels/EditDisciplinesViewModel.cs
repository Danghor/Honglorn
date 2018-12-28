using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HonglornBL.Enums;
using HonglornBL.Models.Entities;
using HonglornWPF.Views;
using MahApps.Metro.Controls.Dialogs;

namespace HonglornWPF.ViewModels
{
    class EditDisciplinesViewModel : ViewModel
    {
        public ObservableCollection<CompetitionDiscipline> Disciplines { get; } = new ObservableCollection<CompetitionDiscipline>();

        public ICommand ShowCreateCompetitionDisciplineViewCommand { get; }
        public ICommand EditDisciplineCommand { get; }
        public ICommand DeleteDisciplineCommand { get; }

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
            EditDisciplineCommand = new RelayCommand(EditDiscipline);
            DeleteDisciplineCommand = new RelayCommand(DeleteDiscipline);
            LoadDisciplines();
        }

        async void ShowCreateCompetitionDisciplineView()
        {
            var customDialog = new CustomDialog();

            var dialogViewModel = new CreateCompetitionDisciplineViewModel(instance =>
            {
                CreateDiscipline(instance.CurrentDiscipline.Type, instance.CurrentDiscipline.Name, instance.CurrentDiscipline.Unit, instance.CurrentDiscipline.LowIsBetter);
                dialogCoordinator.HideMetroDialogAsync(this, customDialog);
            },
            instance =>
            {
                dialogCoordinator.HideMetroDialogAsync(this, customDialog);
            });

            customDialog.Content = new CreateCompetitionDisciplineView
            {
                DataContext = dialogViewModel
            };

            await dialogCoordinator.ShowMetroDialogAsync(this, customDialog);
        }

        async void EditDiscipline()
        {
            var customDialog = new CustomDialog();

            var dialogViewModel = new CreateCompetitionDisciplineViewModel(instance =>
            {
                UpdateDiscipline(instance.CurrentDiscipline.Type, instance.CurrentDiscipline.Name, instance.CurrentDiscipline.Unit, instance.CurrentDiscipline.LowIsBetter);
                dialogCoordinator.HideMetroDialogAsync(this, customDialog);
            },
            instance =>
            {
                dialogCoordinator.HideMetroDialogAsync(this, customDialog);
            }, CurrentDiscipline.Clone());

            customDialog.Content = new CreateCompetitionDisciplineView
            {
                DataContext = dialogViewModel
            };

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

        void DeleteDiscipline()
        {
            if (currentDiscipline != null)
            {
                Honglorn.DeleteCompetitionDiscipline(currentDiscipline.PKey);
                LoadDisciplines();
            }
        }

        void CreateDiscipline(DisciplineType type, string name, string unit, bool lowIsBetter)
        {
            Honglorn.CreateCompetitionDiscipline(type, name, unit, lowIsBetter);
            LoadDisciplines();
        }

        void UpdateDiscipline(DisciplineType type, string name, string unit, bool lowIsBetter)
        {
            Honglorn.UpdateCompetitionDiscipline(CurrentDiscipline.PKey, type, name, unit, lowIsBetter);
            LoadDisciplines();
        }
    }
}