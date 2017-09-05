using System.Data;
using System.Threading.Tasks;

namespace TypeMockPrototype.Database
{
    public interface IConnectionFactory
    {
        IDbConnection GetOpenConnection();
        Task<IDbConnection> GetOpenConnectionAsync();
    }
}