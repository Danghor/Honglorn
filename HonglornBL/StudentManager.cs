using HonglornBL.Exceptions;
using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;

namespace HonglornBL
{
    public class StudentManager : EntityManager
    {
        HonglornDbFactory ContextFactory { get; }

        internal StudentManager(Guid pKey, HonglornDbFactory contextFactory) : base(pKey)
        {
            ContextFactory = contextFactory;
        }

        Student Student(HonglornDb db)
        {
            Student student = db.Student.Find(PKey);

            if (student == null)
            {
                throw new StudentNotFoundException($"No game with key {PKey} found.");
            }

            return student;
        }
    }
}