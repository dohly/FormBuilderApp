using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("appication/json")]
    [ApiController]
    public class PingController : ControllerBase
    {
        /// <summary>
        /// Ping endpoint. Frontend app calls it on "init" form
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get() => Ok(new { });
    }
}