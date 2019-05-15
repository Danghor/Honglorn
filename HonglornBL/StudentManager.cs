using HonglornBL.Exceptions;
using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;

namespace HonglornBL
{
    public class StudentManager
    {
        HonglornDbFactory ContextFactory { get; }

        Guid StudentPKey { get; }

        internal StudentManager(Guid studentPKey, HonglornDbFactory contextFactory)
        {
            StudentPKey = studentPKey;
            ContextFactory = contextFactory;
        }

        Student Student(HonglornDb db)
        {
            Student student = db.Student.Find(StudentPKey);

            if (student == null)
            {
                throw new StudentNotFoundException($"No game with key {StudentPKey} found.");
            }

            return student;
        }
    }
}