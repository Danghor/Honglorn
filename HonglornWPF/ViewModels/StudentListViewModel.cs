using HonglornBL.MasterData.Student;
using HonglornBL.Models.Entities;
using System;

namespace HonglornWPF.ViewModels
{
    class StudentListViewModel : NGListViewModel<StudentService, Student>
    {
        public StudentListViewModel(StudentService service) : base(service) { }

        protected override NGDetailViewModel<StudentService, Student> CreateDetailViewModel(StudentService service, Guid entityKey)
        {
            return new StudentDetailViewModel(service, entityKey);
        }

        public override string ToString() => "Students";
    }
}