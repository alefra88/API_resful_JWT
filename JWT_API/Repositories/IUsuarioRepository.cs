using JWT_API.Models;

namespace JWT_API.Repositories
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioListaDTO>> GetAsync();
        
    }
}
