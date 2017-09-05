using System.Data;
using System.Threading.Tasks;

namespace TypeMockPrototype.Database
{
    public interface IDatabase
    {
        T Execute<T>(IQuery<T> query);
        void Execute(ICommand command);
        T Execute<T>(ICommand<T> command);
        Task<T> ExecuteAsync<T>(IQueryAsync<T> query);
        Task ExecuteAsync(ICommandAsync command);
        Task<T> ExecuteAsync<T>(ICommandAsync<T> command);
    }
}