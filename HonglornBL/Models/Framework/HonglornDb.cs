﻿using HonglornBL.Models.Entities;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using HonglornBL.Game.Competition.TrackAndField;
using HonglornBL.Game.Traditional.TrackAndField;

namespace HonglornBL.Models.Framework
{
    public class HonglornDb : DbContext
    {
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Course> Course { get; set; }

        public virtual DbSet<TraditionalTrackAndFieldGame> TraditionalTrackAndFieldGame { get; set; }
        public virtual DbSet<TraditionalTrackAndFieldPerformance> TraditionalTrackAndFieldPerformance { get; set; }
        public virtual DbSet<TraditionalTrackAndFieldSprintDiscipline> TraditionalTrackAndFieldSprintDiscipline { get; set; }
        public virtual DbSet<TraditionalTrackAndFieldJumpDiscipline> TraditionalTrackAndFieldJumpDiscipline { get; set; }
        public virtual DbSet<TraditionalTrackAndFieldThrowDiscipline> TraditionalTrackAndFieldThrowDiscipline { get; set; }
        public virtual DbSet<TraditionalTrackAndFieldMiddleDistanceDiscipline> TraditionalTrackAndFieldMiddleDistanceDiscipline { get; set; }
        public virtual DbSet<TraditionalTrackAndFieldMeasuringPoint> TraditionalTrackAndFieldMeasuringPoint { get; set; }
        public virtual DbSet<TraditionalTrackAndFieldDisciplineHandicap> TraditionalTrackAndFieldDisciplineHandicap { get; set; }
        public virtual DbSet<TraditionalTrackAndFieldCertificateAssignment> TraditionalTrackAndFieldCertificateAssignment { get; set; }

        public virtual DbSet<CompetitionTrackAndFieldGame> CompetitionTrackAndFieldGame { get; set; }
        public virtual DbSet<CompetitionTrackAndFieldPerformance> CompetitionTrackAndFieldPerformance { get; set; }
        public virtual DbSet<CompetitionTrackAndFieldDiscipline> CompetitionTrackAndFieldDiscipline { get; set; }
        public virtual DbSet<CompetitionTrackAndFieldMeasuringPoint> CompetitionTrackAndFieldMeasuringPoint { get; set; }
        public virtual DbSet<CompetitionTrackAndFieldEvaluationGroup> CompetitionTrackAndFieldEvaluationGroup { get; set; }
        public virtual DbSet<CompetitionTrackAndFieldEvaluationGroupStudent> CompetitionTrackAndFieldEvaluationGroupStudent { get; set; }

        public virtual DbSet<Handicap> Handicap { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentHandicap> StudentHandicap { get; set; }
        public virtual DbSet<StudentCourse> StudentCourse { get; set; }

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