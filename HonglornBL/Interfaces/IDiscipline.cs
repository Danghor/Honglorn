using System;

namespace HonglornBL.Interfaces
{
    public interface IDiscipline
    {
        Guid PKey { get; }
        string ToString();
    }
}
