using JWT_API.Config;
using JWT_API.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_API.Repositories
{
    public class GenerateTokenRepo : IGenerateTokenRepo
    {
        private readonly ISqlCon _sqlCon;
        private readonly IConfiguration _config;
        public GenerateTokenRepo(ISqlCon sqlCon, IConfiguration configuration)
        {
            _sqlCon = sqlCon;
            _config = configuration;
        }
        public async Task<string> GenerateAsync(UsuarioLoginDTO usuarioLoginDTO)
        {
           return await Task.Run(() =>
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier, usuarioLoginDTO.Email),
                //deberia llevar un ClaimType.Role, usuarioModel.Rol
            };
                //crea el token
                var token = new JwtSecurityToken(
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(1),
                    signingCredentials: credentials);
                return new JwtSecurityTokenHandler().WriteToken(token);
            });
    }
    }
}