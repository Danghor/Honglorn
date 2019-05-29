using HonglornBL;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    class ClassListViewModel : ListViewModel<ClassService, ClassManager>
    {
        bool detailViewIsVisible;

        public bool DetailViewIsVisible
        {
            get => detailViewIsVisible;
            set => OnPropertyChanged(out detailViewIsVisible, value);
        }

        ClassDetailViewModel detailViewModel;

        public ClassDetailViewModel DetailViewModel
        {
            get => detailViewModel;
            set => OnPropertyChanged(out detailViewModel, value);
        }

        public ICommand NewCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public ClassListViewModel()
        {
            NewCommand = new RelayCommand(New);
            EditCommand = new RelayCommand(Edit);
            DeleteCommand = new RelayCommand(Delete);

            DetailViewModel = new ClassDetailViewModel(new RelayCommand(() => DetailViewIsVisible = false));

            service = Honglorn.ClassService();

            Refresh();
        }

        void New()
        {
            DetailViewModel.Clear();
            DetailViewModel.AcceptCommand = new RelayCommand(() => { CreateNewClass(); DetailViewIsVisible = false; });

            DetailViewIsVisible = true;
        }

        void Edit()
        {
            DetailViewModel.CopyValues(CurrentManager);
            DetailViewModel.AcceptCommand = new RelayCommand(() => { EditClass(); DetailViewIsVisible = false; });

            DetailViewIsVisible = true;
        }

        void Delete()
        {
            service.Delete(CurrentManager);
            Refresh();
        }

        void Refresh()
        {
            var classManagers = service.GetManagers();
            ClearAndFill(ClassManagers, classManagers);
        }

        void CreateNewClass()
        {
            service.Create(DetailViewModel);
            Refresh();
        }

        void EditClass()
        {
            CurrentManager.Update(DetailViewModel);
            Refresh();
        }
    }
}