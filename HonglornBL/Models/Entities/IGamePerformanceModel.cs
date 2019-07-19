using System;

namespace HonglornBL.Models.Entities
{
    public interface IGamePerformanceModel
    {
        Guid StudentPKey { get; }
        Guid GamePKey { get; }
    }
}