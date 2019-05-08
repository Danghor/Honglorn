using System.Data.Common;
using System.Data.Entity;
using MySql.Data.Entity;

namespace HonglornBL.Models.Framework
{
    class HonglornSqlDb : HonglornDb
    {
        internal HonglornSqlDb(DbConnection connection) : base(connection)
        {
            Database.SetInitializer(new HonglornDbInitializer<HonglornSqlDb>());
        }
    }
}