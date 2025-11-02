using Millonario_Challenge;
using MillonarioApp.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillonarioApp.Datos
{
    public interface IRepositorioPreguntas
    {
        List<PreguntaOpcionMultiple> ObtenerTodas();
        PreguntaOpcionMultiple ObtenerPorId(int preguntaId);
        void Agregar(PreguntaOpcionMultiple pregunta, List<(string texto, bool esCorrecta)> opciones);
        void Actualizar(PreguntaOpcionMultiple pregunta, List<(int opcionId, string texto, bool esCorrecta)> opciones);
        void Eliminar(int preguntaId);
    }
}
