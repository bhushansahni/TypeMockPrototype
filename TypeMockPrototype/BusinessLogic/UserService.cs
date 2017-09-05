using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeMockPrototype.Commands;
using TypeMockPrototype.Database;
using TypeMockPrototype.DBLayer;
using TypeMockPrototype.Models;
using TypeMockPrototype.Queries;

namespace TypeMockPrototype.BusinessLogic
{
    public class UserService : IServices<User>
    {
        private readonly IDatabase _database;
        public UserService()
        {
            _database = new SQLDb.SqlDBFactory().Create();
        }
        public UserService(IDatabase database)
        {
            _database = database;
        }
        public User Get(int id)
        {
            var query = new GetUser(1);
            return _database.Execute(query);
        }

        public User GetUsingDB(int id)
        {
            return UserDb.GetUser(id);
        }

        public void Save(User entity)
        {
            var command = new AddUser(entity);
            _database.Execute(command);
        }

        public void SaveUsingDB(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
