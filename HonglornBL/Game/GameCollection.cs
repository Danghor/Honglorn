using System.Collections.Generic;
using HonglornBL.Game.Competition.TrackAndField;
using HonglornBL.Game.Traditional.TrackAndField;

namespace HonglornBL.Game
{
    public class GameCollection
    {
        public ICollection<TraditionalTrackAndFieldGameManager> TraditionalTrackAndFieldGames { get; internal set; }
        public ICollection<CompetitionTrackAndFieldGameManager> CompetitionTrackAndFieldGames { get; internal set; }
    }
}