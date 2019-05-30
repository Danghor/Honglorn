using HonglornBL.Interfaces;
using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HonglornBL
{
    public sealed class ClassService : Service<ClassManager, Class, IClassModel>
    {
        internal ClassService(HonglornDbFactory contextFactory) : base(contextFactory) { }

        // Todo: Maybe this is slow, potential for performance increase by just creating the manager that is used later on
        public override ICollection<ClassManager> GetManagers()
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return db.Class.Select(s => s.PKey).ToList().Select(key => new ClassManager(key, ContextFactory)).ToList();
            }
        }

        protected override IDbSet<Class> GetDbSet(HonglornDb context)
        {
            return context.Class;
        }

        protected override Class ConstructEntity(IClassModel model)
        {
            return new Class
            {
                Name = model.Name
            };
        }
    }
}