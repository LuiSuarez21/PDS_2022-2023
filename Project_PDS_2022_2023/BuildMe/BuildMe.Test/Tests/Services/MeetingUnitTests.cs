using BuildMe.Infrastructure.Services;
using BuildMe.Test.FakeData;
using BuildMe.Test.Mock.Gateways;
using BuildMe.Test.Mock.Loggers;
using Moq;

namespace BuildMe.Test.Tests.Services
{
    [TestClass]
    public class MeetingUnitTests
    {
        [TestMethod]
        public async Task TestGetAllMeetings_ReturnsListOfMeetings()
        {
            // Arrange
            var _logger = new MockMeetingServiceLogger();
            var _companyGateway = new MockMeetingGateway();
            var _userGateway = new MockUserServiceLogger();

            // Setup
            _companyGateway.Setup(gateway => gateway.GetAllMeetings()).ReturnsAsync(FakeMeetingData.GetAllMeetings);
            var _companyService = new MeetingService(_userGateway.Object, _companyGateway.Object);

            var response = await _companyService.GetAllMeetings();
            var listUsers = response.ToList();

            // Assert
            Assert.AreEqual(FakeMeetingData.GetAllMeetings.Count, listUsers.Count);
            for (int i = 0; i < FakeMeetingData.GetAllMeetings.Count; i++)
            {
                Assert.AreEqual(FakeMeetingData.GetAllMeetings[i].Id, listUsers[i].Id);
                Assert.AreEqual(FakeMeetingData.GetAllMeetings[i].Description, listUsers[i].Description);
            }
        }
    }
}
