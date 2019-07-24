using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HonglornBL.Models.Framework;

namespace HonglornBL.MasterData.Student
{
    public sealed class StudentManager : EntityManager<Models.Entities.Student, IStudentModel>, IStudentModel, IEntityManager<IStudentModel>
    {
        internal StudentManager(Guid pKey, HonglornDbFactory contextFactory, Func<HonglornDb, IDbSet<Models.Entities.Student>> getDbSet) : base(pKey, contextFactory, getDbSet) { }

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

        public ICollection<Guid> StudentCoursePKeys => GetValue(s => s.StudentCourses).Select(course => course.PKey).ToList();

        protected override Exception CreateNotFoundException(string message) => new StudentNotFoundException(message);
    }
}