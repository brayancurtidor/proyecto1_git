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
    public partial class vista_parametro_de_empresa : Form
    {
        public PARAMETROS_EMPRESA_DB usuarios_context = new PARAMETROS_EMPRESA_DB();
        public PARAMETROS_EMPRESA_MODELO jugador_seleccionado = new PARAMETROS_EMPRESA_MODELO();

        public vista_parametro_de_empresa()
        {
            InitializeComponent();
            mostrar_parametros_datagrid();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowDrop = false;
            dataGridView1.AllowUserToDeleteRows = false;
        }
        public void mostrar_parametros_datagrid()
        {

            dataGridView1.DataSource = usuarios_context.busqueda_parametros_empresa_total();
        }
        private int? Get_id_empresa_seleccionado()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }

            catch
            {
                
                return null;
            }

        }








        private void vista_parametro_de_empresa_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            MessageBoxButtons eliminar = MessageBoxButtons.YesNo;
            DialogResult dr2 = MessageBox.Show("¿SEGURO DE QUE DESEA actualizar informacion de la empresa?", "ALERTA", eliminar, MessageBoxIcon.Warning);
            if (dr2 == DialogResult.Yes)
            {
               
                //llamado al dpi del jugador a travez del datagrid
                int? id_empresa = Get_id_empresa_seleccionado();

                PARAMETROS_EMPRESA_MODELO parametros_edita_v = usuarios_context.Get_paramtros_A_EDITAR(id_empresa);

                textBox1.Text = parametros_edita_v.nombre_empresa.ToString();
                textBox2.Text = parametros_edita_v.inicio_lunes_viernes.ToString();
                textBox3.Text = parametros_edita_v.fin_lunes_viernes.ToString();
                textBox4.Text = parametros_edita_v.inicio_jornada_sabado.ToString();
                textBox5.Text = parametros_edita_v.fin_jornada_sabado.ToString();
                textBox6.Text = parametros_edita_v.inicio_jornada_domingos.ToString();
                textBox7.Text = parametros_edita_v.fin_jornada_domingos.ToString();
            ;
            }
            else if (dr2 == DialogResult.No)
            {

                dataGridView1.Enabled = true;

                MessageBox.Show("Actualizacion cancelada exitosamente");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (
                        textBox1.Text == "" ||
                        textBox2.Text == "" ||
                        textBox3.Text == "" ||
                        textBox4.Text == "" ||
                        textBox5.Text == "" ||
                        textBox6.Text == "" ||
                        textBox7.Text == ""
                     
                        )
            {
                MessageBox.Show("valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else
            {


                int?  id_empresa = Get_id_empresa_seleccionado();
                string nombre_editar = textBox1.Text;
                TimeSpan inicio_lunes_vierens =TimeSpan.Parse(textBox2.Text);
                TimeSpan fin_lunes_vierenes = TimeSpan.Parse(textBox3.Text);
                TimeSpan inicio_sabados = TimeSpan.Parse(textBox4.Text);
                TimeSpan fin_sabados = TimeSpan.Parse(textBox5.Text);
                TimeSpan inicio_domingo = TimeSpan.Parse(textBox6.Text);
                TimeSpan fin_domingo = TimeSpan.Parse(textBox7.Text);
            


                usuarios_context.Actualizar_parametros(id_empresa, nombre_editar, inicio_lunes_vierens, fin_lunes_vierenes, inicio_sabados, fin_sabados, inicio_domingo, fin_domingo);
                mostrar_parametros_datagrid();
                dataGridView1.Enabled = true;
               
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
              
            }
           





        }
    }
}
