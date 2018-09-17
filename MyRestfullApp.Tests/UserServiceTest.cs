using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using MyRestfullApp.Data;
using MyRestfullApp.Service;
using MyRestfullApp.DTO;
using System.Collections.Generic;
using System.Linq;
using MyRestfullApp.Tests;

namespace MyRestfullApp.Tests
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void CreateUser()
        {
            var mockSet = new MockDbSet<User>(new List<User>());
            var mockContext = new Mock<MyRestfullAppEntities>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var service = new UserService(mockContext.Object);
            var userDTO=service.AddUser(new UserDTO() { Email = "john@doe.com", FirstName = "John", LastName = "Doe", Password = "pass" });
            mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            List<UserDTO> users = new List<UserDTO>(service.GetUsers());
            Assert.AreEqual(1, users.Count);

            Assert.IsTrue(users.Exists(x => x.FirstName == "John" && x.LastName == "Doe" && x.Email == "john@doe.com" && x.Password == "pass"));


        }

        [TestMethod]
        public void GetUsers()
        {
            var data = new List<User>
            {
               new User() { Email = "john@doe.com", FirstName = "John", LastName = "Doe", Password = "pass" },
               new User() { Email = "foo@doe.com", FirstName = "Foo", LastName = "Bar", Password = "pass" },
               new User() { Email = "baz@doe.com", FirstName = "Baz", LastName = "Baz", Password = "pass" },

            };

            var mockSet = new MockDbSet<User>(data);
            var mockContext = new Mock<MyRestfullAppEntities>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);


            var service = new UserService(mockContext.Object);
            List<UserDTO> users = new List<UserDTO>(service.GetUsers());
            Assert.AreEqual(3, users.Count);

            Assert.IsTrue(users.Exists(x => x.FirstName == "John" && x.LastName == "Doe" && x.Email == "john@doe.com" && x.Password == "pass"));
            Assert.IsTrue(users.Exists(x => x.FirstName == "Foo" && x.LastName == "Bar" && x.Email == "foo@doe.com" && x.Password == "pass"));
        }

        [TestMethod]

        public void GetExistingUser()
        {
            var data = new List<User>
            {
               new User() { Id = 1, Email = "john@doe.com", FirstName = "John", LastName = "Doe", Password = "pass" },
            };

            var mockSet = new MockDbSet<User>(data);
            var mockContext = new Mock<MyRestfullAppEntities>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var service = new UserService(mockContext.Object);
            var user = service.GetUser(1);
            Assert.IsNotNull(user);

            Assert.IsTrue(user.FirstName == "John" && user.LastName == "Doe" && user.Email == "john@doe.com" && user.Password == "pass" && user.Id == 1);
        }

        [TestMethod]

        public void GetNonExistingUser()
        {
            var data = new List<User>
            {
               new User() { Id = 1, Email = "john@doe.com", FirstName = "John", LastName = "Doe", Password = "pass" },
            };

            var mockSet = new MockDbSet<User>(data);
            var mockContext = new Mock<MyRestfullAppEntities>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);


            var service = new UserService(mockContext.Object);
            var user = service.GetUser(2);
            Assert.IsNull(user);

        }

        [TestMethod]
        public void UpdateExistingUser()
        {
            var data = new List<User>
            {
               new User() { Id = 1, Email = "john@doe.com", FirstName = "John", LastName = "Doe", Password = "pass" },
            };

            var mockSet = new MockDbSet<User>(data);
            var mockContext = new Mock<MyRestfullAppEntities>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var service = new UserService(mockContext.Object);
            var user = service.UpdateUser(1,new UserDTO() { Id = 1, Email = "johndoe@doe.com" , FirstName = "John", LastName = "Doe", Password = "pass" });
            Assert.IsNotNull(user);

            Assert.IsTrue(user.FirstName == "John" && user.LastName == "Doe" && user.Email == "johndoe@doe.com" && user.Password == "pass" && user.Id == 1);
        }

        [TestMethod]

        public void UpdateNonExistingUser()
        {
            var data = new List<User>
            {
               new User() { Id = 1, Email = "john@doe.com", FirstName = "John", LastName = "Doe", Password = "pass" },
            };

            var mockSet = new MockDbSet<User>(data);
            var mockContext = new Mock<MyRestfullAppEntities>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);


            var service = new UserService(mockContext.Object);
            var user = service.UpdateUser(2,new UserDTO() { Id = 2, Email = "johndoe@doe.com" });
            Assert.IsNull(user);

        }

        [TestMethod]
        public void DeleteExistingUser()
        {
            var data = new List<User>
            {
               new User() { Id = 1, Email = "john@doe.com", FirstName = "John", LastName = "Doe", Password = "pass" },
            };

            var mockSet = new MockDbSet<User>(data);
            var mockContext = new Mock<MyRestfullAppEntities>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var service = new UserService(mockContext.Object);
            service.DeleteUser(1);
            Assert.AreEqual(data.Count,0);
        }

        [TestMethod]

        public void DeleteNonExistingUser()
        {
            var data = new List<User>
            {
               new User() { Id = 1, Email = "john@doe.com", FirstName = "John", LastName = "Doe", Password = "pass" },
            };

            var mockSet = new MockDbSet<User>(data);
            var mockContext = new Mock<MyRestfullAppEntities>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);


            var service = new UserService(mockContext.Object);
            service.DeleteUser(2);
            Assert.AreEqual(data.Count, 1);

        }
    }
}
