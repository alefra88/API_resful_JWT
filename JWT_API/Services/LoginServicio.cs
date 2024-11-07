using JWT_API.Models;
using JWT_API.Repositories;

namespace JWT_API.Services
{
    public class LoginServicio : ILoginServicio
    {
        private readonly IUsuarioLoginRepository _usuarioLoginRepository;
        public LoginServicio(IUsuarioLoginRepository usuarioLoginRepository)
        {
            _usuarioLoginRepository = usuarioLoginRepository;
        }

        public async Task<bool> LoginAsync(UsuarioLoginDTO usuarioLoginDTO)
        {
            return await _usuarioLoginRepository.LoginAsync(usuarioLoginDTO);
        }
    }
}
