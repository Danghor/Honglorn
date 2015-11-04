using System.Data.Entity;
using System.IO;
using System.Xml.Serialization;
using HonglornBL.Models.Entities;
using HonglornBL.Properties;

namespace HonglornBL.Models.Framework {
  class HonglornDBInitializer : CreateDatabaseIfNotExists<HonglornDB> {
    protected override void Seed(HonglornDB context) {
      InitializeTraditionalDiscipline(context);
      InitializeTraditionalReportMeta(context);

      base.Seed(context);
    }

    static void InitializeTraditionalDiscipline(HonglornDB context) {
      XmlSerializer serializer = new XmlSerializer(typeof(TraditionalDiscipline[]));

      using (StringReader reader = new StringReader(Resources.ArrayOfTraditionalDiscipline)) {
        TraditionalDiscipline[] disciplines = serializer.Deserialize(reader) as TraditionalDiscipline[];
        context.TraditionalDiscipline.AddRange(disciplines);
      }
    }

    static void InitializeTraditionalReportMeta(HonglornDB context) {
      XmlSerializer serializer = new XmlSerializer(typeof(TraditionalReportMeta[]));

      using (StringReader reader = new StringReader(Resources.ArrayOfTraditionalReportMeta)) {
        TraditionalReportMeta[] reportMetaInformation = serializer.Deserialize(reader) as TraditionalReportMeta[];
        context.TraditionalReportMeta.AddRange(reportMetaInformation);
      }
    }
  }
}