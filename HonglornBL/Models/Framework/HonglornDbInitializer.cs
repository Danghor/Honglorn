using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Xml.Serialization;
using HonglornBL.Game.Traditional.TrackAndField;
using HonglornBL.Models.Entities;
using HonglornBL.Properties;

namespace HonglornBL.Models.Framework
{
    class HonglornDbInitializer<TContext> : CreateDatabaseIfNotExists<TContext> where TContext : HonglornDb
    {
        protected override void Seed(TContext context)
        {
            InitializeEntity<Handicap>(Resources.ArrayOfHandicap, context.Handicap);
            InitializeEntity<TraditionalTrackAndFieldSprintDiscipline>(Resources.ArrayOfTraditionalTrackAndFieldSprintDiscipline, context.TraditionalTrackAndFieldSprintDiscipline);
            InitializeEntity<TraditionalTrackAndFieldJumpDiscipline>(Resources.ArrayOfTraditionalTrackAndFieldJumpDiscipline, context.TraditionalTrackAndFieldJumpDiscipline);
            InitializeEntity<TraditionalTrackAndFieldThrowDiscipline>(Resources.ArrayOfTraditionalTrackAndFieldThrowDiscipline, context.TraditionalTrackAndFieldThrowDiscipline);
            InitializeEntity<TraditionalTrackAndFieldMiddleDistanceDiscipline>(Resources.ArrayOfTraditionalTrackAndFieldMiddleDistanceDiscipline, context.TraditionalTrackAndFieldMiddleDistanceDiscipline);
            InitializeEntity<TraditionalTrackAndFieldDisciplineHandicap>(Resources.ArrayOfTraditionalTrackAndFieldDisciplineHandicap, context.TraditionalTrackAndFieldDisciplineHandicap);
            InitializeEntity<TraditionalTrackAndFieldCertificateAssignment>(Resources.ArrayOfTraditionalTrackAndFieldCertificateAssignment, context.TraditionalTrackAndFieldCertificateAssignment);

            base.Seed(context);
        }

        static void InitializeEntity<TEntity>(string xmlContent, DbSet set)
        {
            var serializer = new XmlSerializer(typeof(TEntity[]));

            using (var reader = new StringReader(xmlContent))
            {
                set.AddRange((IEnumerable<TEntity>) serializer.Deserialize(reader));
            }
        }
    }
}