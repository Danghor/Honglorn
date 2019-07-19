using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models.Entities
{
    public class StudentCourse : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        [Required]
        public Guid StudentPKey { get; set; }

        [Required]
        public DateTime DateStart { get; set; }

        [Required]
        public Guid CoursePKey { get; set; }

        [ForeignKey(nameof(StudentPKey))]
        public virtual Student Student { get; set; }

        [ForeignKey(nameof(CoursePKey))]
        public virtual Course Course { get; set; }

        public DateTime? DateEnd { get; set; }
    }
}