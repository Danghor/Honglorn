namespace HonglornBL.Models {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("bjs.competition")]
  public class competition {
    [Key]
    [Column(Order = 0)]
    public Guid StudentPKey { get; set; }

    [Key]
    [Column(Order = 1, TypeName = "year")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public short Year { get; set; }

    public float? Sprint { get; set; }

    public float? Jump { get; set; }

    public float? Throw { get; set; }

    public float? MiddleDistance { get; set; }

    public virtual student student { get; set; }
  }
}