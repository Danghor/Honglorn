﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models.Entities
{
    public class Competition
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid StudentPKey { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Year { get; set; }

        public float? Sprint { get; set; }

        public float? Jump { get; set; }

        public float? Throw { get; set; }

        public float? MiddleDistance { get; set; }

        [ForeignKey(nameof(StudentPKey))]
        public virtual Student Student { get; set; }
    }
}