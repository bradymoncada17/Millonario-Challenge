using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Millonario_Challenge
{
    public partial class FormularioRegistroUsuario : Form
    {
        public int UsuarioId { get; private set; }
        public string NombreUsuario { get; private set; }
        public string NombreCompleto { get; private set; }

        public FormularioRegistroUsuario()
        {
            InitializeComponent();
        }



        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string nombreCompleto = txtNombreCompleto.Text.Trim();

            if (string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show("Por favor ingrese un nombre de usuario.", "Advertencia");
                return;
            }

            try
            {
                // Fecha actual del PC
                DateTime fechaActual = DateTime.Now;

                // Conexión a la base de datos (ya configurada en tu proyecto)
                var conexion = ConexionBD.Instancia.ObtenerConexion();

                // Verificar si el usuario ya existe
                using (var cmdVerificar = new SqlCommand("SELECT UsuarioId FROM Usuarios WHERE NombreUsuario = @nombre", conexion))
                {
                    cmdVerificar.Parameters.AddWithValue("@nombre", usuario);
                    var resultado = cmdVerificar.ExecuteScalar();

                    if (resultado != null)
                    {
                        // Si el usuario ya existe, mostrar mensaje
                        UsuarioId = Convert.ToInt32(resultado);
                        NombreUsuario = usuario;
                        NombreCompleto = nombreCompleto;

                        MessageBox.Show("Bienvenido de nuevo, " + usuario);
                    }
                    else
                    {
                        // Si el usuario no existe, lo insertamos con la fecha del PC
                        using (var cmdInsert = new SqlCommand(
                            "INSERT INTO Usuarios (NombreUsuario, NombreCompleto, FechaCreacion) " +
                            "OUTPUT INSERTED.UsuarioId VALUES (@usuario, @nombreCompleto, @fecha)", conexion))
                        {
                            cmdInsert.Parameters.AddWithValue("@usuario", usuario);
                            cmdInsert.Parameters.AddWithValue("@nombreCompleto",
                                string.IsNullOrWhiteSpace(nombreCompleto) ? (object)DBNull.Value : nombreCompleto);
                            cmdInsert.Parameters.AddWithValue("@fecha", fechaActual);

                            UsuarioId = (int)cmdInsert.ExecuteScalar();
                            NombreUsuario = usuario;
                            NombreCompleto = nombreCompleto;

                            MessageBox.Show("Usuario registrado correctamente el " + fechaActual.ToString("dd/MM/yyyy HH:mm"));
                        }
                    }
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el usuario: " + ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
