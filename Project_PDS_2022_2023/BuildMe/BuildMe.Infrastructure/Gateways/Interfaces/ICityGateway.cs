using BuildMe.Domain.Model;

namespace BuildMe.Infrastructure.Gateways.Interfaces
{
    public interface ICityGateway
    {
        public Task<bool> CreateCity(City city);
        public Task<bool> UpdateCity(City city);
        public Task<bool> DeleteCity(int id, DateTime lastUpdate);
        public Task<City> GetCity(int id);
        public Task<IEnumerable<City>> GetAllCities();
    }
}
