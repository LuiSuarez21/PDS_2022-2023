using BuildMe.API.Data.Contracts.JobType;
using BuildMe.API.Extensions.JobTypes;
using BuildMe.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildMe.API.Controllers
{
    [ApiVersion("1.0")]
    public class JobTypeController : ApiBaseController
    {
        private readonly ILogger<JobTypeController> _logger;
        private readonly IJobTypeService _jobTypeService;
        private readonly ICompanyJobTypeService _companyJobTypeService;

        public JobTypeController(ILogger<JobTypeController> logger, IJobTypeService jobTypesService, ICompanyJobTypeService companyJobTypeService)
        {
            _logger = logger;
            _jobTypeService = jobTypesService;
            _companyJobTypeService = companyJobTypeService;
        }

        [Authorize(Roles = "CompanyUser")]
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateJobType([FromBody] CreateJobTypeRequestContract body)
        {
            try
            {
                var jobTypes = body.ConvertFromBody();
                var response = await _jobTypeService.CreateJobType(jobTypes);

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
        public async Task<IActionResult> UpdateJobType([FromBody] UpdateJobTypeRequestContract body)
        {
            try
            {
                var jobTypes = body.ConvertFromBody();
                var response = await _jobTypeService.UpdateJobType(jobTypes);

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
                var response = await _jobTypeService.DeleteJobType(id, lastUpdate);

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
        public async Task<IActionResult> GetJobType([FromRoute(Name = "id")] int id)
        {
            try
            {
                if (id == null)
                    throw new Exception("Id cannot be null.");

                var userType = await _jobTypeService.GetJobType(id);

                if (userType == null)
                    throw new Exception("JobType cannot be null (JobType not found).");

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
        public async Task<IActionResult> GetAllJobType()
        {
            try
            {
                var jobTypes = await _jobTypeService.GetAllJobTypes();

                if (jobTypes == null)
                    throw new Exception("Error when trying to get all types of Job.");

                return Ok(jobTypes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "NormalUser")]
        [HttpGet]
        [Route("all/{description}")]
        public async Task<IActionResult> GetAvarageBudget([FromRoute(Name = "description")] string description)
        {
            try
            {
                var companyJobTypes = await (_companyJobTypeService.GetAvarageBudgets(description));

                if (companyJobTypes == null)
                    throw new Exception($"Error when trying to get a budget for Description: {description}.");

                return Ok(companyJobTypes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
