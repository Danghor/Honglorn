using System.Data.Entity.ModelConfiguration.Conventions;

namespace HonglornBL.Models.Framework
{
    class CustomSchemaConvention : Convention
    {
        public CustomSchemaConvention()
        {
            Types().Configure(c => c.ToTable("", c.ClrType.Namespace.Substring(c.ClrType.Namespace.LastIndexOf('.') + 1)));
        }
    }
}