using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Administracion_Torneos.Modelo;
using Administracion_Torneos.BD;

namespace Administracion_Torneos.Vista
{
    public partial class REPORTESS_ARBITROSS : Form
    {
        public arbitroDB arbitrosContext = new arbitroDB();
        public Arbitro arbitroSeleccionado = new Arbitro();
        public REPORTESS_ARBITROSS()
        {
            InitializeComponent();
            mostrar();
        }
        public void mostrar()
        {
            listArbitros.DataSource = arbitrosContext.manejoArbitros();
        }

        private void REPORTESS_ARBITROSS_Load(object sender, EventArgs e)
        {

        }
    }
}
