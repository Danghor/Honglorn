using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace HonglornBL
{
    public abstract class Service<TManager, TEntity>
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

        internal void CreateEntity(Func<HonglornDb, IDbSet<TEntity>> dbSet, TEntity entity)
        {
            using (HonglornDb context = ContextFactory.CreateContext())
            {
                dbSet(context).Add(entity);
                context.SaveChanges();
            }
        }
    }
}