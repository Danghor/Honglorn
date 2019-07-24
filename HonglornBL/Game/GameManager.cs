using System;
using System.Data.Entity;
using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;

namespace HonglornBL.Game
{
    public abstract class GameManager<TGame, TPerformance> : EntityManager<TGame, IGameModel>, IGameManager
        where TGame : Game<TPerformance>
    {
        public string Name
        {
            get => GetValue(g => g.Name);
            set => SetValue((game, name) => game.Name = name, value);
        }

        public DateTime Date
        {
            get => GetValue(g => g.Date);
            set => SetValue((game, date) => game.Date = date, value);
        }

        protected GameManager(Guid pKey, HonglornDbFactory contextFactory, Func<HonglornDb, DbSet<TGame>> getDbSet) : base(pKey, contextFactory, getDbSet) { }
    }
}