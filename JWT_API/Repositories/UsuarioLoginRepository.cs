using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Dapper;
using JWT_API.Config;
using JWT_API.Models;

namespace JWT_API.Repositories
{
    public class UsuarioLoginRepository : IUsuarioLoginRepository
    {
        private readonly ISqlCon _sqlCon;
        private readonly IAuthenticateRepo _authenticateRepo;

        public UsuarioLoginRepository(ISqlCon sqlCon, IAuthenticateRepo authenticateRepo)
        {
            _sqlCon = sqlCon;
            _authenticateRepo = authenticateRepo;
        }

        public async Task<bool> LoginAsync(UsuarioLoginDTO usuarioLoginDTO)
        {
            return await _authenticateRepo.AuthenticateAsync(usuarioLoginDTO);
        }
    }
}