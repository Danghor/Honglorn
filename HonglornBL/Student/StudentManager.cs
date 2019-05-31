using HonglornBL.Exceptions;
using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;
using System.Data.Entity;

namespace HonglornBL
{
    public class StudentManager : EntityManager<Student>
    {
        internal StudentManager(Guid pKey, HonglornDbFactory contextFactory) : base(pKey, contextFactory) { }

        protected override Exception CreateNotFoundException(string message) => new StudentNotFoundException(message);

        protected override DbSet<Student> GetDbSet(HonglornDb db) => db.Student;
    }
}