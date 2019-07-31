using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HonglornBL.MasterData.StudentCourse;
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

        public IEnumerable<Guid> StudentCoursePKeys => StudentCourseManagers.Select(m => m.PKey);

        public ICollection<StudentCourseManager> StudentCourseManagers { get; } = new List<StudentCourseManager>();

        public void AddStudentCourse(Guid pKey)
        {
            StudentCourseManagers.Add(new StudentCourseManager(pKey, ContextFactory, c => c.StudentCourse));
        }

        protected override Exception CreateNotFoundException(string message) => new StudentNotFoundException(message);
    }
}