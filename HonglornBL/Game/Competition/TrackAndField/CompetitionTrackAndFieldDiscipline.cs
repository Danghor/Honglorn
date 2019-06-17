using System.ComponentModel.DataAnnotations;
using HonglornBL.Models.Entities;

namespace HonglornBL.Game.Competition.TrackAndField
{
    public class CompetitionTrackAndFieldDiscipline : Discipline
    {
        [Required]
        public bool LowIsBetter { get; set; }
    }
}