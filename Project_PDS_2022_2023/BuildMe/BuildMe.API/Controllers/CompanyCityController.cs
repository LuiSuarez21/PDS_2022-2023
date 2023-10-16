using BuildMe.API.Data.Contracts.CompanyCity;
using BuildMe.API.Extensions.CompanyCities;
using BuildMe.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildMe.API.Controllers
{
    [ApiVersion("1.0")]
    public class CompanyCityController : ApiBaseController
    {
        private readonly ILogger<CompanyCityController> _logger;
        private readonly ICompanyCityService _companyCityService;

        public CompanyCityController(ILogger<CompanyCityController> logger, ICompanyCityService companyCityService)
        {
            _logger = logger;
            _companyCityService = companyCityService;
        }

        [Authorize(Roles = "CompanyUser")]
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateCompanyCity([FromBody] CreateCompanyCityRequestContract body)
        {
            try
            {
                var companyCity = body.ConvertFromBody();
                var response = await _companyCityService.CreateCompanyCity(companyCity);

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

        [Authorize(Roles = "CompanyUser")]
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateCompanyCity([FromBody] UpdateCompanyCityRequestContract body)
        {
            try
            {
                var companyCity = body.ConvertFromBody();
                var response = await _companyCityService.UpdateCompanyCity(companyCity);

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

        [Authorize(Roles = "CompanyUser")]
        [HttpDelete]
        [Route("delete/{companyId}/{cityId}")]
        public async Task<IActionResult> DeleteCompanyCity([FromRoute(Name = "companyId")] int companyId, [FromRoute(Name = "cityId")] int cityId)
        {
            try
            {
                var response = await _companyCityService.DeleteCompanyCity(companyId, cityId);

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
        [Route("{companyId}/{cityId}")]
        public async Task<IActionResult> GetCompanyCity([FromRoute(Name = "companyId")] int companyId, [FromRoute(Name = "cityId")] int cityId)
        {
            try
            {
                if (companyId == null || cityId == null)
                    throw new Exception("companyId or cityId cannot be null.");

                var companyCity = await _companyCityService.GetCompanyCity(companyId, cityId);

                if (companyCity == null)
                    throw new Exception("CompanyCity cannot be null (CompanyCity not found).");

                return Ok(companyCity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "NormalUser")]
        [HttpGet]
        [Route("all/{companyId}")]
        public async Task<IActionResult> GetAllCompanyCities([FromRoute(Name = "companyId")] int companyId)
        {
            try
            {
                var companyCities = await _companyCityService.GetAllCompanyCities(companyId);

                if (companyCities == null)
                    throw new Exception($"Error when trying to get all CompanyCities for CompanyId: {companyId}.");

                return Ok(companyCities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
