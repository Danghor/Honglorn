using System;
using System.Data.Entity;
using HonglornBL.Models.Framework;

namespace HonglornBL.MasterData.Class
{
    public sealed class ClassService : EntityService<ClassManager, Models.Entities.Class, IClassModel>
    {
        internal ClassService(HonglornDbFactory contextFactory) : base(contextFactory) { }

        protected override ClassManager CreateManager(Guid pKey, HonglornDbFactory contextFactory)
        {
            return new ClassManager(pKey, contextFactory);
        }

        protected override IDbSet<Models.Entities.Class> GetDbSet(HonglornDb context)
        {
            return context.Class;
        }

        protected override Models.Entities.Class CreateEntity(IClassModel model)
        {
            return new Models.Entities.Class
            {
                Name = model.Name
            };
        }
    }
}