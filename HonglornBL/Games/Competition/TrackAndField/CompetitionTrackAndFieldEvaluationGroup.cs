using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Games.Competition.TrackAndField
{
    public class CompetitionTrackAndFieldEvaluationGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        [Required]
        public Guid GamePKey { get; set; }

        [ForeignKey(nameof(GamePKey))]
        public virtual CompetitionTrackAndFieldGame Game { get; set; }

        public ICollection<CompetitionTrackAndFieldEvaluationGroupStudent> CompetitionTrackAndFieldEvaluationGroupStudents = new HashSet<CompetitionTrackAndFieldEvaluationGroupStudent>();
    }
}