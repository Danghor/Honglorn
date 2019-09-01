using HonglornBL.Models.Framework;
using System.Data.Entity;

namespace HonglornBL.MasterData.StudentHandicap
{
    public sealed class StudentHandicapService : NGService<Models.Entities.StudentHandicap>
    {
        internal StudentHandicapService(HonglornDbFactory contextFactory) : base(contextFactory) { }

        protected override DbSet<Models.Entities.StudentHandicap> EntitySet => Context.StudentHandicap;
    }
}