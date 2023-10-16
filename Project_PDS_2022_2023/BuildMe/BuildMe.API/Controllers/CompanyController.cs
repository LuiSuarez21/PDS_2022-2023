using BuildMe.API.Data.Contracts.Company;
using BuildMe.API.Extensions.Companies;
using BuildMe.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildMe.API.Controllers
{
    [ApiVersion("1.0")]
    public class CompanyController : ApiBaseController
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ICompanyService _companyService;

        public CompanyController(ILogger<CompanyController> logger, ICompanyService companyService)
        {
            _logger = logger;
            _companyService = companyService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyRequestContract body)
        {
            try
            {
                var company = body.ConvertFromBody();
                var response = await _companyService.CreateCompany(company);

                if (!response)
                    throw new Exception("Error when trying to create a company");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "CompanyUser")]
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompanyRequestContract body)
        {
            try
            {
                var company = body.ConvertFromBody();
                var response = await _companyService.UpdateCompany(company);

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
        [Route("delete/{id}/{lastUpdate}")]
        public async Task<IActionResult> DeleteUser([FromRoute(Name = "id")] int id, [FromRoute(Name = "lastUpdate")] DateTime lastUpdate)
        {
            try
            {
                var response = await _companyService.DeleteCompany(id, lastUpdate);

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
        public async Task<IActionResult> GetCompany([FromRoute(Name = "id")] int id)
        {
            try
            {
                if (id == null)
                    throw new Exception("Id cannot be null");

                var company = await _companyService.GetCompany(id);

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
        [Route("Jobs/{name}")]
        public async Task<IActionResult> GetCompanyJobs([FromRoute(Name = "name")] string name)
        {
            try
            {
                if (name == null)
                    throw new Exception("Name cannot be null");

                var companyJobs = await _companyService.GetAllJobsFromCompany(name);

                if (companyJobs == null)
                    throw new Exception("Company cannot be null (company not found)");

                return Ok(companyJobs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "NormalUser")]
        [HttpGet]
        [Route("Jobs")]
        public async Task<IActionResult> GetCompanyMostJobs()
        {
            try
            {

                var companyJobs = await _companyService.GetCompanyWithMostJobs();

                if (companyJobs == null)
                    throw new Exception("Company cannot be null (company not found)");

                return Ok(companyJobs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "NormalUser")]
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllCompanies()
        {
            try
            {
                var companies = await _companyService.GetAllCompanies();

                if (companies == null)
                    throw new Exception("Error when trying to get all companies");

                return Ok(companies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
