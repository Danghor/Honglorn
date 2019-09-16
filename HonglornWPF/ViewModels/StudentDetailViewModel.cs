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

        StudentCourse selectedStudentCourse;

        public StudentCourse SelectedStudentCourse
        {
            get => selectedStudentCourse;
            set => OnPropertyChanged(out selectedStudentCourse, value);
        }

        StudentCourseDetailViewModel studentCourseDetailViewModel;

        public StudentCourseDetailViewModel StudentCourseDetailViewModel
        {
            get => studentCourseDetailViewModel;
            set => OnPropertyChanged(out studentCourseDetailViewModel, value);
        }

        public StudentDetailViewModel(StudentService service, Guid entityKey) : base(service, entityKey)
        {
            AddStudentCourseCommand = new RelayCommand(AddStudentCourse);
            RemoveStudentCourseCommand = new RelayCommand(RemoveStudentCourse);
        }

        void AddStudentCourse()
        {
            var studentCourse = new StudentCourse();
            StudentCourseDetailViewModel = new StudentCourseDetailViewModel(studentCourse,
                () =>
                {
                    Entity.StudentCourses.Add(studentCourse);
                    StudentCourseDetailViewModel = null;
                },
                () =>
                {
                    StudentCourseDetailViewModel = null;
                }
                );
        }

        void RemoveStudentCourse()
        {
            throw new NotImplementedException();
        }

        //TODO: Implement dispose pattern for the LookupViewModel
    }
}