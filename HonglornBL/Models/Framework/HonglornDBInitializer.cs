using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Xml.Serialization;
using HonglornBL.Models.Entities;
using HonglornBL.Properties;

namespace HonglornBL.Models.Framework {
  class HonglornDBInitializer : CreateDatabaseIfNotExists<HonglornDB> {
    protected override void Seed(HonglornDB context) {
      InitializeEntity<TraditionalDiscipline>(Resources.ArrayOfTraditionalDiscipline, context.TraditionalDiscipline);
      InitializeEntity<TraditionalReportMeta>(Resources.ArrayOfTraditionalReportMeta, context.TraditionalReportMeta);

      base.Seed(context);
    }

    static void InitializeEntity<Entity>(string xmlContent, DbSet set) {
      XmlSerializer serializer = new XmlSerializer(typeof(Entity[]));

      using (StringReader reader = new StringReader(xmlContent)) {
        set.AddRange(serializer.Deserialize(reader) as IEnumerable<Entity>);
      }
    }
  }
}