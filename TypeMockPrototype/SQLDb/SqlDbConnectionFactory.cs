using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeMockPrototype.Database;

namespace TypeMockPrototype.SQLDb
{
    public class SqlDbConnectionFactory: DbConnectionFactoryBase
    {
        public override string ConnectionString { get
            {
                return "SQL Connection String";
            } }

        public override IDbConnection GetOpenConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        public override async Task<IDbConnection> GetOpenConnectionAsync()
        {
            var connection = new SqlConnection(ConnectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
