using System.Data.Entity;
using System.IO;
using System.Xml.Serialization;
using HonglornBL.Models.Entities;
using HonglornBL.Properties;

namespace HonglornBL.Models.Framework {
  class HonglornDBInitializer : CreateDatabaseIfNotExists<HonglornDB> {
    protected override void Seed(HonglornDB context) {
      InitializeTraditionalDisciplinesData(context);

      base.Seed(context);
    }

    static void InitializeTraditionalDisciplinesData(HonglornDB context) {
      XmlSerializer serializer = new XmlSerializer(typeof(TraditionalDiscipline[]));

      using (StringReader reader = new StringReader(Resources.ArrayOfTraditionalDiscipline)) {
        TraditionalDiscipline[] disciplines = serializer.Deserialize(reader) as TraditionalDiscipline[];
        context.TraditionalDiscipline.AddRange(disciplines);
      }
    }
  }
}