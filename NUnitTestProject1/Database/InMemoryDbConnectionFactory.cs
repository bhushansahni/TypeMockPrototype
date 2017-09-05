using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeMockPrototype.Database;

namespace TypeMockPrototypeTests.Database
{
    public class InMemoryDbConnectionFactory: DbConnectionFactoryBase
    {
        SQLiteConnection _connection;
        public override string ConnectionString { get {
                return "Data Source=:memory:";
            } }

        public InMemoryDbConnectionFactory(IDbConnection connection)
        {
            _connection = connection as SQLiteConnection;
        }
        public InMemoryDbConnectionFactory()
        { }
        public override IDbConnection GetOpenConnection()
        {
            if (_connection == null)
            {
                _connection = new SQLiteConnection(ConnectionString);
                _connection.Open();
            }
            return _connection;
        }

        public override async Task<IDbConnection> GetOpenConnectionAsync()
        {
            if (_connection == null)
            {
                _connection = new SQLiteConnection(ConnectionString);
                await _connection.OpenAsync();
            }
            return _connection;
        }
    }
}
