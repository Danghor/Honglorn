using System.Data.Common;
using System.Data.Entity;
using MySql.Data.Entity;

namespace HonglornBL.Models.Framework
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class HonglornMySqlDb : HonglornDb
    {
        internal HonglornMySqlDb(DbConnection connection) : base(connection) { }
    }
}
