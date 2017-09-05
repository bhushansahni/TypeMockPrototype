using System.Data;
using System.Threading.Tasks;

namespace TypeMockPrototype.Database
{
    public interface IQueryAsync<T>
    {
        Task<T> ExecuteAsync(IDbConnection connection);
    }
}