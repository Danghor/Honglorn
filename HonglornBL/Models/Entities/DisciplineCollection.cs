using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HonglornBL.Interfaces;

namespace HonglornBL.Models.Entities
{
    public class DisciplineCollection : IDisciplineCollection
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(1)]
        public string ClassName { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
    }
}