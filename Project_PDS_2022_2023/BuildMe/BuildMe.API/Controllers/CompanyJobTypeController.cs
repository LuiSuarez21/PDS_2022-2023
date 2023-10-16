using BuildMe.API.Data.Contracts.CompanyJobType;
using BuildMe.API.Extensions.CompanyJobTypes;
using BuildMe.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildMe.API.Controllers
{
    [ApiVersion("1.0")]
    public class CompanyJobTypeController : ApiBaseController
    {
        private readonly ILogger<CompanyJobTypeController> _logger;
        private readonly ICompanyJobTypeService _companyJobTypeService;

        public CompanyJobTypeController(ILogger<CompanyJobTypeController> logger, ICompanyJobTypeService companyJobTypeService)
        {
            _logger = logger;
            _companyJobTypeService = companyJobTypeService;
        }

        [Authorize(Roles = "CompanyUser")]
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateCompanyJobType([FromBody] CreateCompanyJobTypeRequestContract body)
        {
            try
            {
                var companyyJobType = body.ConvertFromBody();
                var response = await _companyJobTypeService.CreateCompanyJobType(companyyJobType);

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
        public async Task<IActionResult> UpdateCompanyyJobType([FromBody] UpdateCompanyJobTypeRequestContract body)
        {
            try
            {
                var companyJobType = body.ConvertFromBody();
                var response = await _companyJobTypeService.UpdateCompanyJobType(companyJobType);

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
        [Route("delete/{companyId}/{jobTypeId}")]
        public async Task<IActionResult> DeleteCompanyJobType([FromRoute(Name = "companyId")] int companyId, [FromRoute(Name = "jobTypeId")] int jobTypeId)
        {
            try
            {
                var response = await _companyJobTypeService.DeleteCompanyJobType(companyId, jobTypeId);

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
        [Route("{companyId}/{jobTypeId}")]
        public async Task<IActionResult> GetCompanyJobType([FromRoute(Name = "companyId")] int companyId, [FromRoute(Name = "jobTypeId")] int jobTypeId)
        {
            try
            {
                if (companyId == null || jobTypeId == null)
                    throw new Exception("companyId or jobTypeId cannot be null.");

                var companyJobType = await _companyJobTypeService.DeleteCompanyJobType(companyId, jobTypeId);

                if (companyJobType == null)
                    throw new Exception("CompanyJobType cannot be null (CompanJobType not found).");

                return Ok(companyJobType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "NormalUser")]
        [HttpGet]
        [Route("all/{companyId}")]
        public async Task<IActionResult> GetAllCompanyJobTypes([FromRoute(Name = "companyId")] int companyId)
        {
            try
            {
                var companyJobTypes = await _companyJobTypeService.GetAllCompanyJobTypes(companyId);

                if (companyJobTypes == null)
                    throw new Exception($"Error when trying to get all CompanyJobTypes for CompanyId: {companyId}.");

                return Ok(companyJobTypes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
