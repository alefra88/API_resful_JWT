using JWT_API.Models;
using JWT_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServicio _loginServicio;
        private readonly IGenerateTokenService _generateTokenService;
        public LoginController(ILoginServicio loginServicio, IGenerateTokenService generateTokenService)
        {
            _loginServicio = loginServicio;
            _generateTokenService = generateTokenService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioLoginDTO loginDTO)
        {
            // Llamamos al servicio para verificar el login
            bool isAuthenticated = await _loginServicio.LoginAsync(loginDTO);

            if (isAuthenticated)
            {
                var token = _generateTokenService.GenerateAsync(loginDTO);
                return Ok(new { Token = token });
            }
            else
            {
                // Si el login falla, devolvemos un 401 Unauthorized
                return Unauthorized("Credenciales incorrectas");
            }
        }
    }
}
