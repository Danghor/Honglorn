namespace HonglornBL.Models {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("bjs.studentcourserel")]
  public class studentcourserel {
    [Key]
    [Column(Order = 0)]
    public Guid StudentPKey { get; set; }

    [Column(TypeName = "char")]
    [Required]
    [StringLength(3)]
    public string CourseName { get; set; }

    [Key]
    [Column(Order = 1, TypeName = "year")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public short Year { get; set; }

    public virtual courseclassrel courseclassrel { get; set; }

    public virtual student student { get; set; }
  }
}