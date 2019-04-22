using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models.Entities
{
    public class StudentCourseRel
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid StudentPKey { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Year { get; set; }

        [Required]
        public Guid CoursePKey { get; set; }

        [ForeignKey(nameof(StudentPKey))]
        public virtual Student Student { get; set; }

        [ForeignKey(nameof(CoursePKey))]
        public virtual Course Course { get; set; }
    }
}