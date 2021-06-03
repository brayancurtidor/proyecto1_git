using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Administracion_Torneos.BD;
using Administracion_Torneos.Modelo;

namespace Administracion_Torneos.Vista
{
    public partial class VISTA_REPORTE_ARBITRO_VISTA : Form

    {
        public REPORTE_ARBITROS_ALQUILER_DB reporte_context = new REPORTE_ARBITROS_ALQUILER_DB();
        public VISTA_REPORTE_ARBITRO_VISTA()
        {
            InitializeComponent();

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowDrop = false;
            dataGridView1.AllowUserToDeleteRows = false;
        }
        public void mostrar_reporte_datagrid()
        {

            dataGridView1.DataSource = reporte_context.reporte_arbitros_alquileres(Convert.ToDateTime(dateTimePicker1.Value), Convert.ToDateTime(dateTimePicker2.Value));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mostrar_reporte_datagrid();
        }
    }
}
