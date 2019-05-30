using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;

namespace HonglornBL
{
    public class HandicapManager
    {
        internal HonglornDbFactory ContextFactory { get; set; }

        Guid HandicapPKey { get; }

        internal HandicapManager(Guid handicapPKey, HonglornDbFactory contextFactory)
        {
            HandicapPKey = handicapPKey;
            ContextFactory = contextFactory;
        }

        Handicap Handicap(HonglornDb db)
        {
            Handicap handicap = db.Handicap.Find(HandicapPKey);

            if (handicap == null)
            {
                throw new HandicapNotFoundException($"No handicap with key {HandicapPKey} found.");
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