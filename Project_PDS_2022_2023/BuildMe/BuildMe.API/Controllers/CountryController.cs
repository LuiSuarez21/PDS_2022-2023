using BuildMe.API.Data.Contracts.Country;
using BuildMe.API.Extensions.Cities;
using BuildMe.API.Extensions.Countries;
using BuildMe.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildMe.API.Controllers
{
    [ApiVersion("1.0")]
    public class CountryController : ApiBaseController
    {
        private readonly ILogger<CountryController> _logger;
        private readonly ICountryService _countryService;

        public CountryController(ILogger<CountryController> logger, ICountryService countryService)
        {
            _logger = logger;
            _countryService = countryService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryRequestContract body)
        {
            try
            {
                var country = body.ConvertFromBody();
                var response = await _countryService.CreateCountry(country);

                if (!response)
                    throw new Exception("Error when trying to create a company");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateCountry([FromBody] UpdateCountryRequestContract body)
        {
            try
            {
                var country = body.ConvertFromBody();
                var response = await _countryService.UpdateCountry(country);

                if (!response)
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("delete/{id}/{lastUpdate}")]
        public async Task<IActionResult> DeleteCountry([FromRoute(Name = "id")] int id, [FromRoute(Name = "lastUpdate")] DateTime lastUpdate)
        {
            try
            {
                var response = await _countryService.DeleteCountry(id, lastUpdate);

                if (!response)
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "NormalUser")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCountry([FromRoute(Name = "id")] int id)
        {
            try
            {
                if (id == null)
                    throw new Exception("Id cannot be null");

                var company = await _countryService.GetCountry(id);

                if (company == null)
                    throw new Exception("Company cannot be null (company not found)");

                return Ok(company);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "NormalUser")]
        [HttpGet]
        [Route("country/all")]
        public async Task<IActionResult> GetAllCountries()
        {
            try
            {
                var countries = await _countryService.GetAllCountries();

                if (countries == null)
                    throw new Exception("Error when trying to get all countries");

                return Ok(countries);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
