using MillonarioApp.Datos;
using MillonarioApp.Modelos;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Millonario_Challenge
{
    public partial class FormularioPrincipal : Form
    {
        private readonly IRepositorioPreguntas _repoPreg;
        private readonly IRepositorioPartidas _repoPart;
        private readonly IRepositorioUsuarios _repoUsr;

        // Guardar datos del usuario que llegaron al constructor
        private readonly int _usuarioId;
        private readonly string _nombreUsuario;

        public FormularioPrincipal(int usuarioId, string nombreUsuario)
        {
            InitializeComponent();

            _usuarioId = usuarioId;
            _nombreUsuario = nombreUsuario;

            _repoPreg = new RepositorioPreguntasSql();
            _repoPart = new RepositorioPartidasSql();
            _repoUsr = new RepositorioUsuariosSql();

            // Opcional: mostrar saludo en un Label llamado lblBienvenida
            if (this.Controls.ContainsKey("lblBienvenida"))
            {
                var lbl = this.Controls["lblBienvenida"] as Label;
                if (lbl != null) lbl.Text = $"Bienvenido, {_nombreUsuario}";
            }
        }
        // Campo en la clase
        private readonly string[] usuariosAutorizados = new[] { "Brady", "Profesor" };

        // En el constructor o en Load, ocultar el botón si no está autorizado
        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {
            if (!usuariosAutorizados.Any(u => u.Equals(_nombreUsuario, StringComparison.OrdinalIgnoreCase)))
            {
                btnAdministrarPreguntas.Visible = false; // u btnAdministrarPreguntas.Enabled = false;
            }
        }

        private void btnIniciarJuego_Click(object sender, EventArgs e)
        {
            // Pasar el usuarioId al constructor del FormularioJuego (ya que lo solicita)
            var frm = new FormularioJuego(_repoPreg, _repoPart, _repoUsr, _usuarioId);
            frm.ShowDialog();
        }

        private void btnAdministrarPreguntas_Click(object sender, EventArgs e)
        {

            if (usuariosAutorizados.Any(u => u.Equals(_nombreUsuario, StringComparison.OrdinalIgnoreCase)))
            {
                var frm = new FormularioAdmin(_repoPreg);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Solo usuarios autorizados pueden acceder.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnRanking_Click(object sender, EventArgs e)
        {
            var frm = new FormularioRanking(_repoPart);
            frm.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}