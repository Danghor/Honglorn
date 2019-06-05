using HonglornBL.Enums;
using HonglornBL.Exceptions;
using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;
using System.Data.Entity;

namespace HonglornBL
{
    public class StudentManager : EntityManager<Student>, IStudentModel, IEntityManager<IStudentModel>
    {
        internal StudentManager(Guid pKey, HonglornDbFactory contextFactory) : base(pKey, contextFactory) { }

        public string Surname
        {
            get => GetValue(s => s.Surname);
            set => SetValue((student, surname) => student.Surname = surname, value);
        }

        public string Forename
        {
            get => GetValue(s => s.Forename);
            set => SetValue((student, forename) => student.Forename = forename, value);
        }

        public Sex Sex
        {
            get => GetValue(s => s.Sex);
            set => SetValue((student, sex) => student.Sex = sex, value);
        }

        public DateTime DateOfBirth
        {
            get => GetValue(s => s.DateOfBirth);
            set => SetValue((student, dateOfBirth) => student.DateOfBirth = dateOfBirth, value.Date);
        }

        public void Update(IStudentModel model)
        {
            Surname = model.Surname;
            Forename = model.Forename;
            Sex = model.Sex;
            DateOfBirth = model.DateOfBirth;
        }

        protected override Exception CreateNotFoundException(string message) => new StudentNotFoundException(message);

        protected override DbSet<Student> GetDbSet(HonglornDb db) => db.Student;
    }
}