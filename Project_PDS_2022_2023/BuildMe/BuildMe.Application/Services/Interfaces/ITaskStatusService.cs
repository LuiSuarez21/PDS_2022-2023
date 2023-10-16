using BuildMe.Domain.Model;

namespace BuildMe.Application.Services.Interfaces
{
    public interface ITaskStatusService
    {
        public Task<bool> CreateTaskStatus(_TaskStatus taskStatus);
        public Task<bool> UpdateTaskStatus(_TaskStatus taskStatus);
        public Task<bool> DeleteTaskStatus(int id, DateTime lastUpdate);
        public Task<_TaskStatus> GetTaskStatus(int id);
        public Task<IEnumerable<_TaskStatus>> GetAllTaskStatuses();
    }
}
