using HonglornBL.Models.Framework;
using System;

namespace HonglornBL.MasterData.Handicap
{
    public sealed class HandicapService : EntityService<HandicapManager, Models.Entities.Handicap, IHandicapModel>
    {
        internal HandicapService(HonglornDbFactory contextFactory) : base(contextFactory) { }

        public override HandicapManager CreateManager(Guid pKey)
        {
            return new HandicapManager(pKey, ContextFactory, GetDbSet);
        }

        protected override System.Data.Entity.IDbSet<Models.Entities.Handicap> GetDbSet(HonglornDb context)
        {
            return context.Handicap;
        }
    }
}