using System;

namespace HonglornBL.Models.Entities
{
    public interface IEntity<TModel>
    {
        Guid PKey { get; set; }
        void AdoptValues(TModel model);
    }
}