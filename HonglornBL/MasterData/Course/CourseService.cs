using HonglornBL.Models.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HonglornBL.MasterData.Course
{
    public sealed class CourseService : NGService<Models.Entities.Course>
    {
        internal CourseService(HonglornDbFactory contextFactory) : base(contextFactory) { }

        protected override DbSet<Models.Entities.Course> EntitySet => Context.Course;

        public IEnumerable<Models.Entities.Class> GetValidClasses()
        {
            return Context.Class.AsEnumerable();
        }
    }
}