using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models {
  public class Competition {
    [Key]
    [Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid StudentPKey { get; set; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public ushort Year { get; set; }

    public float? Sprint { get; set; }

    public float? Jump { get; set; }

    public float? Throw { get; set; }

    public float? MiddleDistance { get; set; }

    [ForeignKey(nameof(StudentPKey))]
    public virtual Student Student { get; set; }
  }
}