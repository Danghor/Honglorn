using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HonglornBL.Enums;

namespace HonglornBL.Models.Entities
{
    public class TraditionalReportMeta : Entity
    {
        [Required]
        [Index("IX_FirstAndSecond", 1, IsUnique = true)]
        public Sex Sex { get; set; }

        [Required]
        [Index("IX_FirstAndSecond", 2, IsUnique = true)]
        public byte Age { get; set; }

        [Required]
        public short HonoraryCertificateScore { get; set; }

        [Required]
        public short VictoryCertificateScore { get; set; }
    }
}