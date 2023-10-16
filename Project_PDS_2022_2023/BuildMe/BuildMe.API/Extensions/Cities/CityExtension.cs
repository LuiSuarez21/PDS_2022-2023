using BuildMe.API.Data.Contracts.City;
using BuildMe.Domain.Model;

namespace BuildMe.API.Extensions.Cities
{
    public static class CityExtension
    {
        public static City ConvertFromBody(this CreateCityRequestContract newCity)
        {
            return new City()
            {
                Description = newCity.Description,
                CountryId = newCity.CountryId
            };
        }

        public static City ConvertFromBody(this UpdateCityRequestContract updateCity)
        {
            return new City()
            {
                Id = updateCity.Id,
                Description = updateCity.Description,
                CountryId = updateCity.CountryId,
                Inactive = updateCity.Inactive,
                LastUpdate = updateCity.LastUpdate
            };
        }
    }
}
