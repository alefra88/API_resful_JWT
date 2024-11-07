using JWT_API.Models;

namespace JWT_API.Services
{
    public interface IGenerateTokenService
    {
        Task<string> GenerateAsync(UsuarioLoginDTO usuarioLoginDTO);
    }
}
