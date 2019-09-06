using HonglornBL.MasterData;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace HonglornBL.Models.Entities
{
    [DebuggerDisplay("{Forename} {Surname}, {Sex}, YOB: {DateOfBirth}, ID: {PKey}")]
    public class Student : Entity
    {
        private string surname;

        [Required]
        public string Surname
        {
            get => surname;
            set => OnPropertyChanged(out surname, value);
        }

        private string forename;

        [Required]
        public string Forename
        {
            get => forename;
            set => OnPropertyChanged(out forename, value);
        }

        private Sex sex;

        [Required]
        public Sex Sex
        {
            get => sex;
            set => OnPropertyChanged(out sex, value);
        }

        private DateTime dateOfBirth;

        [Required]
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set => OnPropertyChanged(out dateOfBirth, value);
        }

        public virtual ObservableCollection<StudentHandicap> StudentHandicaps { get; set; } = new ObservableCollection<StudentHandicap>();

        public virtual ObservableCollection<StudentCourse> StudentCourses { get; set; } = new ObservableCollection<StudentCourse>();

        public override string ToString()
        {
            return $"{Forename} {Surname}";
        }
    }
}