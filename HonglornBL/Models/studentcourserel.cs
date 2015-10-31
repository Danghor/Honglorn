using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;

namespace HonglornBL.Models {
  public class StudentCourseRel {
    [Key]
    [Column(Order = 0)]
    [DatabaseGenerated(None)]
    public Guid StudentPKey { get; set; }

    [Key]
    [Column(Order = 1)]
    [DatabaseGenerated(None)]
    public short Year { get; set; }

    [Required]
    [StringLength(3)]
    public string CourseName { get; set; }

    [ForeignKey(nameof(StudentPKey))]
    public virtual Student Student { get; set; }
  }
}