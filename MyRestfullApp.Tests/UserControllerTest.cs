using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRestfullApp.Controllers;
using MyRestfullApp.Service;
using MyRestfullApp.Data;
using System.Collections.Generic;
using Moq;
using System.Web.Http.Results;
using MyRestfullApp.DTO;

namespace MyRestfullApp.Tests
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void CreateUser()
        {
            var mockSet = new MockDbSet<User>(new List<User>());
            var mockContext = new Mock<MyRestfullAppEntities>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            UserController controller = new UserController(new UserService(mockContext.Object));

            var result = controller.Post(new UserDTO() { Email = "johndoe@doe.com", FirstName = "John", LastName = "Doe", Password = "pass" }) as OkNegotiatedContentResult<UserDTO>;
            var user = result.Content;
            Assert.IsTrue(user.FirstName == "John" && user.LastName == "Doe" && user.Email == "johndoe@doe.com" && user.Password == "pass" && user.Id == 1);

        }

        [TestMethod]
        public void GetUsersWithNoResult()
        {
            var mockSet = new MockDbSet<User>(new List<User>());
            var mockContext = new Mock<MyRestfullAppEntities>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            UserController controller = new UserController(new UserService(mockContext.Object));

            var result=controller.Get() as OkNegotiatedContentResult<IEnumerable<UserDTO>>;
            Assert.AreEqual(new List<UserDTO>(result.Content).Count, 0);
        }

        [TestMethod]
        public void GetUsersWith3Results()
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

            UserController controller = new UserController(new UserService(mockContext.Object));

            var result = controller.Get() as OkNegotiatedContentResult<IEnumerable<UserDTO>>;
            var users = new List<UserDTO>(result.Content);
            Assert.AreEqual(users.Count, 3);

            Assert.IsTrue(users.Exists(x => x.FirstName == "John" && x.LastName == "Doe" && x.Email == "john@doe.com" && x.Password == "pass"));
            Assert.IsTrue(users.Exists(x => x.FirstName == "Foo" && x.LastName == "Bar" && x.Email == "foo@doe.com" && x.Password == "pass"));
        }

        [TestMethod]
        public void GetExistingUser()
        {
            var data = new List<User>
            {
               new User() {Id= 1, Email = "john@doe.com", FirstName = "John", LastName = "Doe", Password = "pass" },

            };
            var mockSet = new MockDbSet<User>(data);
            var mockContext = new Mock<MyRestfullAppEntities>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            UserController controller = new UserController(new UserService(mockContext.Object));

            var result = controller.Get(1) as OkNegotiatedContentResult<UserDTO>;
            var user = result.Content;
            Assert.IsNotNull(user);
            Assert.IsTrue(user.FirstName == "John" && user.LastName == "Doe" && user.Email == "john@doe.com" && user.Password == "pass" && user.Id == 1);

        }

        [TestMethod]
        public void GetNonExistingUser()
        {
            var data = new List<User>
            {
               new User() {Id= 1, Email = "john@doe.com", FirstName = "John", LastName = "Doe", Password = "pass" },

            };
            var mockSet = new MockDbSet<User>(data);
            var mockContext = new Mock<MyRestfullAppEntities>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            UserController controller = new UserController(new UserService(mockContext.Object));

            var result = controller.Get(2) as NotFoundResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void DeleteExistingUser()
        {
            var data = new List<User>
            {
               new User() {Id= 1, Email = "john@doe.com", FirstName = "John", LastName = "Doe", Password = "pass" },

            };
            var mockSet = new MockDbSet<User>(data);
            var mockContext = new Mock<MyRestfullAppEntities>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            UserController controller = new UserController(new UserService(mockContext.Object));

            var result = controller.Delete(1) as OkResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(data.Count,0);

        }

        [TestMethod]
        public void DeleteNonExistingUser()
        {
            var data = new List<User>
            {
               new User() {Id= 1, Email = "john@doe.com", FirstName = "John", LastName = "Doe", Password = "pass" },

            };
            var mockSet = new MockDbSet<User>(data);
            var mockContext = new Mock<MyRestfullAppEntities>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            UserController controller = new UserController(new UserService(mockContext.Object));

            var result = controller.Delete(2) as NotFoundResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(data.Count, 1);

        }

        [TestMethod]
        public void UpdateExistingUser()
        {
            var data = new List<User>
            {
               new User() {Id= 1, Email = "john@doe.com", FirstName = "John", LastName = "Doe", Password = "pass" },

            };
            var mockSet = new MockDbSet<User>(data);
            var mockContext = new Mock<MyRestfullAppEntities>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            UserController controller = new UserController(new UserService(mockContext.Object));

            var result = controller.Put(1, new UserDTO() { Email = "johndoe@doe.com", FirstName = "John", LastName = "Doe", Password = "pass" }) as OkNegotiatedContentResult<UserDTO>;
            Assert.IsNotNull(result);
            var user = result.Content;
            Assert.IsTrue(user.FirstName == "John" && user.LastName == "Doe" && user.Email == "johndoe@doe.com" && user.Password == "pass" && user.Id == 1);


        }

        [TestMethod]
        public void UpdatedNonExistingUser()
        {
            var data = new List<User>
            {
               new User() {Id= 1, Email = "john@doe.com", FirstName = "John", LastName = "Doe", Password = "pass" },

            };
            var mockSet = new MockDbSet<User>(data);
            var mockContext = new Mock<MyRestfullAppEntities>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            UserController controller = new UserController(new UserService(mockContext.Object));

            var result = controller.Put(2, new UserDTO() { Email = "john@doe.com", FirstName = "John", LastName = "Doe", Password = "pass" }) as NotFoundResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(data.Count, 1);

        }
    }
}
