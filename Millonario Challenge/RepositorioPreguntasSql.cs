using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Millonario_Challenge;
using System.Data.SqlClient;


namespace Millonario_Challenge
{
    public class RepositorioPreguntasSql : IRepositorioPreguntas

    {
        public List<PreguntaOpcionMultiple> ObtenerTodas()
        {
            var lista = new List<PreguntaOpcionMultiple>();
            var conexion = ConexionBD.Instancia.ObtenerConexion();
            using (var cmd = new SqlCommand("SELECT PreguntaId, Texto, Categoria, Dificultad, Premio FROM Preguntas", conexion))
            using (var rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    int id = rdr.GetInt32(0);
                    string texto = rdr.GetString(1);
                    string categoria = rdr.IsDBNull(2) ? "" : rdr.GetString(2);
                    int dificultad = rdr.GetInt32(3);
                    int premio = rdr.GetInt32(4);

                    // cargar opciones
                    var opciones = new List<string>();
                    int indiceCorrecto = 0;
                    using (var cmdOp = new SqlCommand("SELECT TextoOpcion, EsCorrecta FROM Opciones WHERE PreguntaId=@pid ORDER BY OpcionId", conexion))
                    {
                        cmdOp.Parameters.AddWithValue("@pid", id);
                        using (var rdrOp = cmdOp.ExecuteReader())
                        {
                            int idx = 0;
                            while (rdrOp.Read())
                            {
                                opciones.Add(rdrOp.GetString(0));
                                if (rdrOp.GetBoolean(1)) indiceCorrecto = idx;
                                idx++;
                            }
                        }
                    }

                    var p = new PreguntaOpcionMultiple(texto, opciones, indiceCorrecto, dificultad, premio, categoria) { Id = id };
                    lista.Add(p);
                }
            }
            return lista;
        }

        public PreguntaOpcionMultiple ObtenerPorId(int preguntaId)
        {
            PreguntaOpcionMultiple pregunta = null;
            var conexion = ConexionBD.Instancia.ObtenerConexion();
            using (var cmd = new SqlCommand("SELECT PreguntaId, Texto, Categoria, Dificultad, Premio FROM Preguntas WHERE PreguntaId=@id", conexion))
            {
                cmd.Parameters.AddWithValue("@id", preguntaId);
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        int id = rdr.GetInt32(0);
                        string texto = rdr.GetString(1);
                        string categoria = rdr.IsDBNull(2) ? "" : rdr.GetString(2);
                        int dificultad = rdr.GetInt32(3);
                        int premio = rdr.GetInt32(4);

                        // opciones
                        var opciones = new List<string>();
                        int indiceCorrecto = 0;
                        using (var cmdOp = new SqlCommand("SELECT TextoOpcion, EsCorrecta FROM Opciones WHERE PreguntaId=@pid ORDER BY OpcionId", conexion))
                        {
                            cmdOp.Parameters.AddWithValue("@pid", id);
                            using (var rdrOp = cmdOp.ExecuteReader())
                            {
                                int idx = 0;
                                while (rdrOp.Read())
                                {
                                    opciones.Add(rdrOp.GetString(0));
                                    if (rdrOp.GetBoolean(1)) indiceCorrecto = idx;
                                    idx++;
                                }
                            }
                        }
                        pregunta = new PreguntaOpcionMultiple(texto, opciones, indiceCorrecto, dificultad, premio, categoria) { Id = id };
                    }
                }
            }
            return pregunta;
        }

        public void Agregar(PreguntaOpcionMultiple pregunta, List<(string texto, bool esCorrecta)> opciones)
        {
            var conexion = ConexionBD.Instancia.ObtenerConexion();
            var tran = conexion.BeginTransaction();
            try
            {
                using (var cmd = new SqlCommand("INSERT INTO Preguntas (Texto, Categoria, Dificultad, Premio) OUTPUT INSERTED.PreguntaId VALUES(@texto,@categoria,@dif,@premio)", conexion, tran))
                {
                    cmd.Parameters.AddWithValue("@texto", pregunta.Texto);
                    cmd.Parameters.AddWithValue("@categoria", (object)pregunta.Categoria ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@dif", pregunta.Dificultad);
                    cmd.Parameters.AddWithValue("@premio", pregunta.Premio);
                    int newId = (int)cmd.ExecuteScalar();

                    foreach (var op in opciones)
                    {
                        using (var cmdOp = new SqlCommand("INSERT INTO Opciones (PreguntaId, TextoOpcion, EsCorrecta) VALUES(@pid,@texto,@esCorrecta)", conexion, tran))
                        {
                            cmdOp.Parameters.AddWithValue("@pid", newId);
                            cmdOp.Parameters.AddWithValue("@texto", op.texto);
                            cmdOp.Parameters.AddWithValue("@esCorrecta", op.esCorrecta ? 1 : 0);
                            cmdOp.ExecuteNonQuery();
                        }
                    }
                }
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        public void Actualizar(PreguntaOpcionMultiple pregunta, List<(int opcionId, string texto, bool esCorrecta)> opciones)
        {
            var conexion = ConexionBD.Instancia.ObtenerConexion();
            var tran = conexion.BeginTransaction();
            try
            {
                using (var cmd = new SqlCommand("UPDATE Preguntas SET Texto=@texto, Categoria=@categoria, Dificultad=@dif, Premio=@premio WHERE PreguntaId=@id", conexion, tran))
                {
                    cmd.Parameters.AddWithValue("@texto", pregunta.Texto);
                    cmd.Parameters.AddWithValue("@categoria", (object)pregunta.Categoria ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@dif", pregunta.Dificultad);
                    cmd.Parameters.AddWithValue("@premio", pregunta.Premio);
                    cmd.Parameters.AddWithValue("@id", pregunta.Id);
                    cmd.ExecuteNonQuery();
                }

                // actualizar opciones existentes; para simplicidad asumimos que opciones listadas corresponden a opciones existentes
                foreach (var op in opciones)
                {
                    using (var cmdOp = new SqlCommand("UPDATE Opciones SET TextoOpcion=@texto, EsCorrecta=@esCorrecta WHERE OpcionId=@id", conexion, tran))
                    {
                        cmdOp.Parameters.AddWithValue("@texto", op.texto);
                        cmdOp.Parameters.AddWithValue("@esCorrecta", op.esCorrecta ? 1 : 0);
                        cmdOp.Parameters.AddWithValue("@id", op.opcionId);
                        cmdOp.ExecuteNonQuery();
                    }
                }

                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        public void Eliminar(int preguntaId)
        {
            var conexion = ConexionBD.Instancia.ObtenerConexion();
            using (var cmd = new SqlCommand("DELETE FROM Preguntas WHERE PreguntaId=@id", conexion))
            {
                cmd.Parameters.AddWithValue("@id", preguntaId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}




