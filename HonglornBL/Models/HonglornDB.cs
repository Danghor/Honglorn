namespace HonglornBL.Models {
  using System;
  using System.Data.Entity;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Linq;

  public class HonglornDB : DbContext {
    public virtual DbSet<_class> _class { get; set; }
    public virtual DbSet<classdisciplinerel> classdisciplinerel { get; set; }
    public virtual DbSet<competition> competition { get; set; }
    public virtual DbSet<competitiondiscipline> competitiondiscipline { get; set; }
    public virtual DbSet<competitiondisciplinecollection> competitiondisciplinecollection { get; set; }
    public virtual DbSet<competitionreportmeta> competitionreportmeta { get; set; }
    public virtual DbSet<courseclassrel> courseclassrel { get; set; }
    public virtual DbSet<student> student { get; set; }
    public virtual DbSet<studentcourserel> studentcourserel { get; set; }
    public virtual DbSet<traditionaldiscipline> traditionaldiscipline { get; set; }
    public virtual DbSet<traditionaldisciplinecollection> traditionaldisciplinecollection { get; set; }
    public virtual DbSet<traditionalreportmeta> traditionalreportmeta { get; set; }

    public HonglornDB()
      : base("name=HonglornDB") {}

    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
      modelBuilder.Entity<_class>()
        .Property(e => e.Name)
        .IsUnicode(false);

      modelBuilder.Entity<_class>()
        .HasMany(e => e.classdisciplinerel)
        .WithRequired(e => e._class)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<_class>()
        .HasMany(e => e.courseclassrel)
        .WithRequired(e => e._class)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<classdisciplinerel>()
        .Property(e => e.ClassName)
        .IsUnicode(false);

      modelBuilder.Entity<competitiondiscipline>()
        .Property(e => e.Type)
        .IsUnicode(false);

      modelBuilder.Entity<competitiondiscipline>()
        .Property(e => e.Name)
        .IsUnicode(false);

      modelBuilder.Entity<competitiondiscipline>()
        .Property(e => e.Unit)
        .IsUnicode(false);

      modelBuilder.Entity<competitiondiscipline>()
        .HasMany(e => e.competitiondisciplinecollection)
        .WithRequired(e => e.competitiondiscipline)
        .HasForeignKey(e => e.FemaleJumpPKey)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<competitiondiscipline>()
        .HasMany(e => e.competitiondisciplinecollection1)
        .WithRequired(e => e.competitiondiscipline1)
        .HasForeignKey(e => e.FemaleMiddleDistancePKey)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<competitiondiscipline>()
        .HasMany(e => e.competitiondisciplinecollection2)
        .WithRequired(e => e.competitiondiscipline2)
        .HasForeignKey(e => e.FemaleSprintPKey)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<competitiondiscipline>()
        .HasMany(e => e.competitiondisciplinecollection3)
        .WithRequired(e => e.competitiondiscipline3)
        .HasForeignKey(e => e.FemaleThrowPKey)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<competitiondiscipline>()
        .HasMany(e => e.competitiondisciplinecollection4)
        .WithRequired(e => e.competitiondiscipline4)
        .HasForeignKey(e => e.MaleJumpPKey)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<competitiondiscipline>()
        .HasMany(e => e.competitiondisciplinecollection5)
        .WithRequired(e => e.competitiondiscipline5)
        .HasForeignKey(e => e.MaleMiddleDistancePKey)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<competitiondiscipline>()
        .HasMany(e => e.competitiondisciplinecollection6)
        .WithRequired(e => e.competitiondiscipline6)
        .HasForeignKey(e => e.MaleSprintPKey)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<competitiondiscipline>()
        .HasMany(e => e.competitiondisciplinecollection7)
        .WithRequired(e => e.competitiondiscipline7)
        .HasForeignKey(e => e.MaleThrowPKey)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<courseclassrel>()
        .Property(e => e.CourseName)
        .IsUnicode(false);

      modelBuilder.Entity<courseclassrel>()
        .Property(e => e.ClassName)
        .IsUnicode(false);

      modelBuilder.Entity<courseclassrel>()
        .HasMany(e => e.studentcourserel)
        .WithRequired(e => e.courseclassrel)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<student>()
        .Property(e => e.Surname)
        .IsUnicode(false);

      modelBuilder.Entity<student>()
        .Property(e => e.Forename)
        .IsUnicode(false);

      modelBuilder.Entity<student>()
        .Property(e => e.Sex)
        .IsUnicode(false);

      modelBuilder.Entity<student>()
        .HasMany(e => e.competition)
        .WithRequired(e => e.student)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<student>()
        .HasMany(e => e.studentcourserel)
        .WithRequired(e => e.student)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<studentcourserel>()
        .Property(e => e.CourseName)
        .IsUnicode(false);

      modelBuilder.Entity<traditionaldiscipline>()
        .Property(e => e.Type)
        .IsUnicode(false);

      modelBuilder.Entity<traditionaldiscipline>()
        .Property(e => e.Sex)
        .IsUnicode(false);

      modelBuilder.Entity<traditionaldiscipline>()
        .Property(e => e.Name)
        .IsUnicode(false);

      modelBuilder.Entity<traditionaldiscipline>()
        .Property(e => e.UnitSymbol)
        .IsUnicode(false);

      modelBuilder.Entity<traditionaldiscipline>()
        .Property(e => e.Measurement)
        .IsUnicode(false);

      modelBuilder.Entity<traditionaldiscipline>()
        .HasMany(e => e.traditionaldisciplinecollection)
        .WithRequired(e => e.traditionaldiscipline)
        .HasForeignKey(e => e.FemaleJumpPKey)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<traditionaldiscipline>()
        .HasMany(e => e.traditionaldisciplinecollection1)
        .WithRequired(e => e.traditionaldiscipline1)
        .HasForeignKey(e => e.FemaleMiddleDistancePKey)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<traditionaldiscipline>()
        .HasMany(e => e.traditionaldisciplinecollection2)
        .WithRequired(e => e.traditionaldiscipline2)
        .HasForeignKey(e => e.FemaleSprintPKey)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<traditionaldiscipline>()
        .HasMany(e => e.traditionaldisciplinecollection3)
        .WithRequired(e => e.traditionaldiscipline3)
        .HasForeignKey(e => e.FemaleThrowPKey)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<traditionaldiscipline>()
        .HasMany(e => e.traditionaldisciplinecollection4)
        .WithRequired(e => e.traditionaldiscipline4)
        .HasForeignKey(e => e.MaleJumpPKey)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<traditionaldiscipline>()
        .HasMany(e => e.traditionaldisciplinecollection5)
        .WithRequired(e => e.traditionaldiscipline5)
        .HasForeignKey(e => e.MaleMiddleDistancePKey)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<traditionaldiscipline>()
        .HasMany(e => e.traditionaldisciplinecollection6)
        .WithRequired(e => e.traditionaldiscipline6)
        .HasForeignKey(e => e.MaleSprintPKey)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<traditionaldiscipline>()
        .HasMany(e => e.traditionaldisciplinecollection7)
        .WithRequired(e => e.traditionaldiscipline7)
        .HasForeignKey(e => e.MaleThrowPKey)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<traditionalreportmeta>()
        .Property(e => e.Sex)
        .IsUnicode(false);
    }
  }
}