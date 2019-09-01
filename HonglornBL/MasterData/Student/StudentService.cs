using HonglornBL.Models.Framework;
using System.Data.Entity;

namespace HonglornBL.MasterData.Student
{
    public sealed class StudentService : NGService<Models.Entities.Student>
    {
        internal StudentService(HonglornDbFactory contextFactory) : base(contextFactory) { }

        protected override DbSet<Models.Entities.Student> EntitySet => Context.Student;
    }
}