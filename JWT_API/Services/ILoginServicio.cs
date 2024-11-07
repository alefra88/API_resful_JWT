
using JWT_API.Models;

namespace JWT_API.Services
{
    public interface ILoginServicio
    {
        Task<bool> LoginAsync(UsuarioLoginDTO usuarioLoginDTO);
    }
}
