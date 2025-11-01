using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millonario_Challenge
{
    public class Opcion
    {
        public int OpcionId { get; set; }
        public int PreguntaId { get; set; }
        public string TextoOpcion { get; set; }
        public bool EsCorrecta { get; set; }


    }
}
