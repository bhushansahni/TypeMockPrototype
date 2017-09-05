using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Threading.Tasks;
using TypeMockPrototype.Database;
using System.Data;

namespace TypeMockPrototypeTests.Database
{
    public class InMemoryDbFactory: DatabaseFactoryBase
    {
        IDbConnection _connection;
        public InMemoryDbFactory(IDbConnection connection)
        {
            _connection = connection;
        }
        public override IDatabase Create()
        {
            if (_connection == null)
                return new TypeMockPrototype.Database.Database(new InMemoryDbConnectionFactory());
            else
                return new TypeMockPrototype.Database.Database(new InMemoryDbConnectionFactory(_connection));
        }

        public override IDatabase CreateWithExternalTransactionScope(System.Transactions.TransactionScope transactionScope)
        {
            return new TypeMockPrototype.Database.Database(new InMemoryDbConnectionFactory(), transactionScope);
        }
    }
}
