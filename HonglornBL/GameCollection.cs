using HonglornBL.Games.Traditional.TrackAndField;
using System.Collections.Generic;

namespace HonglornBL
{
    public class GameCollection
    {
        public ICollection<TraditionalTrackAndFieldGame> TraditionalTrackAndFieldGames { get; internal set; }
        public ICollection<CompetitionTrackAndFieldGame> CompetitionTrackAndFieldGames { get; internal set; }
    }
}