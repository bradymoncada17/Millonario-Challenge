using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Millonario_Challenge
{
    public static class ExportadorCsv
    {
        public static void ExportarRanking(string ruta, List<(string NombreUsuario, int Partidas, int DineroTotal, int RespuestasCorrectasTotales)> filas)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Usuario,Partidas,DineroTotal,RespuestasCorrectasTotales");
            foreach (var f in filas)
            {
                sb.AppendLine($"{f.NombreUsuario},{f.Partidas},{f.DineroTotal},{f.RespuestasCorrectasTotales}");
            }
            File.WriteAllText(ruta, sb.ToString(), Encoding.UTF8);
        }
    }
}