using System;
using System.Data.Entity;
using HonglornBL.Models.Framework;

namespace HonglornBL.MasterData.Course
{
    public sealed class CourseManager : EntityManager<Models.Entities.Course, ICourseModel>, ICourseModel, IEntityManager<ICourseModel>
    {
        internal CourseManager(Guid pKey, HonglornDbFactory contextFactory, Func<HonglornDb, IDbSet<Models.Entities.Course>> getDbSet) : base(pKey, contextFactory, getDbSet) { }

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

        protected override Exception CreateNotFoundException(string message) => new CourseNotFoundException(message);
    }
}