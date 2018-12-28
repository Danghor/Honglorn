using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace HonglornBL.Models.Framework
{
    class HonglornDbFactory
    {
        static readonly IDictionary<string, Tuple<Func<string, DbConnection>, Func<DbConnection, HonglornDb>>> ProviderMap = new Dictionary<string, Tuple<Func<string, DbConnection>, Func<DbConnection, HonglornDb>>>
        {
            {
                "MySql.Data.MySqlClient",
                new Tuple<Func<string, DbConnection>, Func<DbConnection, HonglornDb>> (conString => new MySqlConnection(conString), con => new HonglornMySqlDb(con))
            }
        };

        DbConnection Connection { get; }

        internal Func<HonglornDb> CreateContext { get; }

        internal HonglornDbFactory(ConnectionStringSettings settings)
        {
            Tuple<Func<string, DbConnection>, Func<DbConnection, HonglornDb>> functions = ProviderMap[settings.ProviderName];
            Connection = functions.Item1(settings.ConnectionString);
            CreateContext = () => functions.Item2(Connection);
        }

        internal HonglornDbFactory(DbConnection connection)
        {
            Connection = connection;
            CreateContext = () => new HonglornDb(Connection);
        }
    }
}