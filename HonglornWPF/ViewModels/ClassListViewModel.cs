using HonglornBL;
using HonglornBL.Interfaces;

namespace HonglornWPF.ViewModels
{
    class ClassListViewModel : ListViewModel<ClassManager, ClassDetailViewModel, IClassModel>
    {
        public ClassListViewModel()
        {
            NewCommand = new RelayCommand(OpenDetailViewForCreate);
            EditCommand = new RelayCommand(OpenDetailViewForEdit);
            DeleteCommand = new RelayCommand(Delete);

            DetailViewModel = new ClassDetailViewModel(() => DetailViewIsVisible = false);

            service = Honglorn.ClassService();

            RefreshViewModel();
        }

        void OpenDetailViewForCreate()
        {
            DetailViewModel.Clear();
            DetailViewModel.AcceptCommand = new RelayCommand(() => { Create(); DetailViewIsVisible = false; });

            DetailViewIsVisible = true;
        }

        void OpenDetailViewForEdit()
        {
            DetailViewModel.CopyValues(CurrentManager);
            DetailViewModel.AcceptCommand = new RelayCommand(() => { Update(); DetailViewIsVisible = false; });

            DetailViewIsVisible = true;
        }
    }
}