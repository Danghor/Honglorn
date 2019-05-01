using HonglornBL.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL
{
    public class StudentEvent : Entity
    {
        [Required]
        public Guid StudentPKey { get; set; }

        [ForeignKey(nameof(StudentPKey))]
        public virtual Student Student { get; set; }

        [Required]
        public Guid EventPKey { get; set; }

        [ForeignKey(nameof(EventPKey))]
        public virtual Event Event { get; set; }
    }
}