using System;
using System.ComponentModel.DataAnnotations;

namespace HonglornBL.Models.Entities {
  public class TraditionalReportMeta {
    [Key]
    public Guid PKey { get; set; } = Guid.NewGuid();

    [Required]
    public Prerequisites.Sex Sex { get; set; }

    [Required]
    public byte Age { get; set; }

    [Required]
    public short HonoraryCertificateScore { get; set; }

    [Required]
    public short VictoryCertificateScore { get; set; }
  }
}