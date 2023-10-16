using BuildMe.Domain.Model;

namespace BuildMe.Application.Services.Interfaces
{
    public interface IJobTypeService
    {
        public Task<bool> CreateJobType(JobType jobType);
        public Task<bool> UpdateJobType(JobType jobType);
        public Task<bool> DeleteJobType(int id, DateTime lastUpdate);
        public Task<JobType> GetJobType(int id);
        public Task<IEnumerable<JobType>> GetAllJobTypes();
        public Task<List<JobType>> GetAllJobTypesDescription(string description);
    }
}
