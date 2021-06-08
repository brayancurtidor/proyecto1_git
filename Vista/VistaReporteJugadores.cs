using Administracion_Torneos.BD;
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
    public partial class VistaReporteJugadores : Form
    {
        jugadorBD j = new jugadorBD();
        public VistaReporteJugadores()
        {
            InitializeComponent();
            dataGridView1.DataSource = j.Getjugadores();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void VistaReporteJugadores_Load(object sender, EventArgs e)
        {

        }
    }
}
