using HonglornBL.Models.Framework;
using System.Data.Entity;

namespace HonglornBL.MasterData.StudentCourse
{
    public sealed class StudentCourseService : NGService<Models.Entities.StudentCourse>
    {
        internal StudentCourseService(HonglornDbFactory contextFactory) : base(contextFactory) { }

        protected override DbSet<Models.Entities.StudentCourse> EntitySet => Context.StudentCourse;
    }
}