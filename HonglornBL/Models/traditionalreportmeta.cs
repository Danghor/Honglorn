namespace HonglornBL.Models {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("bjs.traditionalreportmeta")]
  public class traditionalreportmeta {
    [Key]
    public Guid PKey { get; set; }

    [Column(TypeName = "enum")]
    [Required]
    [StringLength(65532)]
    public string Sex { get; set; }

    [Column(TypeName = "uint")]
    public long Age { get; set; }

    public int HonoraryCertificateScore { get; set; }

    public int VictoryCertificateScore { get; set; }
  }
}