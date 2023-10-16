using BuildMe.Domain.Model;

namespace BuildMe.Application.Services.Interfaces
{
    public interface ITaskService
    {
        public Task<bool> CreateTask(_Task task);
        public Task<bool> UpdateTask(_Task task);
        public Task<bool> DeleteTask(int id, DateTime lastUpdate);
        public Task<_Task> GetTask(int id);
        public Task<IEnumerable<_Task>> GetAllTasks();
        public Task<List<_Task>> GetAllTasksWhereBiddingEnded();
        public Task<List<_Task>> GetAllUserTasks(int userId);
    }
}
