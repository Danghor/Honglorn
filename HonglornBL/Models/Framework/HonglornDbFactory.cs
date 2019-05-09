using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace HonglornBL.Models.Framework
{
    class HonglornDbFactory
    {
        static readonly IDictionary<string, Tuple<Func<string, Func<DbConnection>>, Func<DbConnection, HonglornDb>>> ProviderMap = new Dictionary<string, Tuple<Func<string, Func<DbConnection>>, Func<DbConnection, HonglornDb>>>
        {
            {
                "MySql.Data.MySqlClient",
                new Tuple<Func<string, Func<DbConnection>>, Func<DbConnection, HonglornDb>> (conString => () => new MySqlConnection(conString), con => new HonglornMySqlDb(con))
            },
            {
                "System.Data.SqlClient",
                new Tuple<Func<string, Func<DbConnection>>, Func<DbConnection, HonglornDb>> (conString => () => new SqlConnection(conString), con => new HonglornSqlDb(con))
            }
        };

        Func<DbConnection> GetConnection { get; }

        readonly string connectionString;

        internal Func<HonglornDb> CreateContext { get; }

        internal HonglornDbFactory(ConnectionStringSettings settings)
        {
            Tuple<Func<string, Func<DbConnection>>, Func<DbConnection, HonglornDb>> functions = ProviderMap[settings.ProviderName];
            connectionString = settings.ConnectionString;
            GetConnection = functions.Item1(connectionString);
            CreateContext = () => functions.Item2(GetConnection());
        }

        internal HonglornDbFactory(DbConnection connection)
        {
            GetConnection = () => connection;
            CreateContext = () => new HonglornDb(GetConnection());
        }
    }
}