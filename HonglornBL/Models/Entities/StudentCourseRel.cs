using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models.Entities
{
    public class StudentCourseRel : Entity
    {
        [Required]
        [Index("IX_FirstAndSecond", 1, IsUnique = true)]
        public Guid StudentPKey { get; set; }

        [Required]
        [Index("IX_FirstAndSecond", 2, IsUnique = true)]
        public short Year { get; set; }

        [Required]
        public Guid CoursePKey { get; set; }

        [ForeignKey(nameof(StudentPKey))]
        public virtual Student Student { get; set; }

        [ForeignKey(nameof(CoursePKey))]
        public virtual Course Course { get; set; }
    }
}