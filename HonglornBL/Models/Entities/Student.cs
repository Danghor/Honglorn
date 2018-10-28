using HonglornBL.Models.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using HonglornBL.Enums;

namespace HonglornBL.Models.Entities
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(45)]
        public string Surname { get; set; }

        [Required]
        [StringLength(45)]
        public string Forename { get; set; }

        [Required]
        public Sex Sex { get; set; }

        [Required]
        public short YearOfBirth { get; set; }

        public virtual ICollection<Competition> Competitions { get; set; }
        public virtual ICollection<StudentCourseRel> StudentCourseRel { get; set; }

        public Student()
        {
            Competitions = new HashSet<Competition>();
            StudentCourseRel = new HashSet<StudentCourseRel>();
        }

        internal Student(short year, string courseName) : this()
        {
            AddStudentCourseRel(year, courseName);
        }

        internal void AddStudentCourseRel(short year, string courseName)
        {
            var rel = new StudentCourseRel
            {
                Year = year,
                CourseName = courseName
            };

            StudentCourseRel.Add(rel);
        }

        public string CourseNameByYear(short year)
        {
            using (var db = new HonglornDb())
            {
                return (from rel in db.StudentCourseRel
                        where rel.Year == year && rel.StudentPKey == PKey
                        select rel.CourseName).Single();
            }
        }

        public override string ToString() => $"{Forename} {Surname}, {Sex}, YOB: {YearOfBirth}, ID: {PKey}";
    }
}