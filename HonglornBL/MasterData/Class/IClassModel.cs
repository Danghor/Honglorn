using System;

namespace HonglornBL.Interfaces
{
    public interface IClassModel
    {
        Guid PKey { get; }
        string Name { get; }
    }
}