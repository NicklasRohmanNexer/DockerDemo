using DockerDemo.Model;
using DockerDemo.Service.Interface;
using Microsoft.Data.SqlClient;

namespace DockerDemo.Service
{
    public class PersonService(DbConnection dbConnection) : IPersonService
    {

        public async Task<List<PersonDto>> GetAllPersons(CancellationToken cancellationToken = default)
        {
            var persons = new List<PersonDto>();

            SqlConnection connection = dbConnection.GetConnection();
            await connection.OpenAsync(cancellationToken);

            string query = "SELECT [PersonID],[Name],[Age],[City] FROM [dockerdemo].[dbo].[Person]";
            SqlCommand command = new(query, connection);
            SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);

            while (await reader.ReadAsync(cancellationToken))
            {
                var person = new PersonDto
                {
                    PersonID = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Age = reader.GetInt32(2),
                    City = reader.GetString(3),

                };
                persons.Add(person);
            }

            await reader.CloseAsync();
            await connection.CloseAsync();

            return persons;
        }
    }
}
