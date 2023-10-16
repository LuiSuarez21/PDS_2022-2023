using BuildMe.Application.Services.Interfaces;
using BuildMe.Domain.Model;
using BuildMe.Infrastructure.Gateways.Interfaces;
using Microsoft.Extensions.Logging;

namespace BuildMe.Infrastructure.Services
{
    public class CityService : ICityService
    {
        private readonly ILogger<CityService> _logger;
        private readonly ICityGateway _cityGateway;

        public CityService(ILogger<CityService> logger, ICityGateway cityGateway)
        {
            _logger = logger;
            _cityGateway = cityGateway;
        }

        public async Task<bool> CreateCity(City city)
        {
            try
            {
                return await _cityGateway.CreateCity(city);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to insert city with id [{city.Id}]");
                throw;
            }
        }

        public async Task<bool> UpdateCity(City city)
        {
            try
            {
                return await _cityGateway.UpdateCity(city);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to update city with id [{city.Id}]");
                throw;
            }
        }

        public async Task<bool> DeleteCity(int id, DateTime lastUpdate)
        {
            try
            {
                return await _cityGateway.DeleteCity(id, lastUpdate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to delete city with id [{id}]");
                throw;
            }
        }

        public async Task<City> GetCity(int id)
        {
            try
            {
                return await _cityGateway.GetCity(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to get city with id [{id}]");
                throw;
            }
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            try
            {
                var cities = await _cityGateway.GetAllCities();
                return cities;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to get all cities list");
                throw;
            }
        }
    }
}