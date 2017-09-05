using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeMockPrototype.Models
{
    public class Listing : IEntity
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Title { get; set; }

    }
}
