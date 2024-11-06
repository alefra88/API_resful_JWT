using System.Data.SqlClient;

namespace JWT_API.Config
{
    public interface ISqlCon
    {
        Task<SqlConnection> SqlConAsync();
    }
}
