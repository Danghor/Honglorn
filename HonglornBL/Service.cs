using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace HonglornBL
{
    public abstract class Service<TManager, TEntity, TModel>
        where TManager : EntityManager
        where TEntity : class, IEntity, new()
    {
        internal HonglornDbFactory ContextFactory { get; }

        internal Service(HonglornDbFactory contextFactory)
        {
            ContextFactory = contextFactory;
        }

        public abstract ICollection<TManager> GetManagers();

        public void Delete(TManager manager)
        {
            var entity = new TEntity
            {
                PKey = manager.PKey
            };

            try
            {
                using (HonglornDb db = ContextFactory.CreateContext())
                {
                    db.Entry(entity).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ArgumentException($"A {entity.GetType()} with PKey {manager.PKey} does not exist in the database.", nameof(manager.PKey), ex);
            }
        }

        protected abstract TEntity ConstructEntity(TModel model);
        protected abstract IDbSet<TEntity> GetDbSet(HonglornDb context);

        public void Create(TModel model)
        {
            using (HonglornDb context = ContextFactory.CreateContext())
            {
                GetDbSet(context).Add(ConstructEntity(model));
                context.SaveChanges();
            }
        }
    }
}