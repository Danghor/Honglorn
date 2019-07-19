using System;
using System.Data.Entity;
using HonglornBL.Models.Framework;

namespace HonglornBL.MasterData.Class
{
    public sealed class ClassManager : EntityManager<Models.Entities.Class, IClassModel>, IClassModel, IEntityManager<IClassModel>
    {
        internal ClassManager(Guid pKey, HonglornDbFactory contextFactory) : base(pKey, contextFactory) { }

        public string Name
        {
            get => GetValue(@class => @class.Name);
            private set => SetValue((@class, name) => @class.Name = name, value);
        }

        protected override DbSet<Models.Entities.Class> GetDbSet(HonglornDb db) => db.Class;

        protected override Exception CreateNotFoundException(string message) => new ClassNotFoundException(message);

        protected override void CopyValues(IClassModel model, Models.Entities.Class entity)
        {
            entity.Name = model.Name;
        }
    }
}