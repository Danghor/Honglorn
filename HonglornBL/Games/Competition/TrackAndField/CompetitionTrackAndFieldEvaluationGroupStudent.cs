using HonglornBL.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Games.Competition.TrackAndField
{
    // TODO: Use unique index to prevent the same student from being added multiple times to the same evaluationgroup
    public class CompetitionTrackAndFieldEvaluationGroupStudent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        [Required]
        public Guid EvaluationGroupPKey { get; set; }

        [ForeignKey(nameof(EvaluationGroupPKey))]
        public virtual CompetitionTrackAndFieldEvaluationGroup EvaluationGroup { get; set; }

        [Required]
        public Guid StudentPKey { get; set; }

        [ForeignKey(nameof(StudentPKey))]
        public virtual Student Student { get; set; }
    }
}