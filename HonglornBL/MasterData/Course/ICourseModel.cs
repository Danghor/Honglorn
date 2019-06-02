using System;

namespace HonglornBL
{
    public interface ICourseModel
    {
        string Name { get; }
        Guid ClassPKey { get; }
    }
}