namespace HonglornBL.Models {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("bjs.competitionreportmeta")]
  public class competitionreportmeta {
    [Key]
    [Column(TypeName = "year")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public short Year { get; set; }

    public int HonoraryCertificatePercentage { get; set; }

    public int VictoryCertificatePercentage { get; set; }

    public int Grade1Percentage { get; set; }

    public int Grade2Percentage { get; set; }

    public int Grade3Percentage { get; set; }

    public int Grade4Percentage { get; set; }

    public int Grade5Percentage { get; set; }
  }
}