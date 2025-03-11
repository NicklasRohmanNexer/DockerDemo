using DockerDemo.Service.Interface;
using Microsoft.Data.SqlClient;

namespace DockerDemo.Service
{
    public class DbConnection(IConfiguration configuration) : IDbConnection
    {
        private readonly string _conString = configuration.GetConnectionString("DbConnection") ?? throw new InvalidOperationException("Connection string not found.");
        private readonly string _localDbConString = configuration.GetConnectionString("LocalDbConnection") ?? throw new InvalidOperationException("LocalDbConnection string not found.");

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_conString);
        }

        public SqlConnection GetLocalDbConnection()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Localdockerdemo;User Id=sa;Password=SuperSecret1!";
            return new SqlConnection(connectionString);
        }

        public async Task<string> TestLocalDbConnectionAsync()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Localdockerdemo;User Id=sa;Password=SuperSecret1!";
            try
            {
                await using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    return "Connection to LocalDb successful!";
                }
            }
            catch (Exception ex)
            {
                return $"Error connecting to LocalDb: {ex.Message}";
            }
        }
    }
}
