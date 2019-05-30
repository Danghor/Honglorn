using System;

namespace HonglornBL
{
    public abstract class EntityManager
    {
        internal Guid PKey { get; }

        protected EntityManager(Guid pKey)
        {
            PKey = pKey;
        }
    }
}