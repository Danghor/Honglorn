using System;
using HonglornBL.MasterData;
using HonglornBL.MasterData.Student;

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

        public StudentDetailViewModel(Action cancelAction) : base(cancelAction) { }

        internal override void Clear()
        {
            Surname = default;
            Forename = default;
            Sex = default;
            DateOfBirth = default;
        }

        internal override void CopyValues(IStudentModel model)
        {
            Surname = model.Surname;
            Forename = model.Forename;
            Sex = model.Sex;
            DateOfBirth = model.DateOfBirth;
        }
    }
}