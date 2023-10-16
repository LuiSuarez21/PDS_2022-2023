using BuildMe.Infrastructure.Services;
using BuildMe.Test.FakeData;
using BuildMe.Test.Mock.Gateways;
using BuildMe.Test.Mock.Loggers;
using Moq;

namespace BuildMe.Test.Tests.Services
{
    [TestClass]
    public class TaskStatusUnitTests
    {
        [TestMethod]
        public async Task TestGetAllTaskStatuses_ReturnsListOfTaskStatuses()
        {
            // Arrange
            var _logger = new MockTaskStatusServiceLogger();
            var _companyGateway = new MockTaskStatusGateway();

            // Setup
            _companyGateway.Setup(gateway => gateway.GetAllTaskStatuses()).ReturnsAsync(FakeTaskStatusData.GetAllTaskStatuses);
            var _companyService = new TaskStatusService(_logger.Object, _companyGateway.Object);

            var response = await _companyService.GetAllTaskStatuses();
            var listUsers = response.ToList();

            // Assert
            Assert.AreEqual(FakeTaskStatusData.GetAllTaskStatuses.Count, listUsers.Count);
            for (int i = 0; i < FakeTaskStatusData.GetAllTaskStatuses.Count; i++)
            {
                Assert.AreEqual(FakeTaskStatusData.GetAllTaskStatuses[i].Id, listUsers[i].Id);
                Assert.AreEqual(FakeTaskStatusData.GetAllTaskStatuses[i].Description, listUsers[i].Description);
            }
        }
    }
}
