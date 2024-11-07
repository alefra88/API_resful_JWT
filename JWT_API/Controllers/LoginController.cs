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
        public LoginController(ILoginServicio loginServicio)
        {
            _loginServicio = loginServicio;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioLoginDTO loginDTO)
        {
            // Llamamos al servicio para verificar el login
            bool isAuthenticated = await _loginServicio.LoginAsync(loginDTO);

            if (isAuthenticated)
            {
                // Si el login es exitoso, devolvemos un 200 OK con un mensaje
                return Ok("Usuario logeado exitosamente");
            }
            else
            {
                // Si el login falla, devolvemos un 401 Unauthorized
                return Unauthorized("Credenciales incorrectas");
            }
        }
    }
}
