using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HonglornBL.MasterData;
using HonglornBL.MasterData.Student;
using HonglornBL.MasterData.StudentCourse;

namespace HonglornWPF.ViewModels
{
    class StudentDetailViewModel : DetailViewModel<IStudentModel>, IStudentModel
    {
        string surname;

        public string Surname
        {
            get => surname;
            set => OnPropertyChanged(out surname, value);
        }

        string forename;

        public string Forename
        {
            get => forename;
            set => OnPropertyChanged(out forename, value);
        }

        Sex sex;

        public Sex Sex
        {
            get => sex;
            set => OnPropertyChanged(out sex, value);
        }

        DateTime dateOfBirth;

        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set => OnPropertyChanged(out dateOfBirth, value);
        }

        public ICollection<Guid> StudentCoursePKeys { get; }

        public ObservableCollection<IStudentCourseModel> StudentCourses { get; set; } = new ObservableCollection<IStudentCourseModel>();

        IStudentCourseModel currentStudentCourse;

        public IStudentCourseModel CurrentStudentCourse
        {
            get => currentStudentCourse;
            set => OnPropertyChanged(out currentStudentCourse, value);
        }

        ICommand addStudentCourseCommand;

        public ICommand AddStudentCourseCommand
        {
            get => addStudentCourseCommand;
            set => OnPropertyChanged(out addStudentCourseCommand, value);
        }

        public StudentDetailViewModel(Action cancelAction) : base(cancelAction) { }

        internal override void Clear()
        {
            Surname = default;
            Forename = default;
            Sex = default;
            DateOfBirth = default;
            StudentCourses.Clear();
        }

        internal override void CopyValues(IStudentModel model)
        {
            Surname = model.Surname;
            Forename = model.Forename;
            Sex = model.Sex;
            DateOfBirth = model.DateOfBirth;

            var studentCourseService = Honglorn.StudentCourseService();

            StudentCourses.Clear();
            foreach(var coursePKey in model.StudentCoursePKeys)
            {
                StudentCourses.Add(studentCourseService.CreateManager(coursePKey));
            }
        }
    }
}