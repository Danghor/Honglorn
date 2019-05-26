using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace HonglornBL
{
    public abstract class Service<TManager, TEntity> where TEntity : class, IEntity, new()
    {
        internal HonglornDbFactory ContextFactory { get; set; }

        internal Service(HonglornDbFactory contextFactory)
        {
            ContextFactory = contextFactory;
        }

        public abstract ICollection<TManager> GetManagers();

        protected void Delete(Guid pKey)
        {
            var entity = new TEntity
            {
                PKey = pKey
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
                throw new ArgumentException($"A {entity.GetType()} with PKey {pKey} does not exist in the database.", nameof(pKey), ex);
            }
        }

        internal void CreateEntity(Func<HonglornDb, IDbSet<TEntity>> dbSet, TEntity game)
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                dbSet(db).Add(game);
                db.SaveChanges();
            }
        }
    }
}