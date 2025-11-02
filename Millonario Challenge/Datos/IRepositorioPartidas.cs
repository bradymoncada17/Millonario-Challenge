using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millonario_Challenge
{

    public interface IRepositorioPartidas
    {
        int GuardarPartida(int? usuarioId, int dineroGanado, int respuestasCorrectas);
        void GuardarRespuestaPartida(int partidaId, int preguntaId, int? opcionSeleccionadaId, bool esCorrecta);
        List<(string NombreUsuario, int Partidas, int DineroTotal, int RespuestasCorrectasTotales, DateTime UltimaPartida)> ObtenerRanking();
        void FinalizarPartida(int partidaId, int dineroGanado, int respuestasCorrectas);
    }
}
