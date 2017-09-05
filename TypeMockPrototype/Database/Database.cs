using System.Data;
using System.Threading.Tasks;
using System.Transactions;

namespace TypeMockPrototype.Database
{
    /// <summary>
    /// Currently creates and opens new connection for every Query/Command. Command execution is wrapped in Transaction.
    /// </summary>
    public class Database : IDatabase
    {
        private readonly IConnectionFactory connectionFactory;
        private readonly TransactionScope externalTransactionScope;

        public Database(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        /// <summary>
        /// Use when you need externally controlled transaction e.g. in integration tests to rollback changes or to execute bunch of commands.
        /// </summary>
        public Database(IConnectionFactory connectionFactory, TransactionScope transactionScope)
            : this(connectionFactory)
        {
            this.externalTransactionScope = transactionScope;
        }
        public T Execute<T>(IQuery<T> query)
        {
            using (var connection = this.connectionFactory.GetOpenConnection())
            {
                return query.Execute(connection);
            }
        }

        public async Task<T> ExecuteAsync<T>(IQueryAsync<T> query)
        {
            using (var connection = await this.connectionFactory.GetOpenConnectionAsync())
            {
                return await query.ExecuteAsync(connection);
            }
        }

        public void Execute(ICommand command)
        {
            if (this.externalTransactionScope != null)
            {
                using (var connection = this.connectionFactory.GetOpenConnection())
                {
                    command.Execute(connection);
                }
            }
            else
            {
                using (var transactionScope = new TransactionScope())
                {
                    using (var connection = this.connectionFactory.GetOpenConnection())
                    {
                        command.Execute(connection);
                    }

                    transactionScope.Complete();
                }
            }
        }

        public T Execute<T>(ICommand<T> command)
        {
            if (this.externalTransactionScope != null)
            {
                using (var connection = this.connectionFactory.GetOpenConnection())
                {
                    T result = command.Execute(connection);
                    return result;
                }
            }

            using (var transactionScope = new TransactionScope())
            {
                using (var connection = this.connectionFactory.GetOpenConnection())
                {
                    T result = command.Execute(connection);
                    transactionScope.Complete();
                    return result;
                }
            }
        }

        public async Task ExecuteAsync(ICommandAsync command)
        {
            if (this.externalTransactionScope != null)
            {
                using (var connection = await this.connectionFactory.GetOpenConnectionAsync())
                {
                    await command.ExecuteAsync(connection);
                }
            }
            else
            {
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required))
                {
                    using (var connection = await this.connectionFactory.GetOpenConnectionAsync())
                    {
                        await command.ExecuteAsync(connection);
                    }

                    transactionScope.Complete();
                }
            }
        }

        public async Task<T> ExecuteAsync<T>(ICommandAsync<T> command)
        {
            if (this.externalTransactionScope != null)
            {
                using (var connection = await this.connectionFactory.GetOpenConnectionAsync())
                {
                    T result = await command.ExecuteAsync(connection);
                    return result;
                }
            }

            using (var transactionScope = new TransactionScope(TransactionScopeOption.Required))
            {
                using (var connection = await this.connectionFactory.GetOpenConnectionAsync())
                {
                    T result = await command.ExecuteAsync(connection);
                    transactionScope.Complete();
                    return result;
                }
            }
        }
    }
}