using HonglornBL.MasterData.StudentCourse;
using HonglornBL.Models.Entities;
using System;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    class StudentCourseDetailViewModel : NGDetailViewModel<StudentCourseService, StudentCourse>
    {
        internal ICommand AcceptCommand { get; }
        internal ICommand CancelCommand { get; }

        public StudentCourseDetailViewModel(StudentCourseService service, Guid entityKey) : base(service, entityKey)
        {

        }
    }
}