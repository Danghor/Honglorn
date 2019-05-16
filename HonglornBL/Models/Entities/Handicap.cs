﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models.Entities
{
    public class Handicap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        [Required]
        [Index(IsUnique = true)]
        [StringLength(5)]
        public string Name { get; set; }

        public virtual ICollection<StudentHandicap> StudentHandicaps { get; set; }

        public Handicap(string name)
        {
            Name = name;
        }
    }
}