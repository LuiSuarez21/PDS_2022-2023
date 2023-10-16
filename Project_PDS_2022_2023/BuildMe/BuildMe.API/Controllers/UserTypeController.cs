using BuildMe.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BuildMe.API.Extensions.UserTypes;
using BuildMe.API.Data.Contracts.UserTypes;
using Microsoft.AspNetCore.Authorization;

namespace BuildMe.API.Controllers
{
    [ApiVersion("1.0")]
    public class UserTypeController : ApiBaseController
    {
        private readonly ILogger<UserTypeController> _logger;
        private readonly IUserTypeService _userTypeService;

        public UserTypeController(ILogger<UserTypeController> logger, IUserTypeService userTypeService)
        {
            _logger = logger;
            _userTypeService = userTypeService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateUserType([FromBody] CreateUserTypeRequestContract body)
        {
            try
            {
                var userType = body.ConvertFromBody();
                var response = await _userTypeService.CreateUserType(userType);

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

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUserType([FromBody] UpdateUserTypeRequestContract body)
        {
            try
            {
                var userType = body.ConvertFromBody();
                var response = await _userTypeService.UpdateUserType(userType);

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

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("delete/{id}/{lastUpdate}")]
        public async Task<IActionResult> DeleteUser([FromRoute(Name = "id")] int id, [FromRoute(Name = "lastUpdate")] DateTime lastUpdate)
        {
            try
            {
                var response = await _userTypeService.DeleteUserType(id, lastUpdate);

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
        public async Task<IActionResult> GetUserType([FromRoute(Name = "id")] int id)
        {
            try
            {
                if (id == null)
                    throw new Exception("Id cannot be null.");

                var userType = await _userTypeService.GetUserType(id);

                if (userType == null)
                    throw new Exception("UserType cannot be null (UserType not found).");

                return Ok(userType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "NormalUser")]
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllUserTypes()
        {
            try
            {
                var userTypes = await _userTypeService.GetAllUserTypes();

                if (userTypes == null)
                    throw new Exception("Error when trying to get all userTypes.");

                return Ok(userTypes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
