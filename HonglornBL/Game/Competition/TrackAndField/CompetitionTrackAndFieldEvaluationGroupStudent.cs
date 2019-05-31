using HonglornBL.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Games.Competition.TrackAndField
{
    public class CompetitionTrackAndFieldEvaluationGroupStudent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        [Required]
        [Index("CompetitionTrackAndFieldEvaluationGroupStudent_Unique", 1, IsUnique = true)]
        public Guid EvaluationGroupPKey { get; set; }

        [ForeignKey(nameof(EvaluationGroupPKey))]
        public virtual CompetitionTrackAndFieldEvaluationGroup EvaluationGroup { get; set; }

        [Required]
        [Index("CompetitionTrackAndFieldEvaluationGroupStudent_Unique", 2, IsUnique = true)]
        public Guid StudentPKey { get; set; }

        [ForeignKey(nameof(StudentPKey))]
        public virtual Student Student { get; set; }
    }
}