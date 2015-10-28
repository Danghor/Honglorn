using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models {
  public class CompetitionReportMeta {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public ushort Year { get; set; }

    public byte HonoraryCertificatePercentage { get; set; } = 0;

    public byte VictoryCertificatePercentage { get; set; } = 0;

    public byte Grade1Percentage { get; set; } = 0;

    public byte Grade2Percentage { get; set; } = 0;

    public byte Grade3Percentage { get; set; } = 0;

    public byte Grade4Percentage { get; set; } = 0;

    public byte Grade5Percentage { get; set; } = 0;
  }
}