using HonglornBL.Models.Framework;
using System;

namespace HonglornBL.MasterData.Handicap
{
    public sealed class HandicapService : EntityService<HandicapManager, Models.Entities.Handicap, IHandicapModel>
    {
        internal HandicapService(HonglornDbFactory contextFactory) : base(contextFactory) { }

        protected override Models.Entities.Handicap CreateEntity(IHandicapModel model)
        {
            return new Models.Entities.Handicap
            {
                Name = model.Name
            };
        }

        protected override HandicapManager CreateManager(Guid pKey, HonglornDbFactory contextFactory)
        {
            return new HandicapManager(pKey, contextFactory);
        }

        protected override System.Data.Entity.IDbSet<Models.Entities.Handicap> GetDbSet(HonglornDb context)
        {
            return context.Handicap;
        }
    }
}