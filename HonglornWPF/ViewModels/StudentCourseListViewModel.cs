using HonglornBL.MasterData.StudentCourse;

namespace HonglornWPF.ViewModels
{
    class StudentCourseListViewModel : ListViewModel<StudentCourseManager, StudentCourseDetailViewModel, IStudentCourseModel>
    {
        public StudentCourseListViewModel()
        {
            DetailViewModel = new StudentCourseDetailViewModel(() => DetailViewIsVisible = false);

            service = Honglorn.StudentCourseService();

            RefreshViewModel();
        }

        public override string ToString() => "Student Courses";
    }
}