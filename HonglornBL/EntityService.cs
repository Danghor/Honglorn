using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace HonglornBL
{
    public abstract class EntityService<TManager, TEntity, TModel> : IEntityService<TManager, TModel>
        where TManager : EntityManager<TEntity, TModel>
        where TEntity : class, IEntity<TModel>, new()
    {
        internal HonglornDbFactory ContextFactory { get; }

        protected EntityService(HonglornDbFactory contextFactory)
        {
            ContextFactory = contextFactory;
        }

        public abstract TManager CreateManager(Guid pKey);

        public ICollection<TManager> GetManagers()
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return GetDbSet(db).Select(s => s.PKey).AsEnumerable().Select(CreateManager).ToList();
            }
        }

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
                throw new ArgumentException($"A {entity.GetType()} with PKey {manager.PKey} does not exist in the database.", nameof(manager), ex);
            }
        }

        protected abstract IDbSet<TEntity> GetDbSet(HonglornDb context);

        public void Create(TModel model)
        {
            using (HonglornDb context = ContextFactory.CreateContext())
            {
                var entity = new TEntity();
                entity.AdoptValues(model);
                GetDbSet(context).Add(entity);

                context.SaveChanges();
            }
        }
    }
}