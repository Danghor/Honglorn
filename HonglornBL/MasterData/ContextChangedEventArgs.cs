using HonglornBL.Models.Framework;
using System;

namespace HonglornBL.MasterData
{
    public class ContextChangedEventArgs : EventArgs
    {
        public HonglornDb Context { get; }

        public ContextChangedEventArgs(HonglornDb context)
        {
            Context = context;
        }
    }
}
