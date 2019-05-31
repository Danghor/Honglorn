﻿using HonglornBL.Models.Framework;
using System;
using System.Data.Entity;

namespace HonglornBL
{
    public abstract class EntityManager<TEntity>
        where TEntity : class
    {
        internal Guid PKey { get; }

        protected HonglornDbFactory ContextFactory { get; }

        protected EntityManager(Guid pKey, HonglornDbFactory contextFactory)
        {
            PKey = pKey;
            ContextFactory = contextFactory;
        }

        protected abstract DbSet<TEntity> GetDbSet(HonglornDb db);

        protected abstract Exception CreateException(string message);

        protected TEntity Entity(HonglornDb db)
        {
            TEntity entity = GetDbSet(db).Find(PKey);

            if (entity == null)
            {
                throw CreateException($"No {typeof(TEntity)} with key {PKey} found.");
            }

            return entity;
        }
    }
}