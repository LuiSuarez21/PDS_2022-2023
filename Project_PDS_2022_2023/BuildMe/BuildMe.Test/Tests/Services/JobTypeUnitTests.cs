using BuildMe.Infrastructure.Services;
using BuildMe.Test.FakeData;
using BuildMe.Test.Mock.Gateways;
using BuildMe.Test.Mock.Loggers;
using Moq;

namespace BuildMe.Test.Tests.Services
{
    [TestClass]
    public class JobTypeUnitTests
    {
        [TestMethod]
        public async Task TestGetAllJobTypes_ReturnsListOfJobTypes()
        {
            // Arrange
            var _logger = new MockJobTypeServiceLogger();
            var _companyGateway = new MockJobTypeGateway();

            // Setup
            _companyGateway.Setup(gateway => gateway.GetAllJobTypes()).ReturnsAsync(FakeJobTypeData.GetAllJobTypes);
            var _companyService = new JobTypeService(_logger.Object, _companyGateway.Object);

            var response = await _companyService.GetAllJobTypes();
            var listUsers = response.ToList();

            // Assert
            Assert.AreEqual(FakeJobTypeData.GetAllJobTypes.Count, listUsers.Count);
            for (int i = 0; i < FakeJobTypeData.GetAllJobTypes.Count; i++)
            {
                Assert.AreEqual(FakeJobTypeData.GetAllJobTypes[i].Id, listUsers[i].Id);
                Assert.AreEqual(FakeJobTypeData.GetAllJobTypes[i].Description, listUsers[i].Description);
            }
        }
    }
}
