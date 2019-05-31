using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HonglornBL
{
    public sealed class StudentService : Service<StudentManager, Student, IStudentModel>
    {
        internal StudentService(HonglornDbFactory contextFactory) : base(contextFactory) { }

        public override ICollection<StudentManager> GetManagers()
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return db.Student.Select(s => s.PKey).ToList().Select(key => new StudentManager(key, ContextFactory)).ToList();
            }
        }

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
    }
}