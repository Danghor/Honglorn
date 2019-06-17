using System.ComponentModel.DataAnnotations;

namespace HonglornBL.Game.Traditional.TrackAndField
{
    public abstract class TraditionalTrackAndFieldRunningDiscipline : TraditionalTrackAndFieldDiscipline
    {
        [Required]
        public short Distance { get; set; }
    }
}