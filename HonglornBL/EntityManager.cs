using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;
using System.Data.Entity;

namespace HonglornBL
{
    public abstract class EntityManager<TEntity, TEntityModel>
        where TEntity : class, IEntity<TEntityModel>
    {
        public Guid PKey { get; }

        protected HonglornDbFactory ContextFactory { get; }

        protected EntityManager(Guid pKey, HonglornDbFactory contextFactory, Func<HonglornDb, IDbSet<TEntity>> getDbSet)
        {
            PKey = pKey;
            ContextFactory = contextFactory;
            GetDbSet = getDbSet;
        }

        protected Func<HonglornDb, IDbSet<TEntity>> GetDbSet;

        protected abstract Exception CreateNotFoundException(string message);

        protected TEntity Entity(HonglornDb db)
        {
            TEntity entity = GetDbSet(db).Find(PKey);

            if (entity == null)
            {
                throw CreateNotFoundException($"No {typeof(TEntity)} with key {PKey} found.");
            }

            return entity;
        }

        protected TValue GetValue<TValue>(Func<TEntity, TValue> getValue)
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return getValue(Entity(db));
            }
        }

        protected void SetValue<TValue>(Action<TEntity, TValue> setValue, TValue value)
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                setValue(Entity(db), value);
                db.SaveChanges();
            }
        }

        public void Update(TEntityModel model)
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                Entity(db).AdoptValues(model);
                db.SaveChanges();
            }
        }
    }
}