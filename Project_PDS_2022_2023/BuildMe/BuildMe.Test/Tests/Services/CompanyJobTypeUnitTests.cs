using BuildMe.Infrastructure.Services;
using BuildMe.Test.FakeData;
using BuildMe.Test.Mock.Gateways;
using BuildMe.Test.Mock.Loggers;
using BuildMe.Test.Mock.Services;
using Moq;
using System.Threading.Tasks;

namespace BuildMe.Test.Tests.Services
{
    [TestClass]
    public class CompanyJobTypeUnitTests
    {
        [DataTestMethod]
        [DataRow(0, true)]
        [DataRow(1, true)]
        public async Task TestGetAllCompanyJobsTypes(int jobTypeId, bool exist)
        {
            // Arrange
            var _logger = new MockCompanyJobTypeServiceLogger();
            var _companyJobTypeGateway = new MockCompanyJobTypeGateway();
            var _jobTypeService = new MockJobTypeService();

            // Setup
            _companyJobTypeGateway.Setup(gateway => gateway.GetAllCompanyJobTypes(jobTypeId)).ReturnsAsync(FakeCompanyJobTypeData.GetCompaniesJobTypes);
            var companyJobTypeService = new CompanyJobTypeService(_logger.Object, _companyJobTypeGateway.Object, _jobTypeService.Object);

            var response = await companyJobTypeService.GetAllCompanyJobTypes(jobTypeId);
            var listCompanyJobTypes = response.ToList();

            // Assert
            Assert.AreEqual(FakeCompanyJobTypeData.GetCompaniesJobTypes.Count, listCompanyJobTypes.Count);
            for (int i = 0; i < FakeCompanyJobTypeData.GetCompaniesJobTypes.Count; i++)
            {
                Assert.AreEqual(FakeCompanyJobTypeData.GetCompaniesJobTypes[i].JobTypeId, listCompanyJobTypes[i].JobTypeId);
                Assert.AreEqual(FakeCompanyJobTypeData.GetCompaniesJobTypes[i].AveragePrice, listCompanyJobTypes[i].AveragePrice);
            }
        }
    }
}
