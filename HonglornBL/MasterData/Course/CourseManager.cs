using System;
using System.Data.Entity;
using HonglornBL.Models.Framework;

namespace HonglornBL.MasterData.Course
{
    public class CourseManager : EntityManager<Models.Entities.Course>, ICourseModel, IEntityManager<ICourseModel>
    {
        internal CourseManager(Guid pKey, HonglornDbFactory contextFactory) : base(pKey, contextFactory) { }

        public string Name
        {
            get => GetValue(g => g.Name);
            set => SetValue((course, name) => course.Name = name, value);
        }

        public Guid ClassPKey
        {
            get => GetValue(g => g.ClassPKey);
            set => SetValue((course, classPKey) => course.ClassPKey = classPKey, value);
        }

        public string ClassName
        {
            get => GetValue(c => c.Class.Name);
        }

        public void Update(ICourseModel model)
        {
            Name = model.Name;
            ClassPKey = model.ClassPKey;
        }

        protected override Exception CreateNotFoundException(string message) => new CourseNotFoundException(message);

        protected override DbSet<Models.Entities.Course> GetDbSet(HonglornDb db) => db.Course;
    }
}