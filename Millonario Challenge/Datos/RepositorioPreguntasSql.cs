using MillonarioApp.Datos;
using MillonarioApp.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Millonario_Challenge
{
    public class RepositorioPreguntasSql : IRepositorioPreguntas
    {
        public List<PreguntaOpcionMultiple> ObtenerTodas()
        {
            var lista = new List<PreguntaOpcionMultiple>();
            var conexion = ConexionBD.Instancia.ObtenerConexion();

            var preguntasTemp = new List<(int id, string texto, string categoria, int dificultad, int premio)>();
            string sqlPreguntas = "SELECT PreguntaId, Texto, Categoria, Dificultad, Premio FROM Preguntas";

            using (var cmd = new SqlCommand(sqlPreguntas, conexion))
            {
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        int id = rdr.GetInt32(0);
                        string texto = rdr.GetString(1);
                        string categoria = rdr.IsDBNull(2) ? "" : rdr.GetString(2);
                        int dificultad = rdr.GetInt32(3);
                        int premio = rdr.GetInt32(4);
                        preguntasTemp.Add((id, texto, categoria, dificultad, premio));
                    }
                }
            }

            string sqlOpciones = "SELECT TextoOpcion, EsCorrecta FROM Opciones WHERE PreguntaId = @pid ORDER BY OpcionId";

            foreach (var p in preguntasTemp)
            {
                var opciones = new List<string>();
                int indiceCorrecto = 0;

                using (var cmdOp = new SqlCommand(sqlOpciones, conexion))
                {
                    cmdOp.Parameters.AddWithValue("@pid", p.id);
                    using (var rdrOp = cmdOp.ExecuteReader())
                    {
                        int idx = 0;
                        while (rdrOp.Read())
                        {
                            string textoOpcion = rdrOp.GetString(0);
                            bool esCorrecta = rdrOp.GetBoolean(1);
                            opciones.Add(textoOpcion);
                            if (esCorrecta) indiceCorrecto = idx;
                            idx++;
                        }
                    }
                }

                var pregunta = new PreguntaOpcionMultiple(
                    p.texto,
                    opciones,
                    indiceCorrecto,
                    p.dificultad,
                    p.premio,
                    p.categoria
                )
                { Id = p.id };

                lista.Add(pregunta);
            }

            return lista;
        }

        public PreguntaOpcionMultiple ObtenerPorId(int preguntaId)
        {
            PreguntaOpcionMultiple pregunta = null;
            var conexion = ConexionBD.Instancia.ObtenerConexion();

            string sqlPregunta = "SELECT PreguntaId, Texto, Categoria, Dificultad, Premio FROM Preguntas WHERE PreguntaId=@id";
            int id = 0;
            string texto = "";
            string categoria = "";
            int dificultad = 1;
            int premio = 100;

            using (var cmd = new SqlCommand(sqlPregunta, conexion))
            {
                cmd.Parameters.AddWithValue("@id", preguntaId);
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        id = rdr.GetInt32(0);
                        texto = rdr.GetString(1);
                        categoria = rdr.IsDBNull(2) ? "" : rdr.GetString(2);
                        dificultad = rdr.GetInt32(3);
                        premio = rdr.GetInt32(4);
                    }
                }
            }

            if (id == 0)
                return null;

            var opciones = new List<string>();
            int indiceCorrecto = 0;
            string sqlOpciones = "SELECT TextoOpcion, EsCorrecta FROM Opciones WHERE PreguntaId=@pid ORDER BY OpcionId";

            using (var cmdOp = new SqlCommand(sqlOpciones, conexion))
            {
                cmdOp.Parameters.AddWithValue("@pid", id);
                using (var rdrOp = cmdOp.ExecuteReader())
                {
                    int idx = 0;
                    while (rdrOp.Read())
                    {
                        string textoOpcion = rdrOp.GetString(0);
                        bool esCorrecta = rdrOp.GetBoolean(1);
                        opciones.Add(textoOpcion);
                        if (esCorrecta) indiceCorrecto = idx;
                        idx++;
                    }
                }
            }

            pregunta = new PreguntaOpcionMultiple(
                texto,
                opciones,
                indiceCorrecto,
                dificultad,
                premio,
                categoria
            )
            { Id = id };

            return pregunta;
        }

        public void Agregar(PreguntaOpcionMultiple pregunta, List<(string texto, bool esCorrecta)> opciones)
        {
            var conexion = ConexionBD.Instancia.ObtenerConexion();
            var tran = conexion.BeginTransaction();
            try
            {
                int newId;
                using (var cmd = new SqlCommand("INSERT INTO Preguntas (Texto, Categoria, Dificultad, Premio) OUTPUT INSERTED.PreguntaId VALUES(@texto,@categoria,@dif,@premio)", conexion, tran))
                {
                    cmd.Parameters.AddWithValue("@texto", pregunta.Texto);
                    cmd.Parameters.AddWithValue("@categoria", (object)pregunta.Categoria ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@dif", pregunta.Dificultad);
                    cmd.Parameters.AddWithValue("@premio", pregunta.Premio);
                    newId = (int)cmd.ExecuteScalar();
                }

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