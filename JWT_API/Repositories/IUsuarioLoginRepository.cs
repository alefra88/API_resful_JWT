using JWT_API.Models;

namespace JWT_API.Repositories
{
    public interface IUsuarioLoginRepository
    {
        Task<bool> LoginAsync(UsuarioLoginDTO usuarioLoginDTO);
    }
}
