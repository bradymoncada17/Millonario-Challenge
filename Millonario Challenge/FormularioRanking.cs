using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Millonario_Challenge
{
    public partial class FormularioRanking : Form
    {
        private RepositorioPartidasSql _repoPart;

        public FormularioRanking(IRepositorioPartidas repo)
        {
            InitializeComponent();
            _repoPart = new RepositorioPartidasSql(); // 🔹 Se crea aquí
            CargarRanking();
        }

        private void CargarRanking()
        {
            try
            {
                var rows = _repoPart.ObtenerRanking();
                dgvRanking.DataSource = rows.Select(r => new
                {
                    r.NombreUsuario,
                    r.Partidas,
                    r.DineroTotal,
                    r.RespuestasCorrectasTotales
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el ranking: " + ex.Message);
            }
        }

        

        private void btnExportarCsv_Click_1(object sender, EventArgs e)
        {
            try
            {
                var filas = _repoPart.ObtenerRanking();
                var sfd = new SaveFileDialog()
                {
                    Filter = "CSV|*.csv",
                    FileName = "ranking.csv"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportadorCsv.ExportarRanking(sfd.FileName, filas);
                    MessageBox.Show("Exportado correctamente a: " + sfd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar CSV: " + ex.Message);
            }
        }
    }
}