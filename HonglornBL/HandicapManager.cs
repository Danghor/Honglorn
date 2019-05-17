using HonglornBL.Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HonglornBL
{
    public class HandicapManager
    {
        internal HonglornDbFactory ContextFactory { get; set; }

        Guid HandicapPKey { get; }

        internal HandicapManager(Guid handicapPKey, HonglornDbFactory contextFactory)
        {
            HandicapPKey = handicapPKey;
            ContextFactory = contextFactory;
        }
    }
}
