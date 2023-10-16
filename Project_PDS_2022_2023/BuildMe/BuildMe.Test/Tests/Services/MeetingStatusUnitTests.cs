using BuildMe.Infrastructure.Services;
using BuildMe.Test.FakeData;
using BuildMe.Test.Mock.Gateways;
using BuildMe.Test.Mock.Loggers;
using Moq;

namespace BuildMe.Test.Tests.Services
{
    [TestClass]
    public class MeetingStatusUnitTests
    {
        [TestMethod]
        public async Task TestGetAllMeetingStatuses_ReturnsListOfMeetingStatuses()
        {
            // Arrange
            var _logger = new MockMeetingStatusServiceLogger();
            var _companyGateway = new MockMeetingStatusGateway();


            // Setup
            _companyGateway.Setup(gateway => gateway.GetAllMeetingStatuses()).ReturnsAsync(FakeMeetingStatusData.GetAllMeetingStatuses);
            var _companyService = new MeetingStatusService(_logger.Object, _companyGateway.Object);

            var response = await _companyService.GetAllMeetingStatuses();
            var listUsers = response.ToList();

            // Assert
            Assert.AreEqual(FakeMeetingStatusData.GetAllMeetingStatuses.Count, listUsers.Count);
            for (int i = 0; i < FakeMeetingStatusData.GetAllMeetingStatuses.Count; i++)
            {
                Assert.AreEqual(FakeMeetingStatusData.GetAllMeetingStatuses[i].Id, listUsers[i].Id);
                Assert.AreEqual(FakeMeetingStatusData.GetAllMeetingStatuses[i].Description, listUsers[i].Description);
            }
        }
    }
}
