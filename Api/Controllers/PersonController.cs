using DockerDemo.Model;
using DockerDemo.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DockerDemo.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class PersonController(IPersonService personService) : ControllerBase
    {
        [HttpGet("getAllPersons", Name = "GetAllPersons")]
        public async Task<ActionResult<List<PersonDto>>> GetAllPersons(CancellationToken cancellationToken)
        {
            try
            {
                var result = new List<PersonDto>();

                var dockerdbPersons = await personService.GetAllPersons(cancellationToken);

                foreach (var person in dockerdbPersons)
                {
                    result.Add(person);
                }


                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Personlist exception " + ex);
            }
        }
    }
}
