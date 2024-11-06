using System.Data.SqlClient;

namespace JWT_API.Config
{
    public class SqlCon : ISqlCon
    {
        private readonly string _connection;
        public SqlCon(IConfiguration configuration)=>_connection = configuration
            .GetConnectionString("SqlConString")
            ?? throw new ArgumentException(_connection);
        public async Task<SqlConnection> SqlConAsync()
        {
            var con = new SqlConnection(_connection);
            await con.OpenAsync();
            return con;
        }
    }
}
