using System;
using System.Data.Entity;
using HonglornBL.Models.Framework;

namespace HonglornBL.MasterData.Handicap
{
    public sealed class HandicapManager : EntityManager<Models.Entities.Handicap, IHandicapModel>, IHandicapModel
    {
        internal HandicapManager(Guid pKey, HonglornDbFactory contextFactory, Func<HonglornDb, IDbSet<Models.Entities.Handicap>> getDbSet) : base(pKey, contextFactory, getDbSet) { }

        public string Name
        {
            get => GetValue(g => g.Name);
            set => SetValue((handicap, name) => handicap.Name = name, value);
        }

        protected override Exception CreateNotFoundException(string message) => new HandicapNotFoundException(message);
    }
}