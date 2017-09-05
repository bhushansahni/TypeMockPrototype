using System.Data;

namespace TypeMockPrototype.Database
{
    public abstract class DatabaseFactoryBase
    {
        public abstract IDatabase Create();
        public abstract IDatabase CreateWithExternalTransactionScope(System.Transactions.TransactionScope transactionScope);
    }
}