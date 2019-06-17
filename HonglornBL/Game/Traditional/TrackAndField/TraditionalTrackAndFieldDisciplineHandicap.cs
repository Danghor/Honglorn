using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HonglornBL.Models.Entities;

namespace HonglornBL.Game.Traditional.TrackAndField
{
    public class TraditionalTrackAndFieldDisciplineHandicap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        [Required]
        public Guid DisciplinePKey { get; set; }

        [ForeignKey(nameof(DisciplinePKey))]
        public virtual TraditionalTrackAndFieldDiscipline Discipline { get; set; }

        [Required]
        public Guid HandicapPKey { get; set; }

        [ForeignKey(nameof(HandicapPKey))]
        public virtual Handicap Handicap { get; set; }

        [Required]
        public double Factor { get; set; }
    }
}