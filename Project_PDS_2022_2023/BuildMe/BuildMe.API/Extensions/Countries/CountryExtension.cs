using BuildMe.API.Data.Contracts.Country;
using BuildMe.Domain.Model;

namespace BuildMe.API.Extensions.Countries
{
    public static class CountryExtension
    {
        public static Country ConvertFromBody(this CreateCountryRequestContract newCountry)
        {
            return new Country()
            {
                Description = newCountry.Description,
            };
        }

        public static Country ConvertFromBody(this UpdateCountryRequestContract updateCountry)
        {
            return new Country()
            {
                Id = updateCountry.Id,
                Description = updateCountry.Description,
                Inactive = updateCountry.Inactive,
                LastUpdate = updateCountry.LastUpdate
            };
        }
    }
}
