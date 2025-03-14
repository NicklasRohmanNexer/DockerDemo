using DockerDemo.Model;

namespace DockerDemo.Service.Interface
{
    public interface IPersonService
    {
        Task<List<PersonDto>> GetAllPersons(CancellationToken cancellationToken = default);
    }
}
