using Millonario_Challenge;
using MillonarioApp.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillonarioApp.Fabrica
{
    public static class FabricaPreguntas
    {
        public static PreguntaOpcionMultiple CrearOpcionMultiple(string texto, string a, string b, string c, string d, int indiceCorrecto, int dificultad, int premio, string categoria = "General")
        {
            var lista = new List<string> { a, b, c, d };
            return new PreguntaOpcionMultiple(texto, lista, indiceCorrecto, dificultad, premio, categoria);
        }
    }
}
