using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using HonglornBL.Models.Entities;
using MySql.Data.Entity;

namespace HonglornBL.Models.Framework {
  [DbConfigurationType(typeof(MySqlEFConfiguration))]
  class HonglornDB : DbContext {
    public virtual DbSet<Competition> Competition { get; set; }
    public virtual DbSet<CompetitionDiscipline> CompetitionDiscipline { get; set; }
    public virtual DbSet<CompetitionReportMeta> CompetitionReportMeta { get; set; }
    public virtual DbSet<DisciplineCollection> DisciplineCollection { get; set; }
    public virtual DbSet<Student> Student { get; set; }
    public virtual DbSet<StudentCourseRel> StudentCourseRel { get; set; }
    public virtual DbSet<TraditionalDiscipline> TraditionalDiscipline { get; set; }
    public virtual DbSet<TraditionalReportMeta> TraditionalReportMeta { get; set; }

    public HonglornDB()
      : base($"name={nameof(HonglornDB)}") {
      Database.SetInitializer(new HonglornDBInitializer());
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }
  }
}