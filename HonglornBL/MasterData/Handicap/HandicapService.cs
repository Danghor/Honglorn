using HonglornBL.Models.Framework;
using System.Data.Entity;

namespace HonglornBL.MasterData.Handicap
{
    public sealed class HandicapService : NGService<Models.Entities.Handicap>
    {
        internal HandicapService(HonglornDbFactory contextFactory) : base(contextFactory) { }

        protected override DbSet<Models.Entities.Handicap> EntitySet => Context.Handicap;
    }
}