using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillonarioApp.Modelos
{
    public class Partida
    {
        public int PartidaId { get; set; }
        public int? UsuarioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int DineroGanado { get; set; }
        public int RespuestasCorrectas { get; set; }
    }
}
