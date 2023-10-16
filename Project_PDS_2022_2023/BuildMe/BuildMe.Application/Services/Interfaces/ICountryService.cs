using BuildMe.Domain.Model;

namespace BuildMe.Application.Services.Interfaces
{
    public interface ICountryService
    {
        public Task<bool> CreateCountry(Country country);
        public Task<bool> UpdateCountry(Country country);
        public Task<bool> DeleteCountry(int id, DateTime lastUpdate);
        public Task<Country> GetCountry(int id);
        public Task<IEnumerable<Country>> GetAllCountries();
    }
}
