using HonglornBL.MasterData.Student;
using HonglornBL.Models.Entities;
using System;

namespace HonglornWPF.ViewModels
{
    class StudentDetailViewModel : NGDetailViewModel<StudentService, Student>
    {
        public StudentDetailViewModel(StudentService service, Guid entityKey) : base(service, entityKey) { }

        public override string ToString() => $"Student - {Entity.Surname}, {Entity.Forename}";
    }
}