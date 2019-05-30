using System;

namespace HonglornBL
{
    public abstract class EntityManager
    {
        internal Guid PKey { get; }

        public EntityManager(Guid pKey)
        {
            PKey = pKey;
        }
    }
}