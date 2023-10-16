using BuildMe.Domain.Model;

namespace BuildMe.Infrastructure.Gateways.Interfaces
{
    public interface ITaskGateway
    {
        public Task<bool> CreateTask(_Task task);
        public Task<bool> UpdateTask(_Task task);
        public Task<bool> DeleteTask(int id, DateTime lastUpdate);
        public Task<_Task> GetTask(int id);
        public Task<IEnumerable<_Task>> GetAllTasks();
        public Task<IEnumerable<_Task>> GetAllTasksWhereBiddingEnded();
        public Task<IEnumerable<_Task>> GetAllUserTasks(int userId);
    }
}
