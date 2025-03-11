using DockerDemo.Service;
using DockerDemo.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DockerDemo.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class TestDbController(IDbConnection dbConnection) : ControllerBase
    {
        [HttpGet("TestDb", Name = "TestDb")]
        public async Task<string> TestDbConnection()
        {
            var result = await dbConnection.TestLocalDbConnectionAsync();

            return result;
        }
    }
}
