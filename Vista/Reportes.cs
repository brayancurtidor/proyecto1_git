using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administracion_Torneos.Vista
{
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            this.Hide();
            tablapos ts = new tablapos();
            ts.Show();
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tarjetas tt = new Tarjetas();
            tt.Show();
        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReporteCanchas reporteCanchas = new ReporteCanchas();
            reporteCanchas.Show();
        }

        private void btnSiete_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportePlanillaArbitro reportePlanillaArbitro = new ReportePlanillaArbitro();
            reportePlanillaArbitro.Show();
        }

        private void Reportes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Menucontrol menucontrol = new Menucontrol();
            menucontrol.Show();
        }

        private void btnDos_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReporteEstadisticasEquipo reporteEstadisticasEquipo = new ReporteEstadisticasEquipo();
            reporteEstadisticasEquipo.Show();
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {

        }

        private void btnCuatro_Click(object sender, EventArgs e)
        {

        }

        private void btnOcho_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VISTA_REPORTE_CANCHA_ALQUILERES vista_reporte = new VISTA_REPORTE_CANCHA_ALQUILERES();
            vista_reporte.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VISTA_REPORTE_ARBITRO_VISTA vista_arbitro = new VISTA_REPORTE_ARBITRO_VISTA();
            vista_arbitro.Show();
        }
    }
}
