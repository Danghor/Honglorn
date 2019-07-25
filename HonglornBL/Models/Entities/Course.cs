using HonglornBL.MasterData.Course;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models.Entities
{
    public class Course : IEntity<ICourseModel>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        [Required]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        public Guid ClassPKey { get; set; }

        [ForeignKey(nameof(ClassPKey))]
        public virtual Class Class { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();

        public void AdoptValues(ICourseModel model)
        {
            Name = model.Name;
            ClassPKey = model.ClassPKey;
        }
    }
}