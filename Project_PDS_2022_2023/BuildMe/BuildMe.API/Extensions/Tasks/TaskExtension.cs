using BuildMe.API.Data.Contracts.Task;
using BuildMe.Domain.Model;

namespace BuildMe.API.Extensions.Task
{
    public static class TaskExtension
    {
        public static _Task ConvertFromBody(this CreateTaskRequestContract newTask)
        {
            return new _Task()
            {
                Description = newTask.Description,
                UserId = newTask.UserId,
                CityId = newTask.CityId,
                DateStart = newTask.DateStart,
                DateEnd = newTask.DateEnd,
                DateBiddingStart = newTask.DateBiddingStart,
                DateBiddingEnd = newTask.DateBiddingEnd,
                TaskStatusId = newTask.TaskStatusId
            };
        }

        public static _Task ConvertFromBody(this UpdateTaskRequestContract updateTask)
        {
            return new _Task()
            {
                Id = updateTask.Id,
                Description = updateTask.Description,
                UserId = updateTask.UserId,
                CityId = updateTask.CityId,
                DateStart = updateTask.DateStart,
                DateEnd = updateTask.DateEnd,
                DateBiddingStart = updateTask.DateBiddingStart,
                DateBiddingEnd = updateTask.DateBiddingEnd,
                TaskStatusId = updateTask.TaskStatusId,
                Inactive = updateTask.Inactive,
                LastUpdate = updateTask.LastUpdate
            };
        }
    }
}
