using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TypeMockPrototype.Database
{
    public interface IQuery<out T>
    {
        /// <summary>
        /// Executes the query over provided connection. Connection will be in open state and disposal is handled automatically.
        /// </summary>
        /// <param name="connection">Open connection.</param>
        T Execute(IDbConnection connection);
    }
}
