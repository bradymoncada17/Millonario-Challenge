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

        private int _usuarioId; // añade este campo en la clase

        public FormularioJuego(IRepositorioPreguntas repoP, IRepositorioPartidas repoPa, IRepositorioUsuarios repoU, int usuarioId)
        {
            InitializeComponent();

            _repoPreg = repoP;
            _repoPart = repoPa;
            _repoUsr = repoU;
            _usuarioId = usuarioId;

            // Crear la partida en la base de datos y guardar su Id
            // GuardarPartida acepta usuarioId (nullable), dinero inicial 0 y correctas 0
            _partidaId = _repoPart.GuardarPartida(_usuarioId > 0 ? (int?)_usuarioId : null, 0, 0);

            if (_partidaId <= 0)
            {
                MessageBox.Show("No se pudo crear la partida en la base de datos. Revisa la conexión.");
                this.Close();
                return;
            }

            // Suscribir eventos y preparar interfaz (si no lo haces en designer)
            btnRespuestaA.Click += BotonRespuesta_Click;
            btnRespuestaB.Click += BotonRespuesta_Click;
            btnRespuestaC.Click += BotonRespuesta_Click;
            btnRespuestaD.Click += BotonRespuesta_Click;

            btnRespuestaA.Tag = 0;
            btnRespuestaB.Tag = 1;
            btnRespuestaC.Tag = 2;
            btnRespuestaD.Tag = 3;

            CargarPreguntas();
            MostrarPregunta();
        }
        private void CargarPreguntas()
        {
            var todas = _repoPreg.ObtenerTodas() ?? new List<PreguntaOpcionMultiple>();

            // Mezclar y tomar hasta 15
            _preguntas = todas.OrderBy(x => Guid.NewGuid()).Take(Math.Min(15, todas.Count)).ToList();

            // Si no hay preguntas, avisar y cerrar el formulario
            if (_preguntas == null || _preguntas.Count == 0)
            {
                MessageBox.Show("No hay preguntas disponibles. Contacte al administrador.");
                this.Close(); // cierra el formulario de juego
            }

            // Asegurarse de que el índice empiece en 0 al cargar preguntas
            _indiceActual = 0;
        }
        private void MostrarPregunta()
        {
            // Si la lista es nula o vacía, cerramos
            if (_preguntas == null || _preguntas.Count == 0)
            {
                MessageBox.Show("No hay preguntas para mostrar.");
                this.Close();
                return;
            }

            // Si _indiceActual está fuera de rango, finalizamos la partida
            if (_indiceActual < 0 || _indiceActual >= _preguntas.Count)
            {
                // Ya no hay más preguntas: finalizamos
                FinalizarPartida();
                return;
            }

            var p = _preguntas[_indiceActual];
            lblPregunta.Text = $"[{_indiceActual + 1}] {p.Texto}";

            // Asignar textos de botones (asegúrate que Opciones tenga 4 elementos)
            btnRespuestaA.Text = "A) " + (p.Opciones.Count > 0 ? p.Opciones[0] : "");
            btnRespuestaB.Text = "B) " + (p.Opciones.Count > 1 ? p.Opciones[1] : "");
            btnRespuestaC.Text = "C) " + (p.Opciones.Count > 2 ? p.Opciones[2] : "");
            btnRespuestaD.Text = "D) " + (p.Opciones.Count > 3 ? p.Opciones[3] : "");

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

        private void btnRetirarse_Click(object sender, EventArgs e)
        {

            FinalizarPartida();

        }

        private void BotonRespuesta_Click(object sender, EventArgs e)
        {
            if (_partidaId <= 0)
            {
                MessageBox.Show("Error: la partida no fue creada. No se puede registrar la respuesta.");
                return;
            }

            Button boton = (Button)sender;
            int seleccionado = Convert.ToInt32(boton.Tag);
            var p = _preguntas[_indiceActual];
            bool esCorrecto = seleccionado == p.IndiceCorrecto;

            try
            {
                if (esCorrecto)
                {
                    _correctas++;
                    _dinero += p.Premio;
                    lblDinero.Text = "Dinero: " + _dinero;

                    // Aquí idealmente pasarías el id real de la opción (si lo tienes).
                    // Si no tienes OpcionId, puedes dejar null si la columna lo permite.
                    _repoPart.GuardarRespuestaPartida(_partidaId, p.Id, null, true);

                    _indiceActual++;
                    MostrarPregunta();
                }
                else
                {
                    _repoPart.GuardarRespuestaPartida(_partidaId, p.Id, null, false);
                    MessageBox.Show("Respuesta incorrecta. Fin del juego.");
                    FinalizarPartida();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la respuesta: " + ex.Message);
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
