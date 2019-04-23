using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HonglornBL.Interfaces;

namespace HonglornBL.Models.Entities
{
    public class DisciplineCollection : Entity, IDisciplineCollection
    {
        [Required]
        [Index("IX_FirstAndSecond", 1, IsUnique = true)]
        public Guid ClassPKey { get; set; }

        [Required]
        [Index("IX_FirstAndSecond", 2, IsUnique = true)]
        public short Year { get; set; }

        // Male
        public Guid? MaleSprintPKey { get; set; }
        public Guid? MaleJumpPKey { get; set; }
        public Guid? MaleThrowPKey { get; set; }
        public Guid? MaleMiddleDistancePKey { get; set; }

        // Female
        public Guid? FemaleSprintPKey { get; set; }
        public Guid? FemaleJumpPKey { get; set; }
        public Guid? FemaleThrowPKey { get; set; }
        public Guid? FemaleMiddleDistancePKey { get; set; }

        // Male
        public virtual Discipline MaleSprint { get; set; }
        public virtual Discipline MaleJump { get; set; }
        public virtual Discipline MaleThrow { get; set; }
        public virtual Discipline MaleMiddleDistance { get; set; }

        // Female
        public virtual Discipline FemaleSprint { get; set; }
        public virtual Discipline FemaleJump { get; set; }
        public virtual Discipline FemaleThrow { get; set; }
        public virtual Discipline FemaleMiddleDistance { get; set; }

        [ForeignKey(nameof(ClassPKey))]
        public virtual Class Class { get; set; }
    }
}