using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using static System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;

namespace HonglornBL.Models {
  [SuppressMessage("ReSharper", "MemberCanBeInternal")]
  public class Student {
    [Key]
    [DatabaseGenerated(None)]
    public Guid PKey { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(45)]
    public string Surname { get; set; }

    [Required]
    [StringLength(45)]
    public string Forename { get; set; }

    [Required]
    public Prerequisites.Sex Sex { get; set; }

    [Required]
    public short YearOfBirth { get; set; }

    public virtual ICollection<Competition> competition { get; set; }
    public virtual ICollection<StudentCourseRel> studentCourseRel { get; set; }

    public Student() {
      competition = new HashSet<Competition>();
      studentCourseRel = new HashSet<StudentCourseRel>();
    }

    internal void AddStudentCourseRel(short year, string courseName) {
      StudentCourseRel rel = new StudentCourseRel {
        Year = year,
        CourseName = courseName
      };

      studentCourseRel.Add(rel);
    }
  }
}