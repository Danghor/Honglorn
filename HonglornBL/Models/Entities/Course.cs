using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HonglornBL.MasterData.Course;

namespace HonglornBL.Models.Entities
{
    public class Course : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        [Required]
        [Index(IsUnique = true)]
        [StringLength(25)]
        public string Name { get; set; }

        [Required]
        public Guid ClassPKey { get; set; }

        [ForeignKey(nameof(ClassPKey))]
        public virtual Class Class { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
    }
}