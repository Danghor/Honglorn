using HonglornBL.MasterData.Student;

namespace HonglornWPF.ViewModels
{
    class StudentListViewModel : ListViewModel<StudentManager, StudentDetailViewModel, IStudentModel>
    {
        public StudentListViewModel()
        {
            DetailViewModel = new StudentDetailViewModel(() => DetailViewIsVisible = false);

            service = Honglorn.StudentService();

            RefreshViewModel();
        }

        public override string ToString() => "Students";
    }
}