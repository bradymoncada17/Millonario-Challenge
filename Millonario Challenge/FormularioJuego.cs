using MillonarioApp.Datos;
using MillonarioApp.Modelos;
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
    public partial class FormularioJuego : Form
    {
        private IRepositorioPreguntas _repoPreg;
        private IRepositorioPartidas _repoPart;
        private IRepositorioUsuarios _repoUsr;

        private List<PreguntaOpcionMultiple> _preguntas;
        private int _indiceActual = 0;
        private int _dinero = 0;
        private int _correctas = 0;
        private int _partidaId = 0;
        private bool _uso5050 = false, _usoPublico = false, _usoLlamar = false;

        public FormularioJuego(IRepositorioPreguntas repoP, IRepositorioPartidas repoPa, IRepositorioUsuarios repoU)
        {
            InitializeComponent();
            _repoPreg = repoP;
            _repoPart = repoPa;
            _repoUsr = repoU;
            CargarPreguntas();
            MostrarPregunta();
        }
        private void CargarPreguntas()
        {
            var todas = _repoPreg.ObtenerTodas();
            _preguntas = todas.OrderBy(x => Guid.NewGuid()).Take(Math.Min(15, todas.Count)).ToList();
        }
        private void MostrarPregunta()
        {
            if (_indiceActual >= _preguntas.Count)
            {
                MessageBox.Show("¡Completaste el juego!");
                FinalizarPartida();
                return;
            }
            var p = _preguntas[_indiceActual];
            lblPregunta.Text = $"[{_indiceActual + 1}] {p.Texto}";
            btnRespuestaA.Text = "A) " + p.Opciones[0];
            btnRespuestaB.Text = "B) " + p.Opciones[1];
            btnRespuestaC.Text = "C) " + p.Opciones[2];
            btnRespuestaD.Text = "D) " + p.Opciones[3];
            btnRespuestaA.Enabled = btnRespuestaB.Enabled = btnRespuestaC.Enabled = btnRespuestaD.Enabled = true;
        }
       
        private void FinalizarPartida()
        {
            try
            {
                // Guardar los datos finales de la partida en la base de datos
                _repoPart.FinalizarPartida(_partidaId, _dinero, _correctas);

                // Mostrar un resumen al jugador
                MessageBox.Show(
                    $"Fin del juego.\n\nRespuestas correctas: {_correctas}\nDinero ganado: {_dinero}",
                    "Partida finalizada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Cerrar el formulario de juego y volver al menú principal
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al finalizar la partida: " + ex.Message);
            }
        }
        private void FormularioJuego_Load(object sender, EventArgs e)
        {
            btnRespuestaA.Tag = 0;
            btnRespuestaB.Tag = 1;
            btnRespuestaC.Tag = 2;
            btnRespuestaD.Tag = 3;
        }
        private void BotonRespuesta_Click(object sender, EventArgs e)
        {
            // Saber cuál botón fue presionado
            Button boton = (Button)sender;

            // Convertir el valor del Tag (0, 1, 2 o 3) a número
            int seleccionado = Convert.ToInt32(boton.Tag);

            // Obtener la pregunta actual
            var p = _preguntas[_indiceActual];

            // Verificar si la respuesta es correcta
            bool esCorrecto = seleccionado == p.IndiceCorrecto;

            if (esCorrecto)
            {
                _correctas++;
                _dinero += p.Premio;
                lblDinero.Text = "Dinero: " + _dinero;

                // Guardar respuesta correcta en base de datos
                _repoPart.GuardarRespuestaPartida(_partidaId, p.Id, null, true);

                // Pasar a la siguiente pregunta
                _indiceActual++;
                MostrarPregunta();
            }
            else
            {
                MessageBox.Show("Respuesta incorrecta. Fin del juego.");
                _repoPart.GuardarRespuestaPartida(_partidaId, p.Id, null, false);
                FinalizarPartida();
            }
        }






        private void btnCincuentaCincuenta_Click(object sender, EventArgs e)
        {
            if (_uso5050) { MessageBox.Show("Ya usaste 50:50"); return; }
            var p = _preguntas[_indiceActual];
            var incorrectas = Enumerable.Range(0, 4).Where(i => i != p.IndiceCorrecto).OrderBy(x => Guid.NewGuid()).Take(2).ToList();
            foreach (var idx in incorrectas)
            {
                if (idx == 0) btnRespuestaA.Enabled = false;
                if (idx == 1) btnRespuestaB.Enabled = false;
                if (idx == 2) btnRespuestaC.Enabled = false;
                if (idx == 3) btnRespuestaD.Enabled = false;
            }
            _uso5050 = true;
        }

       
    }
}
