using HonglornBL.Exceptions;
using HonglornBL.Interfaces;
using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;
using System.Data.Entity;

namespace HonglornBL
{
    public class ClassManager : EntityManager<Class>, IClassModel
    {
        internal ClassManager(Guid pKey, HonglornDbFactory contextFactory) : base(pKey, contextFactory) { }

        public void Update(IClassModel model)
        {
            Name = model.Name;
        }

        public string Name
        {
            get
            {
                return GetValue(g => g.Name);
            }

            private set
            {
                using (HonglornDb db = ContextFactory.CreateContext())
                {
                    Entity(db).Name = value;
                    db.SaveChanges();
                }
            }
        }

        T GetValue<T>(Func<Class, T> getValue)
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return getValue(Entity(db));
            }
        }

        protected override DbSet<Class> GetDbSet(HonglornDb db) => db.Class;

        protected override Exception CreateException(string message) => new ClassNotFoundException(message);
    }
}