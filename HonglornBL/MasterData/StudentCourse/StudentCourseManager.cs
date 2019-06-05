using HonglornBL.Exceptions;
using HonglornBL.Models.Framework;
using System;
using System.Data.Entity;

namespace HonglornBL.MasterData.StudentCourse
{
    public class StudentCourseManager : EntityManager<Models.Entities.StudentCourse>, IStudentCourseModel, IEntityManager<IStudentCourseModel>
    {
        internal StudentCourseManager(Guid pKey, HonglornDbFactory contextFactory) : base(pKey, contextFactory) { }

        public Guid StudentPKey
        {
            get => GetValue(s => s.StudentPKey);
            set => SetValue((s, p) => s.StudentPKey = p, value);
        }

        public Guid CoursePKey
        {
            get => GetValue(s => s.CoursePKey);
            set => SetValue((s, p) => s.CoursePKey = p, value);
        }

        public DateTime DateStart
        {
            get => GetValue(s => s.DateStart);
            set => SetValue((student, dateStart) => student.DateStart = dateStart, value.Date);
        }

        public DateTime DateEnd
        {
            get => GetValue(s => s.DateEnd);
            set => SetValue((student, dateEnd) => student.DateEnd = dateEnd, value.Date);
        }

        public void Update(IStudentCourseModel model)
        {
            StudentPKey = model.StudentPKey;
            CoursePKey = model.CoursePKey;
            DateStart = model.DateStart;
            DateEnd = model.DateEnd;
        }

        protected override Exception CreateNotFoundException(string message) => new StudentCourseNotFoundException(message);

        protected override DbSet<Models.Entities.StudentCourse> GetDbSet(HonglornDb db) => db.StudentCourse;
    }
}
