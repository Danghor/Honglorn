using System;
using HonglornBL.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace HonglornBL.Models.Entities
{
    [DebuggerDisplay("{Forename} {Surname}, {Sex}, YOB: {YearOfBirth}, ID: {PKey}")]
    public class Student : Entity
    {
        [Required]
        [StringLength(45)]
        public string Surname { get; set; }

        [Required]
        [StringLength(45)]
        public string Forename { get; set; }

        [Required]
        public Sex Sex { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Competition> Competitions { get; set; }
        public virtual ICollection<StudentCourse> StudentCourseRel { get; set; }

        public Student()
        {
            Competitions = new HashSet<Competition>();
            StudentCourseRel = new HashSet<StudentCourse>();
        }

        internal Student(string forename, string surname, Sex sex, short yearOfBirth) : this()
        {
            Forename = forename;
            Surname = surname;
            Sex = sex;
            DateOfBirth = yearOfBirth;
        }

        internal void AddStudentCourseRel(short year, Course course)
        {
            var rel = new StudentCourse
            {
                DateStart = year,
                Course = course
            };

            StudentCourseRel.Add(rel);
        }
    }
}