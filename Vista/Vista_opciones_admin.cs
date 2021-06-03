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
    public partial class Vista_opciones_admin : Form
    {
        public string nombres_login;
        public string apellidos_login;
        public string dpi_login;
       public string puesto_login;
        public BITACORA_DB registro_bitacora_contex = new BITACORA_DB();

        public Vista_opciones_admin(string dpi_us,string nombre_us,string apellidos_us,string puesto_trabajo_us)
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

            string accion = "ingresando al sistema";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;

            registro_bitacora_contex.Agregar_registro(agregando_registro_bitacoras);


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Vista_opciones_admin_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Crud_usuarios usuarios = new Crud_usuarios();
            usuarios.Show();
            string accion = "Mantenimiento usuarios";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;

            registro_bitacora_contex.Agregar_registro(agregando_registro_bitacoras);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menucontrol menu = new Menucontrol();
            menu.Show();
            string accion = "Control de todo el sistema";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;

            registro_bitacora_contex.Agregar_registro(agregando_registro_bitacoras);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            vista_parametro_de_empresa parametros_empresa_vista = new vista_parametro_de_empresa();
            parametros_empresa_vista.Show();
            string accion = "adm. Parametros empresa";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema =accion;

            registro_bitacora_contex.Agregar_registro(agregando_registro_bitacoras);





        }

        private void button4_Click(object sender, EventArgs e)
        {
            VISTA_ALQUILER alquiletres = new VISTA_ALQUILER();
            alquiletres.Show();
            string accion = "Mant. alquiler canchas";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;

            registro_bitacora_contex.Agregar_registro(agregando_registro_bitacoras);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Text = textBox1.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //llevando el control de bitacoras de en cada opcion del sistema
            
            
            string accion = "salio del sistema";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;
            registro_bitacora_contex.Agregar_registro(agregando_registro_bitacoras);


            
            this.Close();
            Login_vista saliravista = new Login_vista();
            saliravista.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label4.Text = textBox2.Text;
        }

        private void btnTorneo_Click(object sender, EventArgs e)
        {
           
            TorneoCRUD t = new TorneoCRUD();
            t.Show();
            string accion = "Mantenimiento Torneo";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;

            registro_bitacora_contex.Agregar_registro(agregando_registro_bitacoras);


        }

        private void btnCanchas_Click(object sender, EventArgs e)
        {
            
            Canchas c = new Canchas();
            c.Show();
            string accion = "Mantenimiento canchas";
            bitacora_modelo agregando_registro_bitacoras = new bitacora_modelo();
            agregando_registro_bitacoras.nombre = textBox1.Text;
            agregando_registro_bitacoras.apellidos = textBox2.Text;
            agregando_registro_bitacoras.Puesto_usuario = textBox4.Text;
            agregando_registro_bitacoras.Acciones_en_sistema = accion;

            registro_bitacora_contex.Agregar_registro(agregando_registro_bitacoras);




        }

        private void button6_Click(object sender, EventArgs e)
        {

            Vista_reportes vista_operador = new Vista_reportes(dpi_login, nombres_login, apellidos_login, puesto_login);
            vista_operador.Show();
        }
    }
}
