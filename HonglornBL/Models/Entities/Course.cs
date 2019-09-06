using HonglornBL.MasterData.Course;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models.Entities
{
    public class Course : Entity
    {
        private string name;

        [Required]
        [Index(IsUnique = true)]
        [StringLength(25)]
        public string Name
        {
            get => name;
            set => OnPropertyChanged(out name ,value);
        }

        [Required]
        public Guid ClassPKey { get; set; }

        [ForeignKey(nameof(ClassPKey))]
        public virtual Class Class { get; set; }

        public virtual ObservableCollection<StudentCourse> StudentCourses { get; set; } = new ObservableCollection<StudentCourse>();

        public override string ToString()
        {
            return Name;
        }
    }
}