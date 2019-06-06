using HonglornBL.MasterData.StudentHandicap;

namespace HonglornWPF.ViewModels
{
    class StudentHandicapListViewModel : ListViewModel<StudentHandicapManager, StudentHandicapDetailViewModel, IStudentHandicapModel>
    {
        public StudentHandicapListViewModel()
        {
            DetailViewModel = new StudentHandicapDetailViewModel(() => DetailViewIsVisible = false);

            service = Honglorn.StudentHandicapService();

            RefreshViewModel();
        }

        public override string ToString() => "Student Handicaps";
    }
}