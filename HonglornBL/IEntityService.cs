using System.Collections.Generic;

namespace HonglornBL
{
    public interface IEntityService<TManager, TModel>
    {
        ICollection<TManager> GetManagers();
        void Delete(TManager manager);
        void Create(TModel model);
    }
}