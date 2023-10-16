using BuildMe.API.Data.Contracts.CompanyBudget;
using BuildMe.API.Extensions.CompanyBudgets;
using BuildMe.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildMe.API.Controllers
{
    [ApiVersion("1.0")]
    public class CompanyBudgetController : ApiBaseController
    {
        private readonly ILogger<CompanyBudgetController> _logger;
        private readonly ICompanyBudgetService _companyBudgetService;

        public CompanyBudgetController(ILogger<CompanyBudgetController> logger, ICompanyBudgetService companyBudgetService)
        {
            _logger = logger;
            _companyBudgetService = companyBudgetService;
        }

        [Authorize(Roles = "CompanyUser")]
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateCompanyBudget([FromBody] CreateCompanyBudgetRequestContract body)
        {
            try
            {
                var companyBudget = body.ConvertFromBody();
                var response = await _companyBudgetService.CreateCompanyBudget(companyBudget);

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
        public async Task<IActionResult> UpdateCompanyBudget([FromBody] UpdateCompanyBudgetRequestContract body)
        {
            try
            {
                var companyBudget = body.ConvertFromBody();
                var response = await _companyBudgetService.UpdateCompanyBudget(companyBudget);

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
        [Route("delete/{companyId}/{taskId}")]
        public async Task<IActionResult> DeleteCompanyBudget([FromRoute(Name = "companyId")] int companyId, [FromRoute(Name = "taskId")] int taskId)
        {
            try
            {
                var response = await _companyBudgetService.DeleteCompanyBudget(companyId, taskId);

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
        [Route("{companyId}/{taskId}")]
        public async Task<IActionResult> GetCompanyBudget([FromRoute(Name = "companyId")] int companyId, [FromRoute(Name = "taskId")] int taskId)
        {
            try
            {
                if (companyId == null || taskId == null)
                    throw new Exception("companyId or taskId cannot be null.");

                var companyBudget = await _companyBudgetService.GetCompanyBudget(companyId, taskId);

                if (companyBudget == null)
                    throw new Exception("CompanyBudget cannot be null (CompanyBudget not found).");

                return Ok(companyBudget);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "NormalUser")]
        [HttpGet]
        [Route("all/{companyId}")]
        public async Task<IActionResult> GetAllCompanyBudgets([FromRoute(Name = "companyId")] int companyId)
        {
            try
            {
                var companyBudgets = await _companyBudgetService.GetAllCompanyBudgetsWithCompany(companyId);

                if (companyBudgets == null)
                    throw new Exception($"Error when trying to get all CompanyBudgets for CompanyId: {companyId}.");

                return Ok(companyBudgets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
