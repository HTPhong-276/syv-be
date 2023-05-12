using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace syv_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HaController : ControllerBase
    {
        [HttpGet("admin")]
        [Authorize(Roles = "ADMIN")]
        public string Admin()
        {
            return "Ha Admin";
        }

        [HttpGet("user")]
        [Authorize(Roles = "USER")]
        public string User()
        {
            return "Ha User";
        }
    }
}
