using HonglornBL.Games.Traditional.TrackAndField;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using HonglornBL.Games.Competition.TrackAndField;
using HonglornBL.Models.Entities;

namespace HonglornBL.Models.Framework
{
    class HonglornDb : DbContext
    {
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<TraditionalTrackAndFieldPerformance> TraditionalTrackAndFieldPerformance { get; set; }
        public virtual DbSet<CompetitionTrackAndFieldPerformance> CompetitionTrackAndFieldPerformance { get; set; }
        public virtual DbSet<TraditionalTrackAndFieldGame> TraditionalTrackAndFieldGame { get; set; }
        public virtual DbSet<CompetitionTrackAndFieldGame> CompetitionTrackAndFieldGame { get; set; }
        public virtual DbSet<TraditionalTrackAndFieldDiscipline> TraditionalTrackAndFieldDiscipline { get; set; }
        public virtual DbSet<CompetitionTrackAndFieldDiscipline> CompetitionTrackAndFieldDiscipline { get; set; }
        public virtual DbSet<Handicap> Handicap { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentCourse> StudentCourseRel { get; set; }

        internal HonglornDb(DbConnection connection) : base(connection, true)
        {
            Database.SetInitializer(new HonglornDbInitializer<HonglornDb>());
        }

        protected sealed override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}