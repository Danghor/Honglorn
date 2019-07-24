using System;
using System.Data.Entity;
using HonglornBL.Models.Framework;

namespace HonglornBL.MasterData.Class
{
    public sealed class ClassManager : EntityManager<Models.Entities.Class, IClassModel>, IClassModel, IEntityManager<IClassModel>
    {
        internal ClassManager(Guid pKey, HonglornDbFactory contextFactory, Func<HonglornDb, IDbSet<Models.Entities.Class>> getDbSet) : base(pKey, contextFactory, getDbSet) { }

        public string Name
        {
            get => GetValue(@class => @class.Name);
            private set => SetValue((@class, name) => @class.Name = name, value);
        }

        protected override Exception CreateNotFoundException(string message) => new ClassNotFoundException(message);
    }
}