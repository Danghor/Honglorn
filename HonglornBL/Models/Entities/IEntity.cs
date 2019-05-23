using System;

namespace HonglornBL.Models.Entities
{
    public interface IEntity
    {
        Guid PKey { get; set; }
    }
}