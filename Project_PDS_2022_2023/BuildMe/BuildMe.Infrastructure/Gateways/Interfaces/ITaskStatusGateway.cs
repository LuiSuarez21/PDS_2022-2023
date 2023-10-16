using BuildMe.Domain.Model;

namespace BuildMe.Infrastructure.Gateways.Interfaces
{
    public interface ITaskSatusGateway
    {
        public Task<bool> CreateTaskStatus(_TaskStatus taskStatus);
        public Task<bool> UpdateTaskStatus(_TaskStatus taskStatus);
        public Task<bool> DeleteTaskStatus(int id, DateTime lastUpdate);
        public Task<_TaskStatus> GetTaskStatus(int id);
        public Task<IEnumerable<_TaskStatus>> GetAllTaskStatuses();
    }
}
