using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Millonario_Challenge
{
    public class RespuestaPartida
    {
        public int RespuestaPartidaId { get; set; }
        public int PartidaId { get; set; }
        public int PreguntaId { get; set; }
        public int? OpcionSeleccionadaId { get; set; }
        public bool? EsCorrecta { get; set; }
    }
}
