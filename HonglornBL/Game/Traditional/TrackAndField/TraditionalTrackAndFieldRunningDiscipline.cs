using System.ComponentModel.DataAnnotations;

namespace HonglornBL.Games.Traditional.TrackAndField
{
    public abstract class TraditionalTrackAndFieldRunningDiscipline : TraditionalTrackAndFieldDiscipline
    {
        [Required]
        public short Distance { get; set; }
    }
}