using HonglornBL.Games.Traditional.TrackAndField;
using HonglornBL.Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HonglornBL
{
    public class TraditionalTrackAndFieldGameManager : EntityManager<TraditionalTrackAndFieldGame>
    {
        internal TraditionalTrackAndFieldGameManager(Guid pKey, HonglornDbFactory contextFactory) : base(pKey, contextFactory) { }

        public string GameName
        {
            get => GetValue(g => g.Name);
            set => SetValue((game, name) => game.Name = name, value);
        }

        public DateTime GameDate
        {
            get => GetValue(g => g.Date);
            set => SetValue((game, date) => game.Date = date, value);
        }

        protected override Exception CreateNotFoundException(string message)
        {
            return new GameNotFoundException(message);
        }

        protected override DbSet<TraditionalTrackAndFieldGame> GetDbSet(HonglornDb db)
        {
            return db.TraditionalTrackAndFieldGame;
        }

        public ICollection<TraditionalTrackAndFieldResult> CalculateResults()
        {
            using (HonglornDb db = ContextFactory.CreateContext())
            {
                return Entity(db).GamePerformances.Select(performance => performance.CalculateResult(db)).ToList();
            }
        }
    }
}