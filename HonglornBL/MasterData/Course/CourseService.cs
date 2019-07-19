using HonglornBL.Models.Framework;
using System;
using System.Data.Entity;

namespace HonglornBL.MasterData.Course
{
    public sealed class CourseService : EntityService<CourseManager, Models.Entities.Course, ICourseModel>
    {
        internal CourseService(HonglornDbFactory contextFactory) : base(contextFactory) { }

        protected override CourseManager CreateManager(Guid pKey, HonglornDbFactory contextFactory)
        {
            return new CourseManager(pKey, contextFactory);
        }

        protected override IDbSet<Models.Entities.Course> GetDbSet(HonglornDb context)
        {
            return context.Course;
        }
    }
}