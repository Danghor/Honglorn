using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;

namespace HonglornBL
{
    public class HandicapManager : EntityManager
    {
        HonglornDbFactory ContextFactory { get; }

        internal HandicapManager(Guid pKey, HonglornDbFactory contextFactory) : base(pKey)
        {
            ContextFactory = contextFactory;
        }

        Handicap Handicap(HonglornDb db)
        {
            Handicap handicap = db.Handicap.Find(PKey);

            if (handicap == null)
            {
                throw new HandicapNotFoundException($"No handicap with key {PKey} found.");
            }

            return handicap;
        }

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
                    Handicap(db).Name = value;
                    db.SaveChanges();
                }
            }
        }

        T GetValue<T>(Func<Handicap, T> getValue)
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return getValue(Handicap(db));
            }
        }
    }
}