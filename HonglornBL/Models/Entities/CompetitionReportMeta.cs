using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models.Entities
{
    public class CompetitionReportMeta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Year { get; set; }

        public byte HonoraryCertificatePercentage { get; set; }

        public byte VictoryCertificatePercentage { get; set; }

        public byte Grade1Percentage { get; set; }

        public byte Grade2Percentage { get; set; }

        public byte Grade3Percentage { get; set; }

        public byte Grade4Percentage { get; set; }

        public byte Grade5Percentage { get; set; }
    }
}