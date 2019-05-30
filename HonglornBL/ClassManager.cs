using HonglornBL.Exceptions;
using HonglornBL.Interfaces;
using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;

namespace HonglornBL
{
    public class ClassManager : EntityManager, IClassModel
    {
        HonglornDbFactory ContextFactory { get; }

        internal ClassManager(Guid pKey, HonglornDbFactory contextFactory) : base(pKey)
        {
            ContextFactory = contextFactory;
        }

        Class Class(HonglornDb db)
        {
            Class @class = db.Class.Find(PKey);

            if (@class == null)
            {
                throw new ClassNotFoundException($"No class with key {PKey} found.");
            }

            return @class;
        }

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
                    Class(db).Name = value;
                    db.SaveChanges();
                }
            }
        }

        T GetValue<T>(Func<Class, T> getValue)
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return getValue(Class(db));
            }
        }
    }
}