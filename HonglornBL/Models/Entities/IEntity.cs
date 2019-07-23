using System;

namespace HonglornBL.Models.Entities
{
    public interface IEntity<in TModel>
    {
        Guid PKey { get; set; }
        void AdoptValues(TModel model);
    }
}