using BuildMe.Infrastructure.Services;
using BuildMe.Test.FakeData;
using BuildMe.Test.Mock.Gateways;
using BuildMe.Test.Mock.Loggers;
using Moq;

namespace BuildMe.Test.Tests.Services
{
    [TestClass]
    public class UserTypeUnitTests
    {
        [TestMethod]
        public async Task TestGetAllUserTypes_ReturnsListOfUserTypes()
        {
            // Arrange
            var _logger = new MockUserServiceLogger();
            var _userTypeGateway = new MockUserTypeGateway();

            // Setup
            _userTypeGateway.Setup(gateway => gateway.GetAllUserTypes()).ReturnsAsync(FakeUserTypeData.GetAllUserTypes);
            var _companyService = new UserTypeService(_logger.Object, _userTypeGateway.Object);

            var response = await _companyService.GetAllUserTypes();
            var listUsers = response.ToList();

            // Assert
            Assert.AreEqual(FakeUserTypeData.GetAllUserTypes.Count, listUsers.Count);
            for (int i = 0; i < FakeUserTypeData.GetAllUserTypes.Count; i++)
            {
                Assert.AreEqual(FakeUserTypeData.GetAllUserTypes[i].Id, listUsers[i].Id);
                Assert.AreEqual(FakeUserTypeData.GetAllUserTypes[i].Description, listUsers[i].Description);
            }
        }
    }
}
