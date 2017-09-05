using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeMockPrototype.Models;

namespace TypeMockPrototype.DBLayer
{
    public class UserDb
    {
        public static User GetUser(int id)
        {
            return new User() { Id = id, Name = "From UserDb" };
        }
        public static IEnumerable<User> GetUsers()
        {
            var users = new List<User>();
            for ( int i = 0; i < 5; i++ )
            {
                users.Add(new User() { Id = i, Name = string.Format("From UserDb - {0}", i) });
            }
            return users;
        }

        public static void AddUser(User user)
        {
            Console.WriteLine(string.Format("User Added : {0}", user.Name));
        }
    }
}
