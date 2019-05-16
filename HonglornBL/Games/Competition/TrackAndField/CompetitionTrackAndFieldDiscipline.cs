using HonglornBL.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace HonglornBL.Games.Competition.TrackAndField
{
    public abstract class CompetitionTrackAndFieldDiscipline : Discipline
    {
        [Required]
        public bool LowIsBetter { get; set; }
    }
}