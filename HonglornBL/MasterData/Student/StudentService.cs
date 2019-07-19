using System;
using System.Data.Entity;
using HonglornBL.Models.Framework;

namespace HonglornBL.MasterData.Student
{
    public sealed class StudentService : EntityService<StudentManager, Models.Entities.Student, IStudentModel>
    {
        internal StudentService(HonglornDbFactory contextFactory) : base(contextFactory) { }

        protected override IDbSet<Models.Entities.Student> GetDbSet(HonglornDb context)
        {
            return context.Student;
        }

        protected override StudentManager CreateManager(Guid pKey, HonglornDbFactory contextFactory)
        {
            return new StudentManager(pKey, contextFactory);
        }
    }
}