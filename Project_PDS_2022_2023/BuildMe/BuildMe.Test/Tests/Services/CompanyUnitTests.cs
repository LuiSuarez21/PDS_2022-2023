using BuildMe.Infrastructure.Services;
using BuildMe.Test.FakeData;
using BuildMe.Test.Mock.Gateways;
using BuildMe.Test.Mock.Loggers;
using Moq;

namespace BuildMe.Test.Tests.Services
{
    [TestClass]
    public class CompanyUnitTests
    {
        [TestMethod]
        public async Task TestGetAllCompanies_ReturnsListOfCompanies()
        {
            // Arrange
            var _logger = new MockCompanyServiceLogger();
            var _companyGateway = new MockCompanyGateway();

            // Setup
            _companyGateway.Setup(gateway => gateway.GetAllCompanies()).ReturnsAsync(FakeCompanyData.GetAllCompanies);
            var _companyService = new CompanyService(_logger.Object, _companyGateway.Object);

            var response = await _companyService.GetAllCompanies();
            var listUsers = response.ToList();

            // Assert
            Assert.AreEqual(FakeCompanyData.GetAllCompanies.Count, listUsers.Count);
            for (int i = 0; i < FakeCompanyData.GetAllCompanies.Count; i++)
            {
                Assert.AreEqual(FakeCompanyData.GetAllCompanies[i].Id, listUsers[i].Id);
                Assert.AreEqual(FakeCompanyData.GetAllCompanies[i].Name, listUsers[i].Name);
            }
        }
    }
}
