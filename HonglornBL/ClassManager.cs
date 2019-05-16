using HonglornBL.Exceptions;
using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;

namespace HonglornBL
{
    public class ClassManager
    {
        internal HonglornDbFactory ContextFactory { get; set; }

        Guid ClassPKey { get; }

        internal ClassManager(Guid classPKey, HonglornDbFactory contextFactory)
        {
            ClassPKey = classPKey;
            ContextFactory = contextFactory;
        }

        Class Class(HonglornDb db)
        {
            Class @class = db.Class.Find(ClassPKey);

            if (@class == null)
            {
                throw new ClassNotFoundException($"No class with key {ClassPKey} found.");
            }

            return @class;
        }

        public string ClassName
        {
            get
            {
                return GetValue(g => g.Name);
            }

            set
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