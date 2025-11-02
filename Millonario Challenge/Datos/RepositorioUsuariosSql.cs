using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Millonario_Challenge;
using System.Data.SqlClient;
using System.Configuration;
using MillonarioApp.Modelos;


namespace MillonarioApp.Datos
{
    public class RepositorioUsuariosSql : IRepositorioUsuarios
    {
        public Usuario ObtenerPorNombre(string nombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario)) return null;

            Usuario usuario = null;
            var conexion = ConexionBD.Instancia.ObtenerConexion();

            using (var cmd = new SqlCommand("SELECT UsuarioId, NombreUsuario, NombreCompleto FROM Usuarios WHERE NombreUsuario = @nombre", conexion))
            {
                cmd.Parameters.AddWithValue("@nombre", nombreUsuario);
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        usuario = new Usuario
                        {
                            UsuarioId = rdr.GetInt32(0),
                            NombreUsuario = rdr.GetString(1),
                            NombreCompleto = rdr.IsDBNull(2) ? "" : rdr.GetString(2)
                        };
                    }
                }
            }

            return usuario;
        }

        public int CrearUsuario(string nombreUsuario, string nombreCompleto)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException("El nombre de usuario no puede estar vacío.", nameof(nombreUsuario));

            var conexion = ConexionBD.Instancia.ObtenerConexion();
            using (var cmd = new SqlCommand("INSERT INTO Usuarios (NombreUsuario, NombreCompleto) OUTPUT INSERTED.UsuarioId VALUES (@nombreUsuario, @nombreCompleto)", conexion))
            {
                cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@nombreCompleto", (object)nombreCompleto ?? DBNull.Value);

                // Ejecutar y devolver el id creado
                int nuevoId = (int)cmd.ExecuteScalar();
                return nuevoId;
            }
        }

        public List<Usuario> ObtenerTodos()
        {
            var lista = new List<Usuario>();
            var conexion = ConexionBD.Instancia.ObtenerConexion();
            using (var cmd = new SqlCommand("SELECT UsuarioId, NombreUsuario, NombreCompleto FROM Usuarios ORDER BY NombreUsuario", conexion))
            {
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lista.Add(new Usuario
                        {
                            UsuarioId = rdr.GetInt32(0),
                            NombreUsuario = rdr.GetString(1),
                            NombreCompleto = rdr.IsDBNull(2) ? "" : rdr.GetString(2)
                        });
                    }
                }
            }
            return lista;
        }
    }
}



