using Microsoft.AspNetCore.Mvc;

namespace DockerDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : Controller
    {
        [HttpGet(Name = "ping")]
        public bool Get()
        {
            return true;
        }
    }
}