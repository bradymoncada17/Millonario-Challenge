using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;


namespace Millonario_Challenge
{
    internal class RepositorioPartidasSql : IRepositorioPartidas
    {
        // Guarda una partida y devuelve el id insertado
        public int GuardarPartida(int? usuarioId, int dineroGanado, int respuestasCorrectas)
        {
            var conexion = ConexionBD.Instancia.ObtenerConexion();
            try
            {
                using (var cmd = new SqlCommand("INSERT INTO Partidas (UsuarioId, FechaInicio, FechaFin, DineroGanado, RespuestasCorrectas) OUTPUT INSERTED.PartidaId VALUES(@uid, GETDATE(), NULL, @dinero, @correctas)", conexion))
                {
                    cmd.Parameters.AddWithValue("@uid", usuarioId.HasValue ? (object)usuarioId.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@dinero", dineroGanado);
                    cmd.Parameters.AddWithValue("@correctas", respuestasCorrectas);
                    var result = cmd.ExecuteScalar();
                    return result == null ? 0 : Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                // puedes loggear aquí o relanzar con más contexto
                throw new Exception("Error al guardar la partida: " + ex.Message, ex);
            }
        }

        // Inserta una respuesta de una partida
        public void GuardarRespuestaPartida(int partidaId, int preguntaId, int? opcionSeleccionadaId, bool esCorrecta)
        {
            var conexion = ConexionBD.Instancia.ObtenerConexion();
            try
            {
                using (var cmd = new SqlCommand("INSERT INTO RespuestasPartida (PartidaId, PreguntaId, OpcionSeleccionadaId, EsCorrecta) VALUES(@pid,@qid,@oid,@esCorrecta)", conexion))
                {
                    cmd.Parameters.AddWithValue("@pid", partidaId);
                    cmd.Parameters.AddWithValue("@qid", preguntaId);
                    cmd.Parameters.AddWithValue("@oid", opcionSeleccionadaId.HasValue ? (object)opcionSeleccionadaId.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@esCorrecta", esCorrecta ? 1 : 0);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la respuesta de la partida: " + ex.Message, ex);
            }
        }

        // Actualiza la partida al finalizar (opcional, útil si inicializas la partida antes)
        public void FinalizarPartida(int partidaId, int dineroGanado, int respuestasCorrectas)
        {
            var conexion = ConexionBD.Instancia.ObtenerConexion();
            try
            {
                using (var cmd = new SqlCommand("UPDATE Partidas SET FechaFin = GETDATE(), DineroGanado = @dinero, RespuestasCorrectas = @correctas WHERE PartidaId = @id", conexion))
                {
                    cmd.Parameters.AddWithValue("@dinero", dineroGanado);
                    cmd.Parameters.AddWithValue("@correctas", respuestasCorrectas);
                    cmd.Parameters.AddWithValue("@id", partidaId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al finalizar la partida: " + ex.Message, ex);
            }
        }

        // Devuelve el ranking
        public List<(string NombreUsuario, int Partidas, int DineroTotal, int RespuestasCorrectasTotales)> ObtenerRanking()
        {
            var resultado = new List<(string NombreUsuario, int Partidas, int DineroTotal, int RespuestasCorrectasTotales)>();

            string sql = @"
                SELECT ISNULL(u.NombreUsuario,'Invitado') as NombreUsuario,
                       COUNT(p.PartidaId) AS Partidas,
                       ISNULL(SUM(p.DineroGanado),0) AS DineroTotal,
                       ISNULL(SUM(p.RespuestasCorrectas),0) AS RespuestasCorrectasTotales
                FROM Partidas p
                LEFT JOIN Usuarios u ON p.UsuarioId = u.UsuarioId
                GROUP BY ISNULL(u.NombreUsuario,'Invitado')
                ORDER BY DineroTotal DESC, RespuestasCorrectasTotales DESC;
            ";

            var conexion = ConexionBD.Instancia.ObtenerConexion();

            try
            {
                using (var comando = new SqlCommand(sql, conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            string nombreUsuario = lector.IsDBNull(0) ? "Invitado" : lector.GetString(0);
                            int partidas = lector.IsDBNull(1) ? 0 : lector.GetInt32(1);
                            int dineroTotal = lector.IsDBNull(2) ? 0 : lector.GetInt32(2);
                            int respuestasCorrectas = lector.IsDBNull(3) ? 0 : lector.GetInt32(3);

                            resultado.Add((nombreUsuario, partidas, dineroTotal, respuestasCorrectas));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el ranking: " + ex.Message, ex);
            }

            return resultado;
        }

        List<(string NombreUsuario, int Partidas, int DineroTotal, int RespuestasCorrectasTotales, DateTime UltimaPartida)> IRepositorioPartidas.ObtenerRanking()
        {
            throw new NotImplementedException();
        }
    }
}