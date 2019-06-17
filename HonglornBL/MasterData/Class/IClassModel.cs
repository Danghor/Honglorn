using System;

namespace HonglornBL.MasterData.Class
{
    public interface IClassModel
    {
        Guid PKey { get; }
        string Name { get; }
    }
}