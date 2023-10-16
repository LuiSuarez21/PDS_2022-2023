using BuildMe.API.Data.Contracts.City;
using BuildMe.API.Data.Contracts.Users;
using BuildMe.API.Extensions.Cities;
using BuildMe.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildMe.API.Controllers
{
    [ApiVersion("1.0")]
    public class CityController : ApiBaseController
    {
        private readonly ILogger<CityController> _logger;
        private readonly ICityService _cityService;

        public CityController(ILogger<CityController> logger, ICityService cityService)
        {
            _logger = logger;
            _cityService = cityService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityRequestContract body)
        {
            try
            {
                var city = body.ConvertFromBody();
                var response = await _cityService.CreateCity(city);

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
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateCity([FromBody] UpdateCityRequestContract body)
        {
            try
            {
                var city = body.ConvertFromBody();
                var response = await _cityService.UpdateCity(city);

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
        public async Task<IActionResult> DeleteUser([FromRoute(Name = "id")] int id, [FromRoute(Name = "lastUpdate")] DateTime lastUpdate)
        {
            try
            {
                var response = await _cityService.DeleteCity(id, lastUpdate);

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
        public async Task<IActionResult> GetCity([FromRoute(Name = "id")] int id)
        {
            try
            {
                if (id == null)
                    throw new Exception("Id cannot be null.");

                var userType = await _cityService.GetCity(id);

                if (userType == null)
                    throw new Exception("City cannot be null (City not found).");

                return Ok(userType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "NormalUser")]
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllCities()
        {
            try
            {
                var cities = await _cityService.GetAllCities();

                if (cities == null)
                    throw new Exception("Error when trying to get all cities.");

                var listOfCities = new List<GetAllCItiesResponseContract>();

                foreach (var city in cities)
                {
                    listOfCities.Add(new GetAllCItiesResponseContract()
                    {
                        Id = city.Id,
                        CountryId = city.CountryId,
                        Description = city.Description,
                        Inactive = city.Inactive,
                        LastUpdate = city.LastUpdate
                    });
                }

                return Ok(listOfCities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
