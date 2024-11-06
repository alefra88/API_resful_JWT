namespace JWT_API.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? FechaBaja { get; set; }
    }
}
