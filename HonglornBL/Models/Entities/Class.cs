﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models.Entities
{
    public class Class : Entity
    {
        private string name;

        [Required]
        [Index(IsUnique = true)]
        [StringLength(25)]
        public string Name
        {
            get => name;
            set => OnPropertyChanged(out name, value);
        }

        public virtual ObservableCollection<Course> Courses { get; set; } = new ObservableCollection<Course>();
    }
}