using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using HonglornBL.MasterData;
using HonglornBL.MasterData.Student;

namespace HonglornBL.Models.Entities
{
    [DebuggerDisplay("{Forename} {Surname}, {Sex}, YOB: {DateOfBirth}, ID: {PKey}")]
    public class Student : IEntity
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

        public ICollection<StudentHandicap> StudentHandicaps { get; set; } = new HashSet<StudentHandicap>();

        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
    }
}