using BuildMe.Application.Services.Interfaces;
using BuildMe.Domain.Model;
using BuildMe.Infrastructure.Gateways;
using BuildMe.Infrastructure.Gateways.Interfaces;
using Microsoft.Extensions.Logging;
using System.ComponentModel.Design;

namespace BuildMe.Infrastructure.Services
{
    public class CompanyJobTypeService : ICompanyJobTypeService
    {
        private readonly ILogger<CompanyJobTypeService> _logger;
        private readonly ICompanyJobTypeGateway _companyJobTypeGateway;
        private readonly IJobTypeService _jobTypeService;

        public CompanyJobTypeService(ILogger<CompanyJobTypeService> logger, ICompanyJobTypeGateway companyJobTypeGateway, IJobTypeService job)
        {
            _logger = logger;
            _companyJobTypeGateway = companyJobTypeGateway;
            _jobTypeService = job;
        }

        public async Task<bool> CreateCompanyJobType(CompanyJobType companyJobTypey)
        {
            try
            {
                return await _companyJobTypeGateway.CreateCompanyJobType(companyJobTypey);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to insert company with id {companyJobTypey.CompanyId} and jobType with id {companyJobTypey.JobTypeId}");
                throw;
            }
        }

        public async Task<bool> UpdateCompanyJobType(CompanyJobType companyJobType)
        {
            try
            {
                return await _companyJobTypeGateway.UpdateCompanyJobType(companyJobType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to update company with id {companyJobType.CompanyId} and jobType with id {companyJobType.JobTypeId}");
                throw;
            }
        }

        public async Task<bool> DeleteCompanyJobType(int companyId, int jobTypeId)
        {
            try
            {
                return await _companyJobTypeGateway.DeleteCompanyJobType(companyId, jobTypeId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to delete jobType {jobTypeId} from company {companyId}");
                throw;
            }
        }

        public async Task<CompanyJobType> GetCompanyJobType(int companyId, int jobTypeId)
        {
            try
            {
                return await _companyJobTypeGateway.GetCompanyJobType(companyId, jobTypeId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to get jobType {jobTypeId} from company {companyId}");
                throw;
            }
        }

        public async Task<IEnumerable<CompanyJobType>> GetAllCompanyJobTypes(int companyId)
        {
            try
            {
                return await _companyJobTypeGateway.GetAllCompanyJobTypes(companyId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to get all jobTypes from company {companyId}");
                throw;
            }
        }

        public async Task<float> GetAvarageBudgets(string description)
        {
            try
            {
                double total = 0;
                double media = 0;
                var result = await _jobTypeService.GetAllJobTypesDescription(description);
                if (result == null)
                    return 0;

                foreach (var jobType in result)
                {
                    var companyJobType = await GetCompanyJobTybeBudget(jobType.Id);
                    total += companyJobType.Sum(c => c.AveragePrice) / companyJobType.Count();
                }

                if (result.Count() != 0)
                {
                    media = total / result.Count();
                    return (float)media;
                }

                else { return 0; }
                
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<CompanyJobType>> GetCompanyJobTybeBudget(int jobTypeId)
        {
            try
            {
                return await _companyJobTypeGateway.GetCompanyJobTybeBudget(jobTypeId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when trying to get all jobTypes from company {jobTypeId}");
                throw;
            }
        }
    }
}