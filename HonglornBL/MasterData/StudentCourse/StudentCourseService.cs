using HonglornBL.Models.Framework;
using System;
using System.Data.Entity;

namespace HonglornBL.MasterData.StudentCourse
{
    public sealed class StudentCourseService : EntityService<StudentCourseManager, Models.Entities.StudentCourse, IStudentCourseModel>
    {
        internal StudentCourseService(HonglornDbFactory contextFactory) : base(contextFactory) { }

        protected override IDbSet<Models.Entities.StudentCourse> GetDbSet(HonglornDb context)
        {
            return context.StudentCourse;
        }

        protected override StudentCourseManager CreateManager(Guid pKey, HonglornDbFactory contextFactory)
        {
            return new StudentCourseManager(pKey, contextFactory);
        }
    }
}