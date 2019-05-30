using HonglornBL.Interfaces;
using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System.Collections.Generic;
using System.Linq;

namespace HonglornBL
{
    public sealed class ClassService : Service<ClassManager, Class>
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

        public void Create(IClassModel model)
        {
            CreateEntity(context => context.Class, new Class
            {
                Name = model.Name
            });
        }
    }
}