using System.Collections.Generic;

namespace HonglornBL
{
    public class GameCollection
    {
        public ICollection<TraditionalTrackAndFieldGameManager> TraditionalTrackAndFieldGames { get; internal set; }
        public ICollection<CompetitionTrackAndFieldGameManager> CompetitionTrackAndFieldGames { get; internal set; }
    }
}