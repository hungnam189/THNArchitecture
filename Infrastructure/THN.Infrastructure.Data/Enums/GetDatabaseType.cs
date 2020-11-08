using System;
using System.Collections.Generic;
using System.Text;

namespace THN.Infrastructure.Data.Enums
{
    public enum GetDatabaseType
    {
        /// <summary>
        /// Microsoft SQL Server
        /// </summary>
        MSSQL,

        /// <summary>
        /// Oracle Database Server
        /// </summary>
        Oracle,

        /// <summary>
        /// MongoDb database
        /// </summary>
        MongoDb,
        /// <summary>
        /// Postgres database
        /// </summary>
        PostgresSQL,

        /// <summary>
        /// Cassandra database
        /// </summary>
        Cassandra
    }
}
