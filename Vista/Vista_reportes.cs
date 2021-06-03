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
    public partial class Vista_reportes : Form
    {
        public BITACORA_DB bitacora_context = new BITACORA_DB();
        public string nombres_login;
        public string apellidos_login;
        public string dpi_login;
        public string puesto_login;
        public Vista_reportes(string dpi_us, string nombre_us, string apellidos_us, string puesto_trabajo_us)
        {
            InitializeComponent();
            dpi_login = dpi_us;
            nombres_login = nombre_us;
            apellidos_login = apellidos_us;
            puesto_login = puesto_trabajo_us;


            textBox1.Text = nombres_login;
            textBox2.Text = apellidos_login;
            textBox3.Text = dpi_login;
            textBox4.Text = puesto_login;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;

            string accion = "ingresando al sistema reportes";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;
            bitacora_context.Agregar_registro(agregando_registro_bitacoras);


        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //llevando el control de bitacoras de en cada opcion del sistema
            string accion;
            if(textBox4.Text== "Administrador")
            {
                 accion = "REP.Salio de reportes";
                bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
                agregando_registro_bitacoras.nombre = textBox1.Text;
                agregando_registro_bitacoras.apellidos = textBox2.Text;
                agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
                agregando_registro_bitacoras.Acciones_en_sistema = accion;
                bitacora_context.Agregar_registro(agregando_registro_bitacoras);
                this.Dispose();
            }
            else
            {
                accion = "REP.Salio del sistema";
                bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
                agregando_registro_bitacoras.nombre = textBox1.Text;
                agregando_registro_bitacoras.apellidos = textBox2.Text;
                agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
                agregando_registro_bitacoras.Acciones_en_sistema = accion;
                bitacora_context.Agregar_registro(agregando_registro_bitacoras);
                this.Close();
                Login_vista saliravista = new Login_vista();
                saliravista.Show();
            }
            
          
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Text = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label4.Text = textBox2.Text;
        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            //llevando el control de bitacoras de en cada opcion del sistema
            string accion = "REP.estadistica uso canchas ";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;
            bitacora_context.Agregar_registro(agregando_registro_bitacoras);
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            
            tablapos ts = new tablapos();
            ts.Show();
            //llevando el control de bitacoras de en cada opcion del sistema
            string accion = "REP. tabla de posiciones";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;
            bitacora_context.Agregar_registro(agregando_registro_bitacoras);


        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
   
            Tarjetas tt = new Tarjetas();
            tt.Show();
            //llevando el control de bitacoras de en cada opcion del sistema
            string accion = "REP.targetas por quipos";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;
            bitacora_context.Agregar_registro(agregando_registro_bitacoras);
        }

        private void btnSiete_Click(object sender, EventArgs e)
        {
            
            ReportePlanillaArbitro reportePlanillaArbitro = new ReportePlanillaArbitro();
            reportePlanillaArbitro.Show();
            //llevando el control de bitacoras de en cada opcion del sistema
            string accion = "REP.Planilla arbitros";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;
            bitacora_context.Agregar_registro(agregando_registro_bitacoras);
        }

        private void btnDos_Click(object sender, EventArgs e)
        {
       
            ReporteEstadisticasEquipo reporteEstadisticasEquipo = new ReporteEstadisticasEquipo();
            reporteEstadisticasEquipo.Show();
            //llevando el control de bitacoras de en cada opcion del sistema
            string accion = "REP. estadaistica del equipo";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;
            bitacora_context.Agregar_registro(agregando_registro_bitacoras);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            VISTA_REPORTE_CANCHA_ALQUILERES vista_reporte = new VISTA_REPORTE_CANCHA_ALQUILERES();
            vista_reporte.Show();
            //llevando el control de bitacoras de en cada opcion del sistema
            string accion = "REP.Canchas alquileres";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;
            bitacora_context.Agregar_registro(agregando_registro_bitacoras);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VISTA_REPORTE_ARBITRO_VISTA vista_arbitro=new VISTA_REPORTE_ARBITRO_VISTA();
            vista_arbitro.Show();
            //llevando el control de bitacoras de en cada opcion del sistema
            string accion = "REP.arbitros alquileres ";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;
            bitacora_context.Agregar_registro(agregando_registro_bitacoras);

        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            //llevando el control de bitacoras de en cada opcion del sistema
            string accion = "REP.portero menos vencido";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;
            bitacora_context.Agregar_registro(agregando_registro_bitacoras);
        }

        private void btnCuatro_Click(object sender, EventArgs e)
        {
            //llevando el control de bitacoras de en cada opcion del sistema
            string accion = "REP.Goleadores";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;
            bitacora_context.Agregar_registro(agregando_registro_bitacoras);
        }

        private void btnOcho_Click(object sender, EventArgs e)
        {
            //llevando el control de bitacoras de en cada opcion del sistema
            string accion = "REP.Utilidades del negocio ";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;
            bitacora_context.Agregar_registro(agregando_registro_bitacoras);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Vista_reporte_bitacoras_vista vista_reportes_bitacora = new Vista_reporte_bitacoras_vista();
            vista_reportes_bitacora.Show();
            //llevando el control de bitacoras de en cada opcion del sistema
            string accion = "REP.bitacora de acceso";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;
            bitacora_context.Agregar_registro(agregando_registro_bitacoras);
        }

        private void Vista_reportes_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            vista_reportes_disponibilidad_vistass vista_reportes_bitacora = new vista_reportes_disponibilidad_vistass();
            vista_reportes_bitacora.Show();
            //llevando el control de bitacoras de en cada opcion del sistema
            string accion = "REP.Disponibilidad de canchas";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;
            bitacora_context.Agregar_registro(agregando_registro_bitacoras);
        }
    }
}
