using Desk.Domain.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Desk.Api.Controllers
{
    [ApiController]
    [Route("")]
    [AllowAnonymous]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public GenericCommandResult Get()
        {
            return new GenericCommandResult(true, "Api on-line", null);
        }
    }
}