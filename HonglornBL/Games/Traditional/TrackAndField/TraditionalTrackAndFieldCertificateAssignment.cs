using HonglornBL.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Games.Traditional.TrackAndField
{
    public class TraditionalTrackAndFieldCertificateAssignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        [Required]
        [Index("UniqueSexAge", 1, IsUnique = true)]
        public Sex Sex { get; set; }

        [Required]
        [Index("UniqueSexAge", 2, IsUnique = true)]
        public int Age { get; set; }

        public CertificateType CertificateType { get; set; }
    }
}