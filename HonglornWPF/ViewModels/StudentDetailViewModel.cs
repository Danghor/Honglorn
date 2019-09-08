using HonglornBL.MasterData.Student;
using HonglornBL.Models.Entities;
using System;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    class StudentDetailViewModel : NGDetailViewModel<StudentService, Student>
    {
        public ICommand AddStudentCourseCommand { get; }
        public ICommand RemoveStudentCourseCommand { get; }

        public StudentDetailViewModel(StudentService service, Guid entityKey) : base(service, entityKey)
        {

        }
    }
}