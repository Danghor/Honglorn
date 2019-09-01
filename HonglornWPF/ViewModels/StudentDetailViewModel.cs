using HonglornBL.Models.Entities;
using System;

namespace HonglornWPF.ViewModels
{
    class StudentDetailViewModel : NGDetailViewModel<Student>
    {
        public StudentDetailViewModel(Action cancelAction, Action acceptAction, Student entity)
            : base(cancelAction, acceptAction, entity) { }
    }
}