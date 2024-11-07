using JWT_API.Models;
using JWT_API.Repositories;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace JWT_API.Services
{
    public class GenerateTokenService : IGenerateTokenService
    {
        private readonly IGenerateTokenRepo _repo;
        public GenerateTokenService(IGenerateTokenRepo repo)
        {

        _repo = repo; 
        
        }
    
        public async Task<string> GenerateAsync(UsuarioLoginDTO usuarioLoginDTO)
        {
            return await _repo.GenerateAsync(usuarioLoginDTO);
        }
    }
}
