using BuildMe.Application.Services.Interfaces;
using BuildMe.Domain.Model;
using BuildMe.Infrastructure.Gateways.Interfaces;
using Microsoft.Extensions.Logging;

namespace BuildMe.Infrastructure.Services
{
    public class JobTypeService : IJobTypeService
    {
        private readonly ILogger<JobTypeService> _logger;
        private readonly IJobTypeGateway _jobTypeGateway;

        public JobTypeService(ILogger<JobTypeService> logger, IJobTypeGateway jobTypeGateway)
        {
            _logger = logger;
            _jobTypeGateway = jobTypeGateway;
        }

        public async Task<bool> CreateJobType(JobType jobType)
        {
            try
            {
                return await _jobTypeGateway.CreateJobType(jobType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to insert jobType with id [{jobType.Id}]");
                throw;
            }
        }

        public async Task<bool> UpdateJobType(JobType jobType)
        {
            try
            {
                return await _jobTypeGateway.UpdateJobType(jobType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to update jobType with id [{jobType.Id}]");
                throw;
            }
        }

        public async Task<bool> DeleteJobType(int id, DateTime lastUpdate)
        {
            try
            {
                return await _jobTypeGateway.DeleteJobType(id, lastUpdate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to delete jobType with id [{id}]");
                throw;
            }
        }

        public async Task<JobType> GetJobType(int id)
        {
            try
            {
                return await _jobTypeGateway.GetJobType(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to get jobType with id [{id}]");
                throw;
            }
        }

        public async Task<IEnumerable<JobType>> GetAllJobTypes()
        {
            try
            {
                var cities = await _jobTypeGateway.GetAllJobTypes();
                return cities;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to get all cities list");
                throw;
            }
        }

        public async Task<List<JobType>> GetAllJobTypesDescription(string description)
        {
            try
            {
                var jobTypes = await _jobTypeGateway.GetAllJobTypesDescription(description);
                return jobTypes.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to get all cities list");
                throw;
            }
        }
    }
}