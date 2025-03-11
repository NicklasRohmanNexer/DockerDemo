using Microsoft.Data.SqlClient;

namespace DockerDemo.Service
{
    public class DbConnection(IConfiguration configuration)
    {
        private readonly string _conString = configuration.GetConnectionString("DbConnection") ?? throw new InvalidOperationException("Connection string not found.");
        private readonly string _localDbConString = configuration.GetConnectionString("LocalDbConnection") ?? throw new InvalidOperationException("LocalDbConnection string not found.");

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_conString);
        }

        public SqlConnection GetLocalDbConnection()
        {
            return new SqlConnection(_localDbConString);
        }

        public string TestLocalDbConnection()
        {
            try
            {
                using (var connection = new SqlConnection(_localDbConString))
                {
                    connection.Open();
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
