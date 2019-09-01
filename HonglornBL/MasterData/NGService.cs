using HonglornBL.Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HonglornBL.MasterData
{
    // TODO: rename
    public abstract class NGService<T> : IDisposable
        where T : class
    {
        protected abstract DbSet<T> EntitySet { get; }
        protected HonglornDb Context { get; private set; }

        private readonly HonglornDbFactory contextFactory;

        protected NGService(HonglornDbFactory contextFactory)
        {
            this.contextFactory = contextFactory;
            Context = contextFactory.CreateContext();
        }

        public IEnumerable<T> GetAll()
        {
            return EntitySet.AsEnumerable();
        }

        public T Find(Guid key)
        {
            return EntitySet.Find(key);
        }

        public void Create(T entity)
        {
            EntitySet.Add(@entity);
        }

        public void DiscardObjectChanges(T entity)
        {
            var entry = Context.Entry(entity);

            foreach (var propName in entry.CurrentValues.PropertyNames)
            {
                entry.CurrentValues[propName] = entry.OriginalValues[propName];
            }
        }

        public void RefreshContext()
        {
            Context.Dispose();
            Context = contextFactory.CreateContext();
        }

        public void Delete(T entity)
        {
            EntitySet.Remove(entity);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
