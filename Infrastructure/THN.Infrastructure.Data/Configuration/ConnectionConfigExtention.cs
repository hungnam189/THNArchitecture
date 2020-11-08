using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using THN.Infrastructure.Data.Enums;

namespace THN.Infrastructure.Data.Configuration
{
    public class ConnectionConfigExtention : IConnectionConfigExtention
    {
        private readonly IConfiguration _configuration;

        public ConnectionConfigExtention(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Create DbConnection
        /// </summary>
        /// <param name="databaseServerType"></param>
        /// <returns></returns>
        public IDbConnection GetDbConnection(GetDatabaseServerType databaseServerType)
        {
            return databaseServerType switch
            {
                GetDatabaseServerType.MSSQLServerRead => new SqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("MSSQLRead").Value),
                GetDatabaseServerType.MSSQLServerWrite => new SqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("MSSQLWrite").Value),
                _ => new SqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("MSSQLRead").Value),
            };
        }

        /// <summary>
        /// Get DbConnection from Appsetting.json by connection name
        /// </summary>
        /// <param name="connectionStringName"></param>
        /// <param name="databaseType"></param>
        /// <returns></returns>
        public IDbConnection GetDbConnection(string connectionStringName, GetDatabaseType databaseType)
        {
            return databaseType switch
            {
                GetDatabaseType.MSSQL => new SqlConnection(_configuration.GetSection("ConnectionStrings").GetSection(connectionStringName).Value),
                //case GetDatabaseType.Oracle:
                //    return new OracleConnection(_configuration.GetSection("ConnectionStrings").GetSection("").Value);
                _ => new SqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("MSSQLRead").Value),
            };
        }

        /// <summary>
        /// Get ConnnectionString from Appsetting.json
        /// </summary>
        /// <param name="databaseServerType"></param>
        /// <returns></returns>
        public string GetConnectionString(GetDatabaseServerType databaseServerType)
        {
            return databaseServerType switch
            {
                GetDatabaseServerType.MSSQLServerRead => _configuration.GetSection("ConnectionStrings").GetSection("MSSQLRead").Value,
                GetDatabaseServerType.MSSQLServerWrite => _configuration.GetSection("ConnectionStrings").GetSection("MSSQLWrite").Value,
                _ => _configuration.GetSection("ConnectionStrings").GetSection("MSSQLRead").Value
            };
        }

        /// <summary>
        /// Get ConnectionString from Appsetting.json
        /// </summary>
        /// <param name="connectionStringName"></param>
        /// <param name="databaseType"></param>
        /// <returns></returns>
        public string GetConnectionString(string connectionStringName,GetDatabaseType databaseType)
        {
            return databaseType switch
            {
                GetDatabaseType.MSSQL => _configuration.GetSection("ConnectionStrings").GetSection(connectionStringName).Value,
                //GetDatabaseServerType.MSSQLServerWrite => _configuration.GetSection("ConnectionStrings").GetSection(connectionStringName).Value,
                _ => _configuration.GetSection("ConnectionStrings").GetSection("MSSQLRead").Value
            };
        }
    }
}
