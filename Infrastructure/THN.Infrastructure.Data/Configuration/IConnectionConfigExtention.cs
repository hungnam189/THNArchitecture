
using System.Data;
using THN.Infrastructure.Data.Enums;

namespace THN.Infrastructure.Data.Configuration
{
    public interface IConnectionConfigExtention
    {
        /// <summary>
        /// Create DbConnection
        /// </summary>
        /// <param name="databaseServerType">Get name from Appsetting.json</param>
        /// <returns></returns>
        IDbConnection GetDbConnection(GetDatabaseServerType databaseServerType);

        /// <summary>
        /// Create DbConnection
        /// </summary>
        /// <param name="connectionStringName">Database nam is configuration from Appsetting.json</param>
        /// <param name="databaseServerType">Ex: MSSQL, PLSQL, PostgresSQL ...</param>
        /// <returns></returns>
        IDbConnection GetDbConnection(string connectionStringName, GetDatabaseType databaseServerType);

        /// <summary>
        /// Get ConnectionString from Appsetting.json
        /// </summary>
        /// <param name="databaseServerType"></param>
        /// <returns></returns>
        string GetConnectionString(GetDatabaseServerType databaseServerType);

        /// <summary>
        /// Get ConnectionString from Appsetting.json by connection name
        /// </summary>
        /// <param name="connectionStringName"></param>
        /// <param name="databaseServerType"></param>
        /// <returns></returns>
        string GetConnectionString(string connectionStringName, GetDatabaseType databaseType);
    }
}
