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

        protected override Models.Entities.Student CreateEntity(IStudentModel model)
        {
            return new Models.Entities.Student
            {
                Surname = model.Surname,
                Forename = model.Forename,
                Sex = model.Sex,
                DateOfBirth = model.DateOfBirth
            };
        }

        protected override StudentManager CreateManager(Guid pKey, HonglornDbFactory contextFactory)
        {
            return new StudentManager(pKey, contextFactory);
        }
    }
}