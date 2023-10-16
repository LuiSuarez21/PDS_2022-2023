using BuildMe.Domain.Model;
using BuildMe.Infrastructure.Services;
using BuildMe.Test.FakeData;
using BuildMe.Test.Mock.Gateways;
using BuildMe.Test.Mock.Loggers;
using BuildMe.Test.Mock.Services;
using Moq;
using System.Security.Authentication;

namespace BuildMe.Test.Tests.Services
{
    [TestClass]
    public class UserUnitTest
    {
        [TestMethod]
        public async Task GetAllUsers_ReturnsListOfUsers()
        {
            // Arrange
            var _logger = new MockUserServiceLogger();
            var _passwordService = new MockPasswordService();
            var userGateway = new MockUserGateway();

            // Setup
            userGateway.Setup(gateway => gateway.GetAllUsers()).ReturnsAsync(FakeUserData.GetAllUsers);
            var userService = new UserService(_logger.Object, userGateway.Object, _passwordService.Object);

            var response = await userService.GetAllUsers();
            var listUsers = response.ToList();

            // Assert
            Assert.AreEqual(FakeUserData.GetAllUsers.Count, listUsers.Count);
            for (int i = 0; i < FakeUserData.GetAllUsers.Count; i++)
            {
                Assert.AreEqual(FakeUserData.GetAllUsers[i].Id, listUsers[i].Id);
                Assert.AreEqual(FakeUserData.GetAllUsers[i].UserName, listUsers[i].UserName);
            }
        }

        [DataTestMethod]
        [DataRow(1, true)]
        [DataRow(2, true)]
        [DataRow(5, false)]
        public async Task GetUser_ReturnsUserWhenExist(int userId, bool exist)
        {
            // Arrange
            var _logger = new MockUserServiceLogger();
            var _passwordService = new MockPasswordService();
            var userGateway = new MockUserGateway();

            // Setup
            userGateway.Setup(gateway => gateway.GetUser(userId)).ReturnsAsync(FakeUserData.GetAllUsers.FirstOrDefault(user => user.Id == userId));
            var userService = new UserService(_logger.Object, userGateway.Object, _passwordService.Object);

            var response = await userService.GetUser(userId);

            // Assert
            if (exist)
                Assert.IsNotNull(response);
            else
                Assert.IsNull(response);
        }

        [DataTestMethod]
        [DataRow("Name1", "123")]
        [DataRow("Name2", "123")]
        public async Task GetUserLogin_ReturnsUserWhenIsValid(string username, string password)
        {
            // Arrange
            var _logger = new MockUserServiceLogger();
            var _passwordService = new MockPasswordService();
            var userGateway = new MockUserGateway();

            // Setup
            userGateway.Setup(gateway => gateway.GetUserLogin(username)).ReturnsAsync(FakeUserData.GetAllUsers.FirstOrDefault(user => user.UserName == username));
            var userService = new UserService(_logger.Object, userGateway.Object, _passwordService.Object);

            var response = await userService.GetUserLogin(username, password);

            // Assert
            Assert.IsNotNull(response);
        }

        [DataTestMethod]
        [DataRow("NameDummy", "123")]
        public async Task GetUserLogin_ReturnsErrorWhenIsNotValid(string username, string password)
        {
            // Arrange
            var _logger = new MockUserServiceLogger();
            var _passwordService = new MockPasswordService();
            var userGateway = new MockUserGateway();

            // Setup
            userGateway.Setup(gateway => gateway.GetUserLogin(username)).ReturnsAsync(FakeUserData.GetAllUsers.FirstOrDefault(user => user.UserName == username));
            var userService = new UserService(_logger.Object, userGateway.Object, _passwordService.Object);

            await Assert.ThrowsExceptionAsync<Exception>(async () => await userService.GetUserLogin(username, password), "Error when trying to login");
        }

        //[DataTestMethod]
        //[DataRow("NameDummy", "123")]
        //public async Task CreateUser_ReturnsTrue()
        //{
        //    // Arrange
        //    var _logger = new MockUserServiceLogger();
        //    var _passwordService = new MockPasswordService();
        //    var userGateway = new MockUserGateway();

        //    var user = new User { Id = 4, UserName = "Name4", Password = "123" };

        //    // Setup
        //    userGateway.Setup(gateway => gateway.CreateUser(user)).ReturnsAsync(true);
        //    var userService = new UserService(_logger.Object, userGateway.Object, _passwordService.Object);

        //    var response = await userService.CreateUser(user);

        //    // Assert
        //    Assert.IsTrue(response);
        //}
    }
}