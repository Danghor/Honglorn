using HonglornBL.Game.Competition.TrackAndField;
using HonglornBL.Game.Traditional.TrackAndField;
using HonglornBL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;

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

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            var result = new DbEntityValidationResult(entityEntry, new List<DbValidationError>());

            if (entityEntry.Entity is StudentHandicap studentHandicap)
            {
                // Two people could have met if both were born before the other died
                var studentHandicapsInSamePeriod = from h in StudentHandicap
                                                   where h.StudentPKey == studentHandicap.StudentPKey
                                                   && h.DateStart < (studentHandicap.DateEnd ?? DateTime.MaxValue)
                                                   && studentHandicap.DateStart < (h.DateEnd ?? DateTime.MaxValue)
                                                   select h;

                if (studentHandicapsInSamePeriod.Any())
                {
                    result.ValidationErrors.Add(new DbValidationError(nameof(studentHandicap.DateStart), "The time period of this object overlaps with an already existing object for the same student."));
                }
            }

            if (result.ValidationErrors.Count > 0)
            {
                return result;
            }
            else
            {
                return base.ValidateEntity(entityEntry, items);
            }
        }
    }
}