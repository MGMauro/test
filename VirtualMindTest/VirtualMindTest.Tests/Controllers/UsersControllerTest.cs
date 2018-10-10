using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VirtualMindTest;
using VirtualMindTest.Controllers;
using VirtualMindTest.Repository.Interface;

namespace VirtualMindTest.Tests.Controllers
{
    [TestClass]
    public class UsersControllerTest
    {
        private Mock<IUserRepository> mockRepository;
        private UsersController controller;
        private List<User> users;


        [TestInitialize]
        public void Initialize()
        {
            mockRepository = new Mock<IUserRepository>();
            controller = new UsersController(mockRepository.Object);

            users = new List<User>();
            users.Add(new User { UserId = 1, UserName = "Juan", UserSurname = "Gonzales", UserEmail = "jgonzales@hotmail.com", UserPassword = "Pass01" });
            users.Add(new User { UserId = 2, UserName = "Fernado", UserSurname = "Rio", UserEmail = "frio@hotmail.com", UserPassword = "Pass01" });
        }
        [TestMethod]
        public void Get()
        {
            mockRepository.Setup(m => m.GetUsers()).Returns(users);

            List<User> result = controller.Get();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void GetById()
        {
            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(m => m.GetUserById(It.IsAny<int>())).Returns((int i) => users.Where(
                x => x.UserId == i).Single());

            var userId = 1;
            // Act
            IHttpActionResult result = controller.Get(userId);
            var contentResult = result as OkNegotiatedContentResult<User>;

            // Assert
            Assert.AreEqual("Juan", contentResult.Content.UserName);
        }

        [TestMethod]
        public void Post()
        {
            Models.User user = new Models.User
            {
                Name = "Juan",
                Surname = "Gonzales",
                Email = "jgonzales@hotmail.com",
                Password = "Password01"
            };
            
            mockRepository.Setup(m => m.InsertUser(user));

            // Act
            var result = controller.Post(user);

            // Assert
            Assert.AreEqual(typeof(System.Web.Http.Results.OkResult), result.GetType());
        }

        [TestMethod]
        public void Put()
        {
            Models.User user = new Models.User
            {
                Name = "Fernando"
            };

            var userId = users.Count();
            mockRepository.Setup(m => m.UpdateUser(userId, user));

           var result = controller.Put(userId, user);

            Assert.AreEqual(typeof(System.Web.Http.Results.OkResult), result.GetType());
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            var mockRepository = new Mock<IUserRepository>();

            var controller = new UsersController(mockRepository.Object);

            var id = 5;
            // Act
            controller.Delete(id);

            
        }
    }
}
