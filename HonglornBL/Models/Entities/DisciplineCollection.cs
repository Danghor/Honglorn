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
        [Required]
        public Guid MaleSprintPKey { get; set; }

        [Required]
        public Guid MaleJumpPKey { get; set; }

        [Required]
        public Guid MaleThrowPKey { get; set; }

        [Required]
        public Guid MaleMiddleDistancePKey { get; set; }

        // Female
        [Required]
        public Guid FemaleSprintPKey { get; set; }

        [Required]
        public Guid FemaleJumpPKey { get; set; }

        [Required]
        public Guid FemaleThrowPKey { get; set; }

        [Required]
        public Guid FemaleMiddleDistancePKey { get; set; }

        #region ForeignKeys

        // Male
        [ForeignKey(nameof(MaleSprintPKey))]
        public virtual Discipline MaleSprint { get; set; }

        [ForeignKey(nameof(MaleJumpPKey))]
        public virtual Discipline MaleJump { get; set; }

        [ForeignKey(nameof(MaleThrowPKey))]
        public virtual Discipline MaleThrow { get; set; }

        [ForeignKey(nameof(MaleMiddleDistancePKey))]
        public virtual Discipline MaleMiddleDistance { get; set; }


        // Female
        [ForeignKey(nameof(FemaleSprintPKey))]
        public virtual Discipline FemaleSprint { get; set; }

        [ForeignKey(nameof(FemaleJumpPKey))]
        public virtual Discipline FemaleJump { get; set; }

        [ForeignKey(nameof(FemaleThrowPKey))]
        public virtual Discipline FemaleThrow { get; set; }

        [ForeignKey(nameof(FemaleMiddleDistancePKey))]
        public virtual Discipline FemaleMiddleDistance { get; set; }

        #endregion
    }
}