using System;
using HonglornBL.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace HonglornBL.Models.Entities
{
    [DebuggerDisplay("{Forename} {Surname}, {Sex}, YOB: {YearOfBirth}, ID: {PKey}")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(45)]
        public string Surname { get; set; }

        [Required]
        [StringLength(45)]
        public string Forename { get; set; }

        [Required]
        public Sex Sex { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<StudentCourse> StudentCourseRel { get; set; } = new HashSet<StudentCourse>();
    }
}