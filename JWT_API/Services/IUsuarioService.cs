using JWT_API.Models;

namespace JWT_API.Services
{
    public interface IUsuarioService
    {
        Task<List<UsuarioListaDTO>> GetAsync();
    }
}
