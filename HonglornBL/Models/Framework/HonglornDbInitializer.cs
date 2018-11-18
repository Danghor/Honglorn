using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using HonglornBL.Models.Entities;
using HonglornBL.Properties;

namespace HonglornBL.Models.Framework
{
    class HonglornDbInitializer<T> : CreateDatabaseIfNotExists<T> where T : HonglornDb
    {
        protected override void Seed(T context)
        {
            InitializeEntity<TraditionalDiscipline>(Resources.ArrayOfTraditionalDiscipline, context.TraditionalDiscipline);
            InitializeEntity<TraditionalReportMeta>(Resources.ArrayOfTraditionalReportMeta, context.TraditionalReportMeta);

            base.Seed(context);
        }

        static void InitializeEntity<TEntity>(string xmlContent, DbSet set)
        {
            var serializer = new XmlSerializer(typeof(TEntity[]));

            using (var reader = new StringReader(xmlContent))
            {
                try
                {
                    set.AddRange((IEnumerable<TEntity>) serializer.Deserialize(reader));
                }
                catch (InvalidCastException ex)
                {
                    throw new SerializationException($"Could not initialize database. The content of the XML file used could not be casted to '{typeof(TEntity).FullName}'. XML content: {xmlContent}", ex);
                }
            }
        }
    }
}