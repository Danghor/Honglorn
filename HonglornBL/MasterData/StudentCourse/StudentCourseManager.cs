using HonglornBL.Models.Framework;
using System;
using System.Data.Entity;

namespace HonglornBL.MasterData.StudentCourse
{
    public sealed class StudentCourseManager : EntityManager<Models.Entities.StudentCourse, IStudentCourseModel>, IStudentCourseModel, IEntityManager<IStudentCourseModel>
    {
        internal StudentCourseManager(Guid pKey, HonglornDbFactory contextFactory, Func<HonglornDb, IDbSet<Models.Entities.StudentCourse>> getDbSet) : base(pKey, contextFactory, getDbSet) { }

        public Guid StudentPKey
        {
            get => GetValue(s => s.StudentPKey);
            set => SetValue((s, p) => s.StudentPKey = p, value);
        }

        public string StudentName => GetValue(s => $"{s.Student.Forename} {s.Student.Surname}");

        public Guid CoursePKey
        {
            get => GetValue(s => s.CoursePKey);
            set => SetValue((s, p) => s.CoursePKey = p, value);
        }

        public string CourseName => GetValue(s => s.Course.Name);

        public DateTime DateStart
        {
            get => GetValue(s => s.DateStart);
            set => SetValue((student, dateStart) => student.DateStart = dateStart, value.Date);
        }

        public DateTime? DateEnd
        {
            get => GetValue(s => s.DateEnd);
            set => SetValue((student, dateEnd) => student.DateEnd = dateEnd, value?.Date);
        }

        protected override Exception CreateNotFoundException(string message) => new StudentCourseNotFoundException(message);
    }
}