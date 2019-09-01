using HonglornBL.Models.Framework;
using System.Data.Entity;

namespace HonglornBL.MasterData.Class
{
    public sealed class ClassService : NGService<Models.Entities.Class>
    {
        internal ClassService(HonglornDbFactory contextFactory) : base(contextFactory) { }

        protected override DbSet<Models.Entities.Class> EntitySet => Context.Class;
    }
}