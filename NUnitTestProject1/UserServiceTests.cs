using System;
using NUnit;
using NUnit.Framework;
using TypeMock;
using TypeMock.ArrangeActAssert;
using TypeMockPrototype;
using TypeMockPrototype.DBLayer;
using TypeMockPrototype.Models;
using TypeMockPrototype.BusinessLogic;
using TypeMockPrototypeTests.Database;
using System.Collections.Generic;
using TypeMockPrototype.Database;
using Moq;
using System.Data;

namespace TypeMockPrototypeTests
{
    [TestFixture]
    public class UserServiceTests : NUnitDapperBase
    {
        Moq.Mock<IDatabase> _mock;
        [SetUp]
        public void Setup()
        {
            _mock = new Moq.Mock<IDatabase>();
        }
        [Test]
        public void GetUsingDB_ReturnsMockedData()
        {
            Isolate.WhenCalled(() => UserDb.GetUser(1)).DoInstead((test) => 
            {
                return new User() { Id = 1, Name = "User From Test" };
            });
            var userService = new UserService();
            var user = userService.GetUsingDB(1);
            Assert.AreEqual(1, user.Id);
            Assert.AreEqual("User From Test", user.Name);
        }
        [Test]
        public void Get_ReturnsInMemoryData()
        {
            Database.Insert<User>("USER", new List<User>() { new User() { Id = 1, Name = "Bhushan" } });
            var userService = new UserService(new InMemoryDbFactory(Database.OpenConnection()).Create());
            var user = userService.Get(1);
            Assert.AreEqual(1, user.Id);
            Assert.AreEqual("Bhushan", user.Name);
        }
        [Test]
        public void Get_ReturnsMockedData()
        {
            _mock.Setup(m => m.Execute(It.IsAny<IQuery<User>>())).Returns(new User() { Id = 1, Name = "Bhushan" });
            var userService = new UserService(_mock.Object);
            var user = userService.Get(1);
            Assert.AreEqual(1, user.Id);
            Assert.AreEqual("Bhushan", user.Name);
        }
    }
}