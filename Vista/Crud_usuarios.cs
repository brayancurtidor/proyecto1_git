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
    public partial class Crud_usuarios : Form
    {
        //creando instaciaas para crear usar sus metodos o variables
        public USUARIOS_DB usuarios_context = new USUARIOS_DB();
        public USUARIO_MODELO jugador_seleccionado = new USUARIO_MODELO();
        public int accion = 1;

        public Crud_usuarios()
        {
            InitializeComponent();

            mostrar_usuarios_datagrid();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowDrop = false;
            dataGridView1.AllowUserToDeleteRows = false;

        }
        public void mostrar_usuarios_datagrid()
        {

            dataGridView1.DataSource = usuarios_context.busqueda_usuarios_total();
        }
        private long? Get_dpi_usuario_seleccionado()
        {
            try
            {
                return long.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }

            catch
            {
                return null;
            }

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Crud_usuarios_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (accion)
            {
                case 1:
                    //creandi istancia con variable de para poder acceder al agregar un nuevo cliene o un nuevo query
                    USUARIO_MODELO agregando_usuario = new USUARIO_MODELO();
                    //validacion para que no existan valores nullos
                    if (txt_dpi.Text==""||
                        txt_nombres.Text==""||
                        txt_apellidos.Text==""||
                        txt_telefono.Text==""||
                        txt_direccion.Text==""||
                        txt_correo.Text==""||
                        comboBox1.Text=="Seleccione una opcion"||
                        txt_contra.Text=="" ||
                        cmb_activo.Text== "Seleccione una opcion"||
                        txt_rol_usuario.Text==""
                        )

                    {
                        MessageBox.Show("valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                       
                            //agregando infirmacion a la base de datos
                            agregando_usuario.dpi_usuario = Convert.ToInt64(txt_dpi.Text);
                            agregando_usuario.nombre_usuario = txt_nombres.Text;
                            agregando_usuario.apellidos = txt_apellidos.Text;
                            agregando_usuario.telefono = txt_telefono.Text;
                            agregando_usuario.direccion = txt_direccion.Text;
                            agregando_usuario.correo = txt_correo.Text;
                            agregando_usuario.puesto_usuario = comboBox1.Text;
                            agregando_usuario.rol_usuario = txt_rol_usuario.Text;
                            agregando_usuario.contraeña = txt_contra.Text;
                            agregando_usuario.activo = cmb_activo.Text;
                        usuarios_context.Agregar_usuarios(agregando_usuario);
                        mostrar_usuarios_datagrid();
                        txt_dpi.Text = "";
                        txt_rol_usuario.Text = "";
                        txt_nombres.Text = "";
                        txt_apellidos.Text = "";
                        txt_telefono.Text = "";
                        txt_direccion.Text = "";
                        txt_correo.Text = "";
                        comboBox1.Text = "Seleccione una opcion";
                        txt_contra.Text = "";
                        cmb_activo.Text = "Seleccione una opcion";

                    }
                  

                    break;
                case 2:

                    if (
                        txt_dpi.Text == "" ||
                        txt_nombres.Text == "" ||
                        txt_apellidos.Text == "" ||
                        txt_telefono.Text == "" ||
                        txt_direccion.Text == "" ||
                        txt_correo.Text == "" ||
                        comboBox1.Text == "Seleccione una opcion" ||
                        txt_contra.Text == "" ||
                        cmb_activo.Text == "Seleccione una opcion"||
                        txt_rol_usuario.Text == ""
                        )
                    {
                        MessageBox.Show("valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    }
                    else
                    {
                        
                        
                            long? dpi_jugador_confirmar = Get_dpi_usuario_seleccionado();
                            string nombre_editar = txt_nombres.Text;
                            string apellido_editar = txt_apellidos.Text;
                            string  telefonos = txt_telefono.Text;
                            string direccion_actualizar = txt_direccion.Text;
                            string correo = txt_correo.Text;
                            string puestos = comboBox1.Text;
                        string rol_usuariuo = txt_rol_usuario.Text;
                            string contraseña = txt_contra.Text;
                            string activo = cmb_activo.Text;


                        usuarios_context.Actualizar_usuarios(dpi_jugador_confirmar, nombre_editar, apellido_editar, telefonos, direccion_actualizar, correo, puestos, rol_usuariuo, contraseña, activo);
                            mostrar_usuarios_datagrid();
                            dataGridView1.Enabled = true;
                            accion = 1;


                        txt_dpi.Text = "";
                        txt_rol_usuario.Text = "";
                        txt_nombres.Text = "";
                        txt_apellidos.Text = "";
                        txt_telefono.Text = "";
                        txt_direccion.Text = "";
                        txt_correo.Text = "";
                        comboBox1.Text = "Seleccione una opcion";
                        txt_contra.Text = "";
                        cmb_activo.Text = "Seleccione una opcion";
                    }
                    break;
            }
        }

        private void txt_nombres_TextChanged(object sender, EventArgs e)
        {

        }
        private void txt_nombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion de solo nombres en el texbox
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo Letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_apellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion de solo nombres en el texbox
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo Letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Agregar solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            
            dataGridView1.Enabled = false;
            MessageBoxButtons eliminar = MessageBoxButtons.YesNo;
            DialogResult dr2 = MessageBox.Show("¿SEGURO DE QUE DESEA actualizar informacion del  usuario?", "ALERTA", eliminar, MessageBoxIcon.Warning);
            if (dr2 == DialogResult.Yes)
            {
                accion = 2;
                //llamado al dpi del jugador a travez del datagrid
                long? dpi_jugador = Get_dpi_usuario_seleccionado();

                USUARIO_MODELO usuario_edita_v = usuarios_context.Get_usuario_A_EDITAR(dpi_jugador);

                txt_dpi.Text = usuario_edita_v.dpi_usuario.ToString();
                txt_nombres.Text = usuario_edita_v.nombre_usuario;
                txt_apellidos.Text = usuario_edita_v.apellidos;
                txt_telefono.Text =usuario_edita_v.telefono;
                txt_direccion.Text = usuario_edita_v.direccion;
                txt_correo.Text = usuario_edita_v.correo;
                comboBox1.Text = usuario_edita_v.puesto_usuario;
                txt_rol_usuario.Text = usuario_edita_v.rol_usuario;
                txt_contra.Text = usuario_edita_v.contraeña;
                cmb_activo.Text = usuario_edita_v.activo;
            }
            else if (dr2 == DialogResult.No)
            {
                
                dataGridView1.Enabled = true;
               
                MessageBox.Show("Actualizacion cancelada exitosamente");
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {

            dataGridView1.Enabled = false;
            MessageBoxButtons eliminar = MessageBoxButtons.YesNo;
            DialogResult dr2 = MessageBox.Show("¿SEGURO DE QUE DESEA DESACTIVAR AL USUARIO?", "ALERTA", eliminar, MessageBoxIcon.Warning);
            if (dr2 == DialogResult.Yes)
            {
                accion = 2;
                //llamado al dpi del jugador a travez del datagrid
                long? dpi_jugador = Get_dpi_usuario_seleccionado();

                USUARIO_MODELO usuario_edita_v = usuarios_context.Get_usuario_A_EDITAR(dpi_jugador);

               
                usuarios_context.DESACTIVAR_usuarios(dpi_jugador);
                mostrar_usuarios_datagrid();
                dataGridView1.Enabled = true;

            }
            else if (dr2 == DialogResult.No)
            {

                dataGridView1.Enabled = true;

                MessageBox.Show("Actualizacion cancelada exitosamente");
            }
        }

        private void txt_dpi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_dpi_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion para que se ingrese solo numeros
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Agregar solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }
    }
}
