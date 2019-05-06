using System.Collections.Generic;

namespace HonglornBL
{
    public class GameCollection
    {
        public ICollection<TraditionalTrackAndFieldGame> TraditionalTrackAndFieldGames { get; internal set; }
        public ICollection<TraditionalTrackAndFieldGame> CompetitionTrackAndFieldGames { get; internal set; }
    }
}