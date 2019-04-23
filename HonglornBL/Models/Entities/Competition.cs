using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models.Entities
{
    public class Competition : Entity
    {
        [Required]
        [Index("IX_FirstAndSecond", 1, IsUnique = true)]
        public Guid StudentPKey { get; set; }

        [Required]
        [Index("IX_FirstAndSecond", 2, IsUnique = true)]
        public short Year { get; set; }

        public float? Sprint { get; set; }

        public float? Jump { get; set; }

        public float? Throw { get; set; }

        public float? MiddleDistance { get; set; }

        [ForeignKey(nameof(StudentPKey))]
        public virtual Student Student { get; set; }
    }
}