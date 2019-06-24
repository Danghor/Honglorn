using HonglornBL.MasterData.StudentHandicap;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models.Entities
{
    public class StudentHandicap : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        [Required]
        public Guid StudentPKey { get; set; }

        [ForeignKey(nameof(StudentPKey))]
        public virtual Student Student { get; set; }

        [Required]
        public Guid HandicapPKey { get; set; }

        [ForeignKey(nameof(HandicapPKey))]
        public virtual Handicap Handicap { get; set; }

        [Required]
        public DateTime DateStart { get; set; }

        public DateTime? DateEnd { get; set; }
    }
}