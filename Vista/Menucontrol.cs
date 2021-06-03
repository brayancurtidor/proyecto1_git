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
    public partial class Menucontrol : Form
    {
        public Menucontrol()
        {
            InitializeComponent();
        }

        private void btnTorneo_Click(object sender, EventArgs e)
        {
            this.Hide();
            TorneoCRUD t = new TorneoCRUD();
            t.Show();
        }

        private void btnEquipo_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewEquipo vq = new ViewEquipo();
            vq.Show();
        }

        private void btnEntrenador_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewEntrenador ve = new ViewEntrenador();
            ve.Show();
        }

        private void btnArbitros_Click(object sender, EventArgs e)
        {
            this.Hide();
            VistaArbitro vA = new VistaArbitro();
            vA.Show();
        }

        private void btnAmonestaciones_Click(object sender, EventArgs e)
        {
            this.Hide();
            Amonestacion ar = new Amonestacion();
            ar.Show();
        }

        private void btnPagoAmonestaciones_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewPagoAmonestacion viewPagoAmonestacion = new ViewPagoAmonestacion();
            viewPagoAmonestacion.Show();
        }

        private void btnJugadores_Click(object sender, EventArgs e)
        {
            this.Hide();
            jugadorescrud jrs = new jugadorescrud();
            jrs.Show();
        }

        private void btnCanchas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Canchas c = new Canchas();
            c.Show();  
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Reportes nuevos_reportes= new Reportes();
            nuevos_reportes.Show();
        }
    }
}
