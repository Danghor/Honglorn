using HonglornBL.Exceptions;
using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;

namespace HonglornBL
{
    public class CourseManager : EntityManager
    {
        HonglornDbFactory ContextFactory { get; }

        internal CourseManager(Guid pKey, HonglornDbFactory contextFactory) : base(pKey)
        {
            ContextFactory = contextFactory;
        }

        Course Course(HonglornDb db)
        {
            Course course = db.Course.Find(PKey);

            if (course == null)
            {
                throw new CourseNotFoundException($"No course with key {PKey} found.");
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