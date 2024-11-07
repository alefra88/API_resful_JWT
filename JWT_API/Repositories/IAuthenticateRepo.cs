using JWT_API.Models;

namespace JWT_API.Repositories
{
    public interface IAuthenticateRepo
    {
        Task<bool> AuthenticateAsync(UsuarioLoginDTO loginDTO);
    }
}
