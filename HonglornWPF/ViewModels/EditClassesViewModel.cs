using HonglornBL.Models.Entities;
using System.Collections.ObjectModel;
using MahApps.Metro.Controls.Dialogs;

namespace HonglornWPF.ViewModels
{
    class EditClassesViewModel : ViewModel
    {
        readonly IDialogCoordinator dialogCoordinator;

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
            LoadClasses();
        }

        void LoadClasses() => ClearAndFill(Classes, Honglorn.AllClasses());
    }
}