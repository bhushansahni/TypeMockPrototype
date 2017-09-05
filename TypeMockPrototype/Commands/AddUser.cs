using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeMockPrototype.Models;
using Dapper;
using TypeMockPrototype.Database;

namespace TypeMockPrototype.Commands
{
    public class AddUser:ICommand<User>
    {
        private readonly User _user;
        public AddUser(User user)
        {
            _user = user;
        }

        public User Execute(IDbConnection connection)
        {
            var query = string.Format("INSERT INTO USER VALUES ({0}, '{1}')", _user.Id, _user.Name);
            connection.ExecuteScalar(query, CommandType.Text);
            return _user;
        }
    }
}
