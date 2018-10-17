using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using HonglornBL.Models.Entities;

namespace HonglornBL.Models.Framework
{
    class HonglornDb : DbContext
    {
        public virtual DbSet<Competition> Competition { get; set; }
        public virtual DbSet<CompetitionDiscipline> CompetitionDiscipline { get; set; }
        public virtual DbSet<CompetitionReportMeta> CompetitionReportMeta { get; set; }
        public virtual DbSet<DisciplineCollection> DisciplineCollection { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentCourseRel> StudentCourseRel { get; set; }
        public virtual DbSet<TraditionalDiscipline> TraditionalDiscipline { get; set; }
        public virtual DbSet<TraditionalReportMeta> TraditionalReportMeta { get; set; }

        public HonglornDb() : base($"name=local")
        {
            Database.SetInitializer(new HonglornDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}