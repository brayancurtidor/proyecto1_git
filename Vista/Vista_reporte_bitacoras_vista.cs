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
    public partial class Vista_reporte_bitacoras_vista : Form
    {
        public Login_DB usuarios_all_basedatos = new Login_DB();
        public BITACORA_DB reporte_context = new BITACORA_DB();


        public Vista_reporte_bitacoras_vista()
        {
            InitializeComponent();

            usuarios_all_basedatos.usuario_all(comboBox2);

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowDrop = false;
            dataGridView1.AllowUserToDeleteRows = false;

            comboBox2.Visible = false;
            comboBox3.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label2.Visible = false;
            label3.Visible = false;

        }
        public void mostrar_reporte_fechas_datagrid()
        {
            DateTime inicio;
            inicio = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime fin;
            fin = Convert.ToDateTime(dateTimePicker2.Text);
            if(inicio == fin)
            {
                dataGridView1.DataSource = reporte_context.reporte_bitacora_fechas(inicio, inicio);

            }
            else
            {
                dataGridView1.DataSource = reporte_context.reporte_bitacora_fechas(inicio, fin);
            }
            
        }
        public void mostrar_reporte_por_usuario_datagrid()
        {

            dataGridView1.DataSource = reporte_context.reporte_bitacora_nombre_apellido(comboBox2.Text,comboBox3.Text);
        }
        private void Vista_reporte_bitacoras_vista_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==1)
            {
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
            }
            
            else if (comboBox1.SelectedIndex == 0)
            {
                comboBox2.Visible = false;
                comboBox3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;

                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                label2.Visible = true;
                label3.Visible = true;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text=="")
            {

                MessageBox.Show("Seleccione un tipo de busqueda","ALERTA",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

            }
            else
            {
                if(comboBox1.SelectedIndex==1)
                {
                    if(comboBox2.Text==""|| comboBox3.Text=="")
                    {
                        MessageBox.Show("Seleccione un nombre y un apellido", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        mostrar_reporte_por_usuario_datagrid();
                        if (dataGridView1.Rows.Count == 0)
                        {
                            MessageBox.Show("Este usuario aun no ha echo ninguna accion dentro del sistema");
                          
                        }

                      


                    }


                }
                else if(comboBox1.SelectedIndex == 0)
                {
                    mostrar_reporte_fechas_datagrid();
                    if (dataGridView1.Rows.Count == 0)
                    {
                        MessageBox.Show("En este rango de fechas  no se realizaron acciones dentro del sistema");

                    }

                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex >= 0)
            {
                usuarios_all_basedatos.usuario_all_apellios(comboBox3, comboBox2.Text);
               
            }
        }
    }
}
