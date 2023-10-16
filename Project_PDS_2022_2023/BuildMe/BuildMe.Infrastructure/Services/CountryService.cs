using BuildMe.Application.Services.Interfaces;
using BuildMe.Domain.Model;
using BuildMe.Infrastructure.Gateways;
using BuildMe.Infrastructure.Gateways.Interfaces;
using Microsoft.Extensions.Logging;

namespace BuildMe.Infrastructure.Services
{
    public class CountryService : ICountryService
    {
        private readonly ILogger<CountryService> _logger;
        private readonly ICountryGateway _countryGateway;

        public CountryService(ILogger<CountryService> logger, ICountryGateway countryGateway)
        {
            _logger = logger;
            _countryGateway = countryGateway;
        }

        public async Task<bool> CreateCountry(Country country)
        {
            try
            {
                return await _countryGateway.CreateCountry(country);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> UpdateCountry(Country country)
        {
            try
            {
                return await _countryGateway.UpdateCountry(country);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to update country with id [{id}]", country.Id);
                throw;
            }
        }

        public async Task<bool> DeleteCountry(int id, DateTime lastUpdate)
        {
            try
            {
                return await _countryGateway.DeleteCountry(id, lastUpdate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to delete country with id [{id}]", id);
                throw;
            }
        }

        public async Task<Country> GetCountry(int id)
        {
            try
            {
                var country = await _countryGateway.GetCountry(id);
                return country;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to get country with id [{id}]", id);
                throw;
            }
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            try
            {
                var companies = await _countryGateway.GetAllCountries();
                return companies;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to get all companies list");
                throw;
            }
        }
    }
}
