using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Millonario_Challenge
{
    public sealed class ConexionBD
    {
        private static readonly Lazy<ConexionBD> instancia = new Lazy<ConexionBD>(() => new ConexionBD());
        private readonly string cadenaConexion;
        private SqlConnection conexion;

        private ConexionBD()
        {
            // Use the strongly-typed Settings value which matches the App.config generated name
            cadenaConexion = Properties.Settings.Default.MillonarioDBConnectionString
                ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'MillonarioDBConnectionString' en Settings.");
            conexion = new SqlConnection(cadenaConexion);
        }

        public static ConexionBD Instancia => instancia.Value;

        public SqlConnection ObtenerConexion()
        {
            if (conexion.State != System.Data.ConnectionState.Open)
                conexion.Open();
            return conexion;
        }

        public void CerrarConexion()
        {
            if (conexion.State != System.Data.ConnectionState.Closed)
                conexion.Close();
        }
    }
}
