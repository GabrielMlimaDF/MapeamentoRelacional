using Microsoft.AspNetCore.Mvc;

namespace Models.Controller
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [Route("")]
        [HttpGet("")]
        public ActionResult Get()
        {
            return Ok("Funcionando");
        }
    }
}