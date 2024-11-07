using JWT_API.Models;

namespace JWT_API.Repositories
{
    public interface IGenerateTokenRepo
    {
        Task<string> GenerateAsync(UsuarioLoginDTO usuarioLoginDTO);
    }
}
