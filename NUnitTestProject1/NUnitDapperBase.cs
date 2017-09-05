using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeMockPrototype.Database;
using TypeMockPrototypeTests.Database;
using TypeMock;
using TypeMock.ArrangeActAssert;
using System.Data;
using Moq;
namespace TypeMockPrototypeTests
{
    public class NUnitDapperBase
    {
        internal InMemoryDatabase Database;
        public NUnitDapperBase()
        {
            Database = new InMemoryDatabase();
        }
    }
}
