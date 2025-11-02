using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillonarioApp.Modelos
{
    public abstract class Pregunta
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public string Categoria { get; set; }
        public int Dificultad { get; set; }
        public int Premio { get; set; }
        public abstract IList<string> Opciones { get; }
        public abstract int IndiceCorrecto { get; }
    }
}
