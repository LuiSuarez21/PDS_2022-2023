using BuildMe.Infrastructure.Services;
using BuildMe.Test.FakeData;
using BuildMe.Test.Mock.Gateways;
using BuildMe.Test.Mock.Loggers;
using Moq;

namespace BuildMe.Test.Tests.Services
{
    [TestClass]
    public class CountryUnitTests
    {
        [TestMethod]
        public async Task TestGetAllCountries_ReturnsListOfCountries()
        {
            // Arrange
            var _logger = new MockCountryServiceLogger();
            var _companyGateway = new MockCountryGateway();

            // Setup
            _companyGateway.Setup(gateway => gateway.GetAllCountries()).ReturnsAsync(FakeCountryData.GetAllCountries);
            var _companyService = new CountryService(_logger.Object, _companyGateway.Object);

            var response = await _companyService.GetAllCountries();
            var listUsers = response.ToList();

            // Assert
            Assert.AreEqual(FakeCountryData.GetAllCountries.Count, listUsers.Count);
            for (int i = 0; i < FakeCountryData.GetAllCountries.Count; i++)
            {
                Assert.AreEqual(FakeCountryData.GetAllCountries[i].Id, listUsers[i].Id);
                Assert.AreEqual(FakeCountryData.GetAllCountries[i].Description, listUsers[i].Description);
            }
        }
    }
}
