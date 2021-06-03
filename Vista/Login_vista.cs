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
    public partial class Login_vista : Form
    {
       
         public string nombres;
        public  string apellidos;
        public Login_DB usuarios_all_basedatos = new Login_DB();
        
        public Login_vista()
        {
            InitializeComponent();
            usuarios_all_basedatos.usuario_all(comboBox1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text=="Seleccione una opcion"||
                comboBox2.Text== "Seleccione una opcion"||
                textBox1.Text==""

                )
            {
                MessageBox.Show("Campos vacios");

            }
            else
            {

             
             
                    usuarios_all_basedatos.Login_usuarios(comboBox1.Text, comboBox2.Text, textBox1.Text);
                if(usuarios_all_basedatos.bandera_acceso==1)
                {
                   this.Hide();
                }
                
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_vista_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex>=0)
            {
                usuarios_all_basedatos.usuario_all_apellios(comboBox2, comboBox1.Text);
                
                nombres = comboBox2.Text;
            }
        }
    }
}
