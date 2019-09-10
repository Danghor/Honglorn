using HonglornBL.MasterData.Student;
using HonglornBL.MasterData.StudentCourse;
using HonglornBL.Models.Entities;
using System;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    class StudentDetailViewModel : NGDetailViewModel<StudentService, Student>
    {
        public ICommand AddStudentCourseCommand { get; }
        public ICommand RemoveStudentCourseCommand { get; }

        LookupViewModel<StudentCourseService, StudentCourse> studentCourseLookupViewModel;

        public LookupViewModel<StudentCourseService, StudentCourse> StudentCourseLookupViewModel
        {
            get => studentCourseLookupViewModel;
            set
            {
                studentCourseLookupViewModel?.Dispose();
                OnPropertyChanged(out studentCourseLookupViewModel, value);
            }
        }

        public StudentDetailViewModel(StudentService service, Guid entityKey) : base(service, entityKey)
        {
            AddStudentCourseCommand = new RelayCommand(AddStudentCourse);
            RemoveStudentCourseCommand = new RelayCommand(RemoveStudentCourse);
        }

        void AddStudentCourse()
        {
            throw new NotImplementedException();
        }

        void RemoveStudentCourse()
        {
            throw new NotImplementedException();
        }

        //TODO: Implement dispose pattern for the LookupViewModel
    }
}