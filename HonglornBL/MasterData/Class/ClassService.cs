using System;
using System.Data.Entity;
using HonglornBL.Models.Framework;

namespace HonglornBL.MasterData.Class
{
    public sealed class ClassService : EntityService<ClassManager, Models.Entities.Class, IClassModel>
    {
        internal ClassService(HonglornDbFactory contextFactory) : base(contextFactory) { }

        public override ClassManager CreateManager(Guid pKey)
        {
            return new ClassManager(pKey, ContextFactory);
        }

        protected override IDbSet<Models.Entities.Class> GetDbSet(HonglornDb context)
        {
            return context.Class;
        }
    }
}