using Dapper;
using JWT_API.Config;
using JWT_API.Models;
using System.Security.Cryptography;
using System.Text;

namespace JWT_API.Repositories
{
    public class AuthenticateRepo : IAuthenticateRepo
    {
        private readonly ISqlCon _sqlCon;

        public AuthenticateRepo(ISqlCon sqlCon)
        {
            _sqlCon = sqlCon;
        }
        public async Task<bool> AuthenticateAsync(UsuarioLoginDTO usuarioLoginDTO)
        {
            // Obtener conexión asíncrona
            using var connection = await _sqlCon.SqlConAsync();

            // Consulta SQL para obtener el hash de la contraseña usando el email
            var query = @"SELECT Password FROM Usuarios WHERE Email = @Email";

            // Ejecutar la consulta para obtener el hash almacenado
            byte[] storedPasswordHash = await connection.QuerySingleOrDefaultAsync<byte[]>(query, new { Email = usuarioLoginDTO.Email });

            if (storedPasswordHash == null)
            {
                // Si el usuario no existe, devolvemos false
                return false;
            }


            // Generamos el hash de la contraseña ingresada
            byte[] inputPasswordHash = HashPassword(usuarioLoginDTO.Password);

            // Comparamos el hash de la base de datos con el hash generado
            return storedPasswordHash.SequenceEqual(inputPasswordHash);

        }

        // Método para hashear la contraseña usando SHA-256
        private static byte[] HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
