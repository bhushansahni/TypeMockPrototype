using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeMockPrototype.Database
{
    public class InMemoryDatabase
    {
        private readonly IDbConnection _connection;

        public InMemoryDatabase()
        {
            _connection = new SQLiteConnection("Data Source=:memory:");

        }

        public IDbConnection OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();
            return _connection;
        }

        public void Insert<T>(string tableName, IEnumerable<T> items)
        {
            var con = OpenConnection();

            con.CreateTableIfNotExists<T>(tableName);
            con.InsertAll(tableName, items);
        }
    }
}
