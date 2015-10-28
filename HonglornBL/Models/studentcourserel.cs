using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models {
  public class StudentCourseRel {
    [Key]
    [Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid StudentPKey { get; set; }

    [Key]
    [Column(Order = 1)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public ushort Year { get; set; }

    [Required]
    [StringLength(3)]
    public string CourseName { get; set; }

    [ForeignKey(nameof(StudentPKey))]
    public virtual Student Student { get; set; }
  }
}