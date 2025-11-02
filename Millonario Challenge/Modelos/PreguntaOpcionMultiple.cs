using Millonario_Challenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillonarioApp.Modelos
{
    public class PreguntaOpcionMultiple : Pregunta
    {
        public List<string> ListaOpciones { get; set; }
        public int IndiceCorrectoInterno { get; set; }

        public PreguntaOpcionMultiple() { ListaOpciones = new List<string> { "", "", "", "" }; }

        public PreguntaOpcionMultiple(string texto, List<string> opciones, int indiceCorrecto, int dificultad, int premio, string categoria = "General")
        {
            Texto = texto;
            ListaOpciones = opciones;
            IndiceCorrectoInterno = indiceCorrecto;
            Dificultad = dificultad;
            Premio = premio;
            Categoria = categoria;
        }

        public override IList<string> Opciones => ListaOpciones;
        public override int IndiceCorrecto => IndiceCorrectoInterno;
    }
}

