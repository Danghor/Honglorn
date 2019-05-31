using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;
using System.Data.Entity;

namespace HonglornBL
{
    public sealed class StudentService : Service<StudentManager, Student, IStudentModel>
    {
        internal StudentService(HonglornDbFactory contextFactory) : base(contextFactory) { }

        protected override IDbSet<Student> GetDbSet(HonglornDb context)
        {
            return context.Student;
        }

        protected override Student ConstructEntity(IStudentModel model)
        {
            return new Student
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