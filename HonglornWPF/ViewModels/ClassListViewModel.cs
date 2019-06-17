using HonglornBL.MasterData.Class;

namespace HonglornWPF.ViewModels
{
    class ClassListViewModel : ListViewModel<ClassManager, ClassDetailViewModel, IClassModel>
    {
        public ClassListViewModel()
        {
            DetailViewModel = new ClassDetailViewModel(() => DetailViewIsVisible = false);

            service = Honglorn.ClassService();

            RefreshViewModel();
        }

        public override string ToString() => "Classes";
    }
}