using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeMockPrototype.Database;
using TypeMockPrototype.Models;
using Dapper;
namespace TypeMockPrototype.Queries
{
    public class GetUser : IQuery<User>
    {
        private readonly int _userId;
        public GetUser(int userId)
        {
            _userId = userId;
        }

        public User Execute(IDbConnection connection)
        {
            return connection.QueryFirstOrDefault<User>(string.Format("Select * from user where id = {0}", _userId));
        }
    }
}
