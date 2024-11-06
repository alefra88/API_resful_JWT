using JWT_API.Config;
using JWT_API.Models;
using System.Data;
using System.Data.SqlClient;

namespace JWT_API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ISqlCon _sqlCon;
        public UsuarioRepository(ISqlCon sqlCon)
        {
            _sqlCon = sqlCon;
        }
        public async Task<List<UsuarioListaDTO>> GetAsync()
        {
            var listaUsuarios = new List<UsuarioListaDTO>();
            var storedProcedure = "spSeleccionarDatosUsuarios";
            using(SqlConnection con = await _sqlCon.SqlConAsync())
            {
                using var command = new SqlCommand(storedProcedure, con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                using var reader = await command.ExecuteReaderAsync();
                while(await reader.ReadAsync())
                {
                    var alumno = MapReaderUsuarioLista(reader);
                    listaUsuarios.Add(alumno);
                }
                return listaUsuarios;
            }
        }
        private static UsuarioListaDTO MapReaderUsuarioLista(SqlDataReader reader)
        {
            return new UsuarioListaDTO
            {
                IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario")),
                FechaAlta = reader.GetDateTime(reader.GetOrdinal("FechaAlta")),
                Email = reader.GetString(reader.GetOrdinal("email")),
                FechaBaja = reader.IsDBNull(reader.GetOrdinal("FechaBaja")) ? (DateTime?)null: reader.GetDateTime(reader.GetOrdinal("FechaBaja"))
            };
        }
    }
}
