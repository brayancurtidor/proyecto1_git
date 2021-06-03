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
    public partial class Vista_operador : Form
    {
        public BITACORA_DB registro_bitacora_context = new BITACORA_DB();
        public string nombres_login;
        public string apellidos_login;
        public string dpi_login;
        public string puesto_login;
        public Vista_operador(string dpi_us, string nombre_us, string apellidos_us, string puesto_trabajo_us)
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
            string accion = "ingresando al sistema operador";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;

            registro_bitacora_context.Agregar_registro(agregando_registro_bitacoras);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menucontrol menuoperador = new Menucontrol();
            menuoperador.Show();
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Vista_operador_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //llevando el control de bitacoras de en cada opcion del sistema
            string accion = "salio del sistema";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;
            registro_bitacora_context.Agregar_registro(agregando_registro_bitacoras);

            this.Close();
            Login_vista saliravista = new Login_vista();
            saliravista.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Text = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label4.Text = textBox2.Text;
        }

        private void btnEquipo_Click(object sender, EventArgs e)
        {
            
            ViewEquipo vq = new ViewEquipo();
            vq.Show();
            //llevando el control de bitacoras de en cada opcion del sistema
            string accion = "Mantentenimiento equipo";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;

            registro_bitacora_context.Agregar_registro(agregando_registro_bitacoras);


        }

        private void btnArbitros_Click(object sender, EventArgs e)
        {
            
            VistaArbitro vA = new VistaArbitro();
            vA.Show();
            //llevando el control de bitacoras de en cada opcion del sistema
            string accion = "Mantentenimiento arbitros";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;
            registro_bitacora_context.Agregar_registro(agregando_registro_bitacoras);



        }

        private void btnJugadores_Click(object sender, EventArgs e)
        {
           
            jugadorescrud jrs = new jugadorescrud();
            jrs.Show();


            //llevando el control de bitacoras de en cada opcion del sistema
            string accion = "Mantentenimiento Jugadores";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;

            registro_bitacora_context.Agregar_registro(agregando_registro_bitacoras);
        }

        private void btnEntrenador_Click(object sender, EventArgs e)
        {
            
            ViewEntrenador ve = new ViewEntrenador();
            ve.Show();
            //llevando el control de bitacoras de en cada opcion del sistema
            string accion = "Mantentenimiento entrenador";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;

            registro_bitacora_context.Agregar_registro(agregando_registro_bitacoras);

        }

        private void btnAmonestaciones_Click(object sender, EventArgs e)
        {
            
            Amonestacion ar = new Amonestacion();
            ar.Show();
            //llevando el control de bitacoras de en cada opcion del sistema
            string accion = "Mantentenimiento amonestaciones";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;

            registro_bitacora_context.Agregar_registro(agregando_registro_bitacoras);

        }

        private void btnPagoAmonestaciones_Click(object sender, EventArgs e)
        {
            
            ViewPagoAmonestacion viewPagoAmonestacion = new ViewPagoAmonestacion();
            viewPagoAmonestacion.Show();
            //llevando el control de bitacoras de en cada opcion del sistema
            string accion = "Mantentenimiento pago targetas";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;
            registro_bitacora_context.Agregar_registro(agregando_registro_bitacoras);



        }
    }
}
