using System;
using HonglornBL.Models.Framework;

namespace HonglornBL
{
    public class CompetitionTrackAndFieldGameManager
    {
        internal HonglornDbFactory ContextFactory { get; set; }

        Guid GamePKey { get; }

        internal CompetitionTrackAndFieldGameManager(Guid gamePKey, HonglornDbFactory contextFactory)
        {
            GamePKey = gamePKey;
            ContextFactory = contextFactory;
        }
    }
}