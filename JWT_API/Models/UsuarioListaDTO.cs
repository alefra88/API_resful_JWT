namespace JWT_API.Models
{
    public class UsuarioListaDTO
    {
        public int IdUsuario { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Email { get; set; }
        public DateTime? FechaBaja { get; set; }
    }
}
