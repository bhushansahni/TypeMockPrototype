using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeMockPrototype.Database;
using TypeMockPrototype.SQLDb;

namespace TypeMockPrototype.SQLDb
{
    public class SqlDBFactory : DatabaseFactoryBase
    {
        public override IDatabase Create()
        {
            return new TypeMockPrototype.Database.Database(new SqlDbConnectionFactory());
        }

        public override IDatabase CreateWithExternalTransactionScope(System.Transactions.TransactionScope transactionScope)
        {
            return new TypeMockPrototype.Database.Database(new SqlDbConnectionFactory(), transactionScope);
        }
    }
}
