using BuildMe.API.Data.Contracts;
using BuildMe.API.Data.Contracts.City;
using BuildMe.API.Data.Contracts.Task;
using BuildMe.API.Extensions.Task;
using BuildMe.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildMe.API.Controllers
{
    [ApiVersion("1.0")]
    public class TaskController : ApiBaseController
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ITaskService _taskService;

        public TaskController(ILogger<TaskController> logger, ITaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }

        [Authorize(Roles = "NormalUser")]
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequestContract body)
        {
            try
            {
                var task = body.ConvertFromBody();
                var response = await _taskService.CreateTask(task);

                if (!response)
                    throw new Exception("Error when trying to create a company");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "NormalUser")]
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskRequestContract body)
        {
            try
            {
                var task = body.ConvertFromBody();
                var response = await _taskService.UpdateTask(task);

                if (!response)
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "NormalUser")]
        [HttpDelete]
        [Route("delete/{id}/{lastUpdate}")]
        public async Task<IActionResult> DeleteUser([FromRoute(Name = "id")] int id, [FromRoute(Name = "lastUpdate")] DateTime lastUpdate)
        {
            try
            {
                var response = await _taskService.DeleteTask(id, lastUpdate);

                if (!response)
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "NormalUser")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTask([FromRoute(Name = "id")] int id)
        {
            try
            {
                if (id == null)
                    throw new Exception("Id cannot be null");

                var company = await _taskService.GetTask(id);

                if (company == null)
                    throw new Exception("Task cannot be null (task not found)");

                return Ok(company);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "NormalUser")]
        [HttpGet]
        [Route("task/all")]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var tasks = await _taskService.GetAllTasks();

                if (tasks == null)
                    throw new Exception("Error when trying to get all taks");

                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "NormalUser")]
        [HttpGet]
        [Route("userTasks/{userId}")]
        public async Task<IActionResult> GetAllTasks([FromRoute(Name = "userId")] int userId)
        {
            try
            {
                var tasks = await _taskService.GetAllUserTasks(userId);

                if (tasks == null)
                {
                    throw new Exception("Error when trying to get all user taks");
                }

                var listOfUserTaks = new List<GetAllUserTasksResponseContract>();

                foreach (var task in tasks)
                {
                    listOfUserTaks.Add(new GetAllUserTasksResponseContract()
                    {
                        Id = task.Id,
                        CityId = task.CityId,
                        Description = task.Description,
                        DateBiddingEnd = task.DateBiddingEnd,
                        DateBiddingStart = task.DateBiddingStart,
                        DateEnd = task.DateEnd,
                        DateStart = task.DateStart,
                        TaskStatusId = task.TaskStatusId,
                        UserId = task.UserId,
                        Inactive = task.Inactive,
                        LastUpdate = task.LastUpdate
                    });
                }
                
                if (listOfUserTaks.Count == 0)
                {
                    throw new Exception("Error no user tasks");
                }

                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
