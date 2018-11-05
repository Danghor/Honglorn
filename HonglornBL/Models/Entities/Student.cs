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

        internal Student(string forename, string surname, Sex sex, short yearOfBirth) : this()
        {
            Forename = forename;
            Surname = surname;
            Sex = sex;
            YearOfBirth = yearOfBirth;
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

        //todo: currently throws objectDisposedException
        public string CourseNameByYear(short year)
        {
            return (from rel in StudentCourseRel
                    where rel.Year == year && rel.StudentPKey == PKey
                    select rel.CourseName).Single();
        }

        public override string ToString() => $"{Forename} {Surname}, {Sex}, YOB: {YearOfBirth}, ID: {PKey}";
    }
}