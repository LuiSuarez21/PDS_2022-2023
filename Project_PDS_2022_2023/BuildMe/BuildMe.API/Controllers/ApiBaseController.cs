using Microsoft.AspNetCore.Mvc;

namespace BuildMe.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class ApiBaseController : ControllerBase
    {
    }
}
