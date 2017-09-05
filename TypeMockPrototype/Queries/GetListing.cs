using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeMockPrototype.Database;
using TypeMockPrototype.Models;

namespace TypeMockPrototype.Queries
{
    public class GetListing : IQuery<Listing>
    {
        private readonly int _listingId;
        public GetListing(int listingId)
        {
            _listingId = listingId;
        }

        public Listing Execute(IDbConnection connection)
        {
            return connection.QueryFirstOrDefault<Listing>(string.Format("Select * from Listing where userid = {0}", _listingId));
        }
    }
}
