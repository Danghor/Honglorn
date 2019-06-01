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
    }
}