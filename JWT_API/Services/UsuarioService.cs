using JWT_API.Models;
using JWT_API.Repositories;

namespace JWT_API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<List<UsuarioListaDTO>> GetAsync()
        {
            return await _usuarioRepository.GetAsync();
        }
    }
}
