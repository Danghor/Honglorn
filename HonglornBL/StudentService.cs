using HonglornBL.Enums;
using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HonglornBL
{
    public sealed class StudentService : Service<StudentManager, Student>
    {
        internal StudentService(HonglornDbFactory contextFactory) : base(contextFactory) { }

        public override ICollection<StudentManager> GetManagers()
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return db.Student.Select(s => s.PKey).ToList().Select(key => new StudentManager(key, ContextFactory)).ToList();
            }
        }

        public void Create(string surname, string forename, Sex sex, DateTime dateOfBirth)
        {
            CreateEntity(context => context.Student, new Student { Surname = surname, Forename = forename, Sex = sex, DateOfBirth = dateOfBirth });
        }
    }
}