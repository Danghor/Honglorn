using HonglornBL.MasterData;
using HonglornBL.Models.Entities;

namespace HonglornWPF.ViewModels
{
    class LookupViewModel<TService, TEntity> : ServiceViewModel<TService, TEntity>
        where TService : NGService<TEntity>
        where TEntity : Entity
    {
        internal LookupViewModel(TService service) : base(service) { }
    }
}
