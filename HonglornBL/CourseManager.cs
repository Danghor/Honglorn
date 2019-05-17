using HonglornBL.Exceptions;
using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HonglornBL
{
    public class CourseManager
    {
        internal HonglornDbFactory ContextFactory { get; set; }

        Guid CoursePKey { get; }

        internal CourseManager(Guid classPKey, HonglornDbFactory contextFactory)
        {
            CoursePKey = classPKey;
            ContextFactory = contextFactory;
        }

        Course Course(HonglornDb db)
        {
            Course course = db.Course.Find(CoursePKey);

            if (course == null)
            {
                throw new CourseNotFoundException($"No course with key {CoursePKey} found.");
            }

            return course;
        }

        public string CourseName
        {
            get
            {
                return GetValue(g => g.Name);
            }

            set
            {
                using (HonglornDb db = ContextFactory.CreateContext())
                {
                    Course(db).Name = value;
                    db.SaveChanges();
                }
            }
        }

        public Guid ClassIdentifier
        {
            get
            {
                return GetValue(g => g.ClassPKey);
            }

            set
            {
                using (HonglornDb db = ContextFactory.CreateContext())
                {
                    Course(db).Class = db.Class.Find(value);
                    db.SaveChanges();
                }
            }
        }

        T GetValue<T>(Func<Course, T> getValue)
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return getValue(Course(db));
            }
        }
    }
}