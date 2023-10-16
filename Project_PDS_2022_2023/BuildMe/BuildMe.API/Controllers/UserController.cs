using BuildMe.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BuildMe.API.Extensions.Users;
using BuildMe.API.Data.Contracts.Users;
using BuildMe.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using BuildMe.Domain.Model;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Data;

namespace BuildMe.API.Controllers
{
    [ApiVersion("1.0")]
    public class UserController : ApiBaseController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(ILogger<UserController> logger, IUserService userService, IConfiguration configuration)
        {
            _logger = logger;
            _userService = userService;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> GetUserLogin([FromBody] UserLoginRequestContract body)
        {
            try
            {
                var user = body.ConvertFromBody();
                var response = await _userService.GetUserLogin(user.UserName, user.Password);

                if (response == null)
                {
                    return BadRequest();
                }

                //var authenticationResponse = _jwtService.CreateToken(response);
                var authenticationResponse = GenerateJwtToken(response);

                return Ok(new UserLoginResponseContract()
                {
                    Token = authenticationResponse,
                    UserId = response.Id
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestContract body)
        {
            try
            {
                var user = body.ConvertFromBody();
                var response = await _userService.CreateUser(user);

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
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequestContract body)
        {
            try
            {
                var user = body.ConvertFromBody();
                var response = await _userService.UpdateUser(user);

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
                var response = await _userService.DeleteUser(id, lastUpdate);

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
        public async Task<IActionResult> GetUser([FromRoute(Name = "id")] int id)
        {
            try
            {
                if (id == null)
                    throw new Exception("Id cannot be null.");

                var user = await _userService.GetUser(id);

                if (user == null)
                    throw new Exception("User cannot be null (user not found).");

                return Ok(new GetUserResponseContract()
                {
                    Id = user.Id,
                    Address = user.Address,
                    CompanyId = user.CompanyId is null ? 0 : (int)user.CompanyId,
                    Email = user.Email,
                    Inactive = user.Inactive,
                    LastUpdate = user.LastUpdate,
                    Phone = user.Phone,
                    PostalCode = user.PostalCode,
                    UserName = user.UserName,
                    UserTypeId = user.UserTypeId,
                    VAT = user.VAT
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "NormalUser")]
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var user = await _userService.GetAllUsers();

                if (user == null)
                    throw new Exception("User cannot be null (user not found).");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "NormalUser"),
            };

            if (user.UserTypeId == 1)
            {
                claims.Add(new Claim(ClaimTypes.Role, "CompanyUser"));
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }
            else if (user.UserTypeId == 3)
            {
                claims.Add(new Claim(ClaimTypes.Role, "CompanyUser"));
            }

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims.ToArray(),
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
