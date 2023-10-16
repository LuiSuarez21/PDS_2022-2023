using BuildMe.API.Data.Contracts.JobType;
using BuildMe.Domain.Model;

namespace BuildMe.API.Extensions.JobTypes
{
    public static class JobTypeExtension
    {
        public static JobType ConvertFromBody(this CreateJobTypeRequestContract newJobTypes)
        {
            return new JobType()
            {
                Description = newJobTypes.Description,
            };
        }

        public static JobType ConvertFromBody(this UpdateJobTypeRequestContract updateJobTypes)
        {
            return new JobType()
            {
                Id = updateJobTypes.Id,
                Description = updateJobTypes.Description,
                Inactive = updateJobTypes.Inactive,
                LastUpdate = updateJobTypes.LastUpdate
            };
        }
    }
}
