using HonglornBL.MasterData.StudentCourse;
using HonglornBL.Models.Entities;
using System;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    public class StudentCourseDetailViewModel
    {
        public ICommand AcceptCommand { get; }
        public ICommand CancelCommand { get; }

        public StudentCourse StudentCourse { get; }

        public StudentCourseDetailViewModel(StudentCourse studentCourse, Action acceptAction, Action cancelAction)
        {
            StudentCourse = studentCourse;
            AcceptCommand = new RelayCommand(acceptAction);
            CancelCommand = new RelayCommand(cancelAction);
        }
    }
}