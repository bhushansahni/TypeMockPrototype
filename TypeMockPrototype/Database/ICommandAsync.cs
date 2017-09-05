using System.Data;
using System.Threading.Tasks;

namespace TypeMockPrototype.Database
{
    public interface ICommandAsync<T>
    {
        Task<T> ExecuteAsync(IDbConnection connection);
    }

    public interface ICommandAsync
    {
        Task ExecuteAsync(IDbConnection connection);
    }
}