using HonglornBL.Exceptions;
using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;
using System.Data.Entity;

namespace HonglornBL
{
    public class CourseManager : EntityManager<Course>, ICourseModel
    {
        internal CourseManager(Guid pKey, HonglornDbFactory contextFactory) : base(pKey, contextFactory) { }

        public string Name
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

        protected override Exception CreateException(string message) => new CourseNotFoundException(message);

        protected override DbSet<Course> GetDbSet(HonglornDb db) => db.Course;
    }
}