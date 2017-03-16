using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models.Entities
{
    public class TraditionalReportMeta
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Prerequisites.Sex Sex { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public byte Age { get; set; }

        [Required]
        public short HonoraryCertificateScore { get; set; }

        [Required]
        public short VictoryCertificateScore { get; set; }
    }
}