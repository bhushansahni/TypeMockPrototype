using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeMockPrototype.Database;
using TypeMockPrototype.DBLayer;
using TypeMockPrototype.Models;
using TypeMockPrototype.Queries;

namespace TypeMockPrototype.BusinessLogic
{
    public class ListingService : IServices<Listing>
    {
        private readonly IDatabase _database;
        public ListingService()
        {
            _database = new SQLDb.SqlDBFactory().Create();
        }
        public ListingService(IDatabase database)
        {
            _database = database;
        }
        public Listing Get(int id)
        {
            var query = new GetListing(1);
            return _database.Execute(query);
        }

        public Listing GetUsingDB(int id)
        {
            return ListingDb.GetListing(id);
        }

        public void Save(Listing entity)
        {
            throw new NotImplementedException();
        }

        public void SaveUsingDB(Listing entity)
        {
            throw new NotImplementedException();
        }
    }
}
