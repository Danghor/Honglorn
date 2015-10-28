using System;
using System.ComponentModel.DataAnnotations;

namespace HonglornBL.Models {
  public class TraditionalReportMeta {
    [Key]
    public Guid PKey { get; set; }

    [Required]
    public Prerequisites.Sex Sex { get; set; }

    [Required]
    public byte Age { get; set; }

    [Required]
    public ushort HonoraryCertificateScore { get; set; }

    [Required]
    public ushort VictoryCertificateScore { get; set; }
  }
}