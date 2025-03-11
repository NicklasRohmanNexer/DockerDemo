namespace DockerDemo.Service.Interface
{
    public interface IDbConnection
    {
        Microsoft.Data.SqlClient.SqlConnection GetConnection();

        Microsoft.Data.SqlClient.SqlConnection GetLocalDbConnection();

        Task<string> TestLocalDbConnectionAsync();

    }
}