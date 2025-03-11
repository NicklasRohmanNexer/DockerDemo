using DockerDemo.Model;
using DockerDemo.Service;
using Microsoft.AspNetCore.Mvc;

namespace DockerDemo.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class TestDb(DbConnection dbConnection) : ControllerBase
    {
        [HttpGet("TestDb", Name = "TestDb")]
        public string TestDbConnection()
        {
                var result = dbConnection.TestLocalDbConnection();

                return result;
        }
    }
}
