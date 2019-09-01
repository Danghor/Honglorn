using System;
using HonglornBL;
using HonglornBL.MasterData;
using HonglornBL.MasterData.Student;
using HonglornBL.Models.Entities;

namespace HonglornWPF.ViewModels
{
    class StudentListViewModel : NGListViewModel<Student>
    {
        protected override NGService<Student> Service { get; }

        public StudentListViewModel()
        {
            Service = Honglorn.StudentService();
        }

        protected override NGDetailViewModel<Student> CreateDetailViewModel(Action cancelAction, Action acceptAction, Student entity)
        {
            return new StudentDetailViewModel(cancelAction, acceptAction, entity);
        }

        public override string ToString() => "Students";
    }
}