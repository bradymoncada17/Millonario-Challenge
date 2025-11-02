using MillonarioApp.Datos;
using MillonarioApp.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Millonario_Challenge
{
    public partial class FormularioAdmin : Form
    {
        private readonly IRepositorioPreguntas _repoPreguntas;

        // Constructor recibe la dependencia (repo) para facilitar pruebas y reutilización.
        public FormularioAdmin(IRepositorioPreguntas repoPreg)
        {
            InitializeComponent();
            _repoPreguntas = repoPreg ?? throw new ArgumentNullException(nameof(repoPreg));
            CargarLista();
        }

        private void CargarLista()
        {
            lstPreguntas.Items.Clear();
            var preguntas = _repoPreguntas.ObtenerTodas();
            foreach (var p in preguntas)
            {
                // Muestra "Id - Texto" para poder extraer fácilmente el id
                lstPreguntas.Items.Add($"{p.Id} - {p.Texto}");
            }
        }

        private void lstPreguntas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstPreguntas.SelectedIndex == -1)
                {
                    LimpiarCampos();
                    return;
                }

                var texto = lstPreguntas.SelectedItem?.ToString();
                if (string.IsNullOrWhiteSpace(texto))
                {
                    LimpiarCampos();
                    return;
                }

                // Esperamos "ID - Texto"
                var partes = texto.Split(new char[] { '-' }, 2);
                if (partes.Length < 1 || !int.TryParse(partes[0].Trim(), out int id))
                {
                    MessageBox.Show("No se pudo leer el id de la pregunta seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var pregunta = _repoPreguntas.ObtenerPorId(id);
                if (pregunta == null)
                {
                    MessageBox.Show($"No se encontró la pregunta con id {id}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarCampos();
                    return;
                }

                // Asignar valores a los controles (suponiendo que PreguntaOpcionMultiple implementa Opciones como IList<string>)
                txtPregunta.Text = pregunta.Texto ?? "";
                // Si usas ComboBox para dificultad:
                if (this.Controls.ContainsKey("cmbDificultad"))
                {
                    var cmb = this.Controls["cmbDificultad"] as ComboBox;
                    if (cmb != null)
                    {
                        cmb.SelectedIndex = Math.Max(0, Math.Min(2, pregunta.Dificultad - 1));
                    }
                }
                else
                {
                    txtDificultad.Text = pregunta.Dificultad.ToString();
                }

                // Opciones (asumimos mínimo 4; si no, llenamos con cadenas vacías)
                var ops = pregunta.Opciones ?? new List<string> { "", "", "", "" };
                txtOpcionA.Text = ops.ElementAtOrDefault(0) ?? "";
                txtOpcionB.Text = ops.ElementAtOrDefault(1) ?? "";
                txtOpcionC.Text = ops.ElementAtOrDefault(2) ?? "";
                txtOpcionD.Text = ops.ElementAtOrDefault(3) ?? "";

                txtIndiceCorrecto.Text = pregunta.IndiceCorrecto.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la pregunta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

       

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
        }
        private void btnCargarSemilla_Click(object sender, EventArgs e)
        {
            try
            {
                // Ruta del archivo CSV (puedes cambiarla según donde lo guardes)
                string rutaArchivo = Path.Combine(Application.StartupPath, "Preguntas.csv");

                if (!File.Exists(rutaArchivo))
                {
                    MessageBox.Show("No se encontró el archivo Preguntas.csv en la carpeta del proyecto.");
                    return;
                }

                // Leer todas las líneas del archivo, omitiendo la primera (encabezados)
                var lineas = File.ReadAllLines(rutaArchivo).Skip(1);

                foreach (var linea in lineas)
                {
                    if (string.IsNullOrWhiteSpace(linea)) continue;

                    var partes = linea.Split(';');
                    if (partes.Length < 8)
                    {
                        MessageBox.Show("Formato incorrecto en el archivo CSV.");
                        return;
                    }

                    string texto = partes[0].Trim();
                    string opcionA = partes[1].Trim();
                    string opcionB = partes[2].Trim();
                    string opcionC = partes[3].Trim();
                    string opcionD = partes[4].Trim();
                    int indiceCorrecto = int.Parse(partes[5]);
                    int dificultad = int.Parse(partes[6]);
                    string categoria = partes[7].Trim();
                    int premio = int.Parse(partes[8]);

                    var opciones = new List<(string texto, bool esCorrecta)>
            {
                (opcionA, indiceCorrecto == 0),
                (opcionB, indiceCorrecto == 1),
                (opcionC, indiceCorrecto == 2),
                (opcionD, indiceCorrecto == 3)
            };

                    var pregunta = new PreguntaOpcionMultiple(texto,
                        new List<string> { opcionA, opcionB, opcionC, opcionD },
                        indiceCorrecto,
                        dificultad,
                        premio,
                        categoria);

                    _repoPreguntas.Agregar(pregunta, opciones);
                }

                MessageBox.Show("Preguntas cargadas correctamente desde el archivo CSV.");
                CargarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la semilla: " + ex.Message);
            }
        }


        private void LimpiarCampos()
        {
            txtPregunta.Clear();
            txtOpcionA.Clear();
            txtOpcionB.Clear();
            txtOpcionC.Clear();
            txtOpcionD.Clear();
            txtIndiceCorrecto.Clear();
            if (this.Controls.ContainsKey("cmbDificultad"))
            {
                var cmb = this.Controls["cmbDificultad"] as ComboBox;
                if (cmb != null) cmb.SelectedIndex = 0;
            }
            else
            {
                txtDificultad.Clear();
            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // VALIDACIÓN
                if (string.IsNullOrWhiteSpace(txtPregunta.Text) ||
                    string.IsNullOrWhiteSpace(txtOpcionA.Text) ||
                    string.IsNullOrWhiteSpace(txtOpcionB.Text) ||
                    string.IsNullOrWhiteSpace(txtOpcionC.Text) ||
                    string.IsNullOrWhiteSpace(txtOpcionD.Text) ||
                    !int.TryParse(txtIndiceCorrecto.Text, out int indice) || indice < 0 || indice > 3)
                {
                    MessageBox.Show("Complete todos los campos correctamente (Índice 0..3).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int dif;
                if (this.Controls.ContainsKey("cmbDificultad"))
                {
                    var cmb = this.Controls["cmbDificultad"] as ComboBox;
                    dif = (cmb != null) ? cmb.SelectedIndex + 1 : 1;
                }
                else
                {
                    if (!int.TryParse(txtDificultad.Text, out dif) || dif < 1 || dif > 3)
                    {
                        MessageBox.Show("Seleccione o ingrese una dificultad válida (1..3).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Crear PreguntaOpcionMultiple y lista opciones para el repositorio
                var listaOpciones = new List<string> { txtOpcionA.Text, txtOpcionB.Text, txtOpcionC.Text, txtOpcionD.Text };
                var pregunta = new PreguntaOpcionMultiple(txtPregunta.Text, listaOpciones, indice, dif, dif * 100, "General");

                // Construir lista de tuplas (texto, esCorrecta) según la firma del repositorio
                var opcionesParaRepo = new List<(string texto, bool esCorrecta)>
                {
                    (txtOpcionA.Text, indice == 0),
                    (txtOpcionB.Text, indice == 1),
                    (txtOpcionC.Text, indice == 2),
                    (txtOpcionD.Text, indice == 3)
                };

                _repoPreguntas.Agregar(pregunta, opcionesParaRepo);

                MessageBox.Show("Pregunta agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarLista();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la pregunta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (lstPreguntas.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione una pregunta para editar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var texto = lstPreguntas.SelectedItem.ToString();
                var partes = texto.Split(new char[] { '-' }, 2);
                if (!int.TryParse(partes[0].Trim(), out int id))
                {
                    MessageBox.Show("No se pudo leer el id de la pregunta seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPregunta.Text) ||
                    string.IsNullOrWhiteSpace(txtOpcionA.Text) ||
                    string.IsNullOrWhiteSpace(txtOpcionB.Text) ||
                    string.IsNullOrWhiteSpace(txtOpcionC.Text) ||
                    string.IsNullOrWhiteSpace(txtOpcionD.Text) ||
                    !int.TryParse(txtIndiceCorrecto.Text, out int indice) || indice < 0 || indice > 3)
                {
                    MessageBox.Show("Complete todos los campos correctamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int dif;
                if (this.Controls.ContainsKey("cmbDificultad"))
                {
                    var cmb = this.Controls["cmbDificultad"] as ComboBox;
                    dif = (cmb != null) ? cmb.SelectedIndex + 1 : 1;
                }
                else
                {
                    if (!int.TryParse(txtDificultad.Text, out dif) || dif < 1 || dif > 3)
                    {
                        MessageBox.Show("Seleccione o ingrese una dificultad válida (1..3).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Opción 1 (sencilla): eliminar la pregunta antigua y crear una nueva con mismo contenido
                // (más simple si aún no implementaste Actualizar con manejo de OpcionId)
                _repoPreguntas.Eliminar(id);

                var listaOpciones = new List<string> { txtOpcionA.Text, txtOpcionB.Text, txtOpcionC.Text, txtOpcionD.Text };
                var nuevaPregunta = new PreguntaOpcionMultiple(txtPregunta.Text, listaOpciones, indice, dif, dif * 100, "General");
                var opcionesParaRepo = new List<(string texto, bool esCorrecta)>
                {
                    (txtOpcionA.Text, indice == 0),
                    (txtOpcionB.Text, indice == 1),
                    (txtOpcionC.Text, indice == 2),
                    (txtOpcionD.Text, indice == 3)
                };

                _repoPreguntas.Agregar(nuevaPregunta, opcionesParaRepo);

                MessageBox.Show("Pregunta editada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarLista();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar la pregunta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (lstPreguntas.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione una pregunta para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var texto = lstPreguntas.SelectedItem.ToString();
                var partes = texto.Split(new char[] { '-' }, 2);
                if (!int.TryParse(partes[0].Trim(), out int id))
                {
                    MessageBox.Show("No se pudo leer el id de la pregunta seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirmar = MessageBox.Show("¿Seguro que desea eliminar esta pregunta?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmar == DialogResult.Yes)
                {
                    _repoPreguntas.Eliminar(id);
                    MessageBox.Show("Pregunta eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarLista();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la pregunta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


