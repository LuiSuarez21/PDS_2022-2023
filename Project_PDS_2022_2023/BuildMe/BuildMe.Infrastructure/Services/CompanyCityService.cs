using BuildMe.Application.Services.Interfaces;
using BuildMe.Domain.Model;
using BuildMe.Infrastructure.Gateways.Interfaces;
using Microsoft.Extensions.Logging;

namespace BuildMe.Infrastructure.Services
{
    public class CompanyCityService : ICompanyCityService
    {
        private readonly ILogger<CompanyCityService> _logger;
        private readonly ICompanyCityGateway _companyCityGateway;

        public CompanyCityService(ILogger<CompanyCityService> logger, ICompanyCityGateway companyCityGateway)
        {
            _logger = logger;
            _companyCityGateway = companyCityGateway;
        }

        public async Task<bool> CreateCompanyCity(CompanyCity companyCity)
        {
            try
            {
                return await _companyCityGateway.CreateCompanyCity(companyCity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to insert company with id {companyCity.CompanyId} and city with id {companyCity.CityId}");
                throw;
            }
        }

        public async Task<bool> UpdateCompanyCity(CompanyCity companyCity)
        {
            try
            {
                return await _companyCityGateway.UpdateCompanyCity(companyCity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to update company with id {companyCity.CompanyId} and city with id {companyCity.CityId}");
                throw;
            }
        }

        public async Task<bool> DeleteCompanyCity(int companyId, int cityId)
        {
            try
            {
                return await _companyCityGateway.DeleteCompanyCity(companyId, cityId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to delete city {cityId} from company {companyId}");
                throw;
            }
        }

        public async Task<CompanyCity> GetCompanyCity(int companyId, int cityId)
        {
            try
            {
                return await _companyCityGateway.GetCompanyCity(companyId, cityId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to get city {cityId} from company {companyId}");
                throw;
            }
        }

        public async Task<IEnumerable<CompanyCity>> GetAllCompanyCities(int companyId)
        {
            try
            {
                return await _companyCityGateway.GetAllCompanyCities(companyId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to get all cities from company {companyId}");
                throw;
            }
        }
    }
}