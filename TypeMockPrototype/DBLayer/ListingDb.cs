using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeMockPrototype.Models;

namespace TypeMockPrototype.DBLayer
{
    public class ListingDb
    {
        public static Listing GetListing(int id)
        {
            return new Listing() { Id = id, Title = "From LstingDb", User = new User() { Id = id, Name = "From LstingDb" } };
        }
        public static IEnumerable<Listing> GetListings()
        {
            var users = new List<Listing>();
            for (int i = 0; i < 5; i++)
            {
                users.Add(new Listing() { Id = i, Title = "From LstingDb", User = new User() { Id = i, Name = "From LstingDb" } });
            }
            return users;
        }
        public static void AddListing(Listing listing)
        {
            Console.WriteLine(string.Format("Listing Added : {0}", listing.Title));
        }

    }
}
