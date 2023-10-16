using BuildMe.Domain.Model;

namespace BuildMe.Application.Services.Interfaces
{
    public interface ICityService
    {
        public Task<bool> CreateCity(City city);
        public Task<bool> UpdateCity(City city);
        public Task<bool> DeleteCity(int id, DateTime lastUpdate);
        public Task<City> GetCity(int id);
        public Task<IEnumerable<City>> GetAllCities();
    }
}
