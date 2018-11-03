using System.Data.Entity;
using HonglornBL.Models.Entities;

namespace HonglornAUT
{
    public partial class TraditionalCalculatorTest
    {
        sealed class TestDb : DbContext
        {
            public DbSet<Competition> Competition { get; set; }
            public DbSet<CompetitionDiscipline> CompetitionDiscipline { get; set; }
            public DbSet<CompetitionReportMeta> CompetitionReportMeta { get; set; }
            public DbSet<DisciplineCollection> DisciplineCollection { get; set; }
            public DbSet<Student> Student { get; set; }
            public DbSet<StudentCourseRel> StudentCourseRel { get; set; }
            public DbSet<TraditionalDiscipline> TraditionalDiscipline { get; set; }
            public DbSet<TraditionalReportMeta> TraditionalReportMeta { get; set; }

            public TestDb(string connectionString) : base(connectionString)
            {
                Database.SetInitializer(new TestDbInitializer());
            }
        }
    }
}