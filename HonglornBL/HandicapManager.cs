﻿using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;
using System.Data.Entity;

namespace HonglornBL
{
    public class HandicapManager : EntityManager<Handicap>
    {
        internal HandicapManager(Guid pKey, HonglornDbFactory contextFactory) : base(pKey, contextFactory) { }

        public string HandicapName
        {
            get
            {
                return GetValue(g => g.Name);
            }

            set
            {
                using (HonglornDb db = ContextFactory.CreateContext())
                {
                    Entity(db).Name = value;
                    db.SaveChanges();
                }
            }
        }

        protected override Exception CreateException(string message) => new HandicapNotFoundException(message);

        protected override DbSet<Handicap> GetDbSet(HonglornDb db) => db.Handicap;

        T GetValue<T>(Func<Handicap, T> getValue)
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return getValue(Entity(db));
            }
        }
    }
}