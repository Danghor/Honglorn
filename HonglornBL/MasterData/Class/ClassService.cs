using HonglornBL.Interfaces;
using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;
using System.Data.Entity;

namespace HonglornBL
{
    public sealed class ClassService : EntityService<ClassManager, Class, IClassModel>
    {
        internal ClassService(HonglornDbFactory contextFactory) : base(contextFactory) { }

        protected override ClassManager CreateManager(Guid pKey, HonglornDbFactory contextFactory)
        {
            return new ClassManager(pKey, contextFactory);
        }

        protected override IDbSet<Class> GetDbSet(HonglornDb context)
        {
            return context.Class;
        }

        protected override Class CreateEntity(IClassModel model)
        {
            return new Class
            {
                Name = model.Name
            };
        }
    }
}