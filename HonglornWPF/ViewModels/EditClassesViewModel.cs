using HonglornBL.Models.Entities;
using System.Collections.ObjectModel;
using MahApps.Metro.Controls.Dialogs;
using System.Windows.Input;
using HonglornWPF.Views;
using MahApps.Metro.Controls;
using System;

namespace HonglornWPF.ViewModels
{
    class EditClassesViewModel : ViewModel
    {
        readonly IDialogCoordinator dialogCoordinator;

        public ICommand ShowCreateClassViewCommand { get; }
        public ICommand EditClassCommand { get; }
        public ICommand DeleteClassCommand { get; }

        public ObservableCollection<Class> Classes { get; } = new ObservableCollection<Class>();

        Class currentClass;
        public Class CurrentClass
        {
            get => currentClass;
            set => OnPropertyChanged(out currentClass, value);
        }

        public EditClassesViewModel(IDialogCoordinator dialogCoordinator)
        {
            this.dialogCoordinator = dialogCoordinator;
            ShowCreateClassViewCommand = new RelayCommand(ShowCreateClassView);
            EditClassCommand = new RelayCommand(EditClass);
            DeleteClassCommand = new RelayCommand(DeleteClass);
            LoadClasses();
        }

        void LoadClasses() => ClearAndFill(Classes, Honglorn.AllClasses());

        async void ShowCreateClassView()
        {
            var customDialog = new CustomDialog();

            var dialogViewModel = new CreateClassViewModel(instance =>
            {
                CreateClass(instance.CurrentClass.Name);
                dialogCoordinator.HideMetroDialogAsync(this, customDialog);
            },
            instance => dialogCoordinator.HideMetroDialogAsync(this, customDialog));

            customDialog.Content = new CreateClassView
            {
                DataContext = dialogViewModel
            };

            await dialogCoordinator.ShowMetroDialogAsync(this, customDialog);
        }

        async void EditClass()
        {
            var customDialog = new CustomDialog();

            var dialogViewModel = new CreateClassViewModel(instance =>
            {
                UpdateClass(instance.CurrentClass.Name);
                dialogCoordinator.HideMetroDialogAsync(this, customDialog);
            },
            instance =>
            {
                dialogCoordinator.HideMetroDialogAsync(this, customDialog);
            }, CurrentClass.Clone());

            customDialog.Content = new CreateClassView
            {
                DataContext = dialogViewModel
            };

            await dialogCoordinator.ShowMetroDialogAsync(this, customDialog);
        }

        void DeleteClass()
        {
            Honglorn.DeleteClass(currentClass.PKey);
            LoadClasses();
        }

        void CreateClass(string className)
        {
            Honglorn.CreateClass(className);
            LoadClasses();
        }

        void UpdateClass(string className)
        {
            try
            {
                Honglorn.UpdateClass(CurrentClass.PKey, className);
                LoadClasses();
            }
            catch (Exception ex)
            {
                var mainWindow = (MetroWindow)System.Windows.Application.Current.MainWindow;
                mainWindow.ShowMessageAsync("Error", ex.Message);
            }
        }
    }
}