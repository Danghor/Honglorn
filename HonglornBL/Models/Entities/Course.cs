﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models.Entities
{
    public class Course : Entity
    {
        [Required]
        [Index(IsUnique = true)]
        [StringLength(25)]
        public string Name { get; set; }

        [Required]
        public Guid ClassPKey { get; set; }

        [ForeignKey(nameof(ClassPKey))]
        public virtual Class Class { get; set; }
    }
}