using HonglornBL;

namespace HonglornWPF.ViewModels
{
    class ClassListViewModel : ListViewModel<ClassService, ClassManager, ClassDetailViewModel>
    {
        bool detailViewIsVisible;

        public bool DetailViewIsVisible
        {
            get => detailViewIsVisible;
            set => OnPropertyChanged(out detailViewIsVisible, value);
        }

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