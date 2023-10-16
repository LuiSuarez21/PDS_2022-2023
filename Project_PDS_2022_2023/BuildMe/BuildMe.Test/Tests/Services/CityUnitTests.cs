using BuildMe.Infrastructure.Services;
using BuildMe.Test.FakeData;
using BuildMe.Test.Mock.Gateways;
using BuildMe.Test.Mock.Loggers;
using Moq;

namespace BuildMe.Test.Tests.Services
{
    [TestClass]
    public class CityUnitTests
    {
        [TestMethod]
        public async Task TestGetAllCities_ReturnsListOfCities()
        {
            // Arrange
            var _logger = new MockCityServiceLogger();
            var _companyGateway = new MockCityGateway();

            // Setup
            _companyGateway.Setup(gateway => gateway.GetAllCities()).ReturnsAsync(FakeCityData.GetAllCities);
            var _companyService = new CityService(_logger.Object, _companyGateway.Object);

            var response = await _companyService.GetAllCities();
            var listUsers = response.ToList();

            // Assert
            Assert.AreEqual(FakeCityData.GetAllCities.Count, listUsers.Count);
            for (int i = 0; i < FakeCityData.GetAllCities.Count; i++)
            {
                Assert.AreEqual(FakeCityData.GetAllCities[i].Id, listUsers[i].Id);
                Assert.AreEqual(FakeCityData.GetAllCities[i].Description, listUsers[i].Description);
            }
        }
    }
}

