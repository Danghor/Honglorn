using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;
using System.Data.Entity;

namespace HonglornBL
{
    public class CourseManager : EntityManager<Course>
    {
        internal CourseManager(Guid pKey, HonglornDbFactory contextFactory) : base(pKey, contextFactory) { }

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
                    Entity(db).Name = value;
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
                    Entity(db).Class = db.Class.Find(value);
                    db.SaveChanges();
                }
            }
        }

        // TODO: Write own exception type
        protected override Exception CreateException(string message) => new Exception(message);

        protected override DbSet<Course> GetDbSet(HonglornDb db) => db.Course;

        T GetValue<T>(Func<Course, T> getValue)
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return getValue(Entity(db));
            }
        }
    }
}