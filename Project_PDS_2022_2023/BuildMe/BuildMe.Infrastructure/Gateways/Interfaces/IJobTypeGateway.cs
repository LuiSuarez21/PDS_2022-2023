using BuildMe.Domain.Model;

namespace BuildMe.Infrastructure.Gateways.Interfaces
{
    public interface IJobTypeGateway
    {
        public Task<bool> CreateJobType(JobType jobType);
        public Task<bool> UpdateJobType(JobType jobType);
        public Task<bool> DeleteJobType(int id, DateTime lastUpdate);
        public Task<JobType> GetJobType(int id);
        public Task<IEnumerable<JobType>> GetAllJobTypes();
        public Task<IEnumerable<JobType>> GetAllJobTypesDescription(string description);
    }
}
