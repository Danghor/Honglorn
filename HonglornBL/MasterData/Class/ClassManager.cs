using HonglornBL.Exceptions;
using HonglornBL.Interfaces;
using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;
using System.Data.Entity;

namespace HonglornBL
{
    public class ClassManager : EntityManager<Class>, IClassModel, IEntityManager<IClassModel>
    {
        internal ClassManager(Guid pKey, HonglornDbFactory contextFactory) : base(pKey, contextFactory) { }

        public void Update(IClassModel model)
        {
            Name = model.Name;
        }

        public string Name
        {
            get => GetValue(@class => @class.Name);
            private set => SetValue((@class, name) => @class.Name = name, value);
        }

        protected override DbSet<Class> GetDbSet(HonglornDb db) => db.Class;

        protected override Exception CreateNotFoundException(string message) => new ClassNotFoundException(message);
    }
}