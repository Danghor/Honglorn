using System;
using System.Collections.Generic;
using System.Data.Common;
using HonglornBL.Enums;

namespace HonglornBL.Models.Framework
{
    internal class HonglornDbFactory
    {
        static readonly IDictionary<DatabaseManagementSystem, Func<DbConnection, HonglornDb>> providerMap = new Dictionary<DatabaseManagementSystem, Func<DbConnection, HonglornDb>>
        {
            { DatabaseManagementSystem.Invariant, (con) => new HonglornDb(con) },
            { DatabaseManagementSystem.MySql, (con) => new HonglornMySqlDb(con) }
        };

        DatabaseManagementSystem ManagementSystem { get; }

        internal HonglornDbFactory(DatabaseManagementSystem managementSystem)
        {
            ManagementSystem = managementSystem;
        }

        internal HonglornDb GetDbContext(DbConnection connection)
        {
            return providerMap[ManagementSystem](connection);
        }
    }
}
