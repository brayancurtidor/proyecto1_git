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
using System.Data.SqlClient;

namespace Administracion_Torneos.Vista
{
    public partial class vista_reportes_disponibilidad_vistass : Form
    {
        Reporte_disponibilidad_de_canchas_final disponibilidadCanchaDB = new Reporte_disponibilidad_de_canchas_final();
 
   

        public vista_reportes_disponibilidad_vistass()
        {
            InitializeComponent();

            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowDrop = false;
            dataGridView2.AllowUserToDeleteRows = false;

            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowDrop = false;
            dataGridView3.AllowUserToDeleteRows = false;



            disponibilidadCanchaDB.GetCanchas(comboBox1);
            //estas variables ayudan a ver si existe informacion en la base de datos
            string[] datos = disponibilidadCanchaDB.captar_info_horas_jornadas();
            if (datos == null)
            {
                MessageBox.Show("Error...\nNo se ha definido la hora de inicio de jornada\ny tampoco la hora de finalizacion de jornadas", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txt_inicio_jornada.Text = datos[0];
                txt_fin_jornada.Text = datos[1];
                txt_inicio_sabado.Text = datos[2];
                txt_fin_sabado.Text = datos[3];
                txt_inicio_domingos.Text = datos[4];
                txt_fin_domingos.Text = datos[5];

            }



        }
     
        
 
   
        
        
        
        
        
        
        
        
        
        
        
        
        private void vista_reportes_disponibilidad_vistass_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mostrar_reporte_datagrid();
            mostrar_reporte_datagrid2();
            int max = 0;
            int min = 100;
           
            //int dias = dateTimePicker2.Value.Day - dateTimePicker1.Value.Day;

            /*   for (int i = 0; i <= dias; i++) {
                   dataGridView1.Columns.Add("", Convert.ToString(i + 1));
               }*/

            //for (DateTime inicio = dateTimePicker1.Value.Date; inicio <= dateTimePicker2.Value.Date; inicio = inicio.AddDays(1))
            //{
            //    dataGridView1.Columns.Add("Disponibilidad", Convert.ToString(inicio.Day + "/" + inicio.Month + "/" + inicio.Year));

            //    switch (inicio.DayOfWeek.ToString())
            //    {
            //        case "Monday":
            //            if (max < Convert.ToInt32(txt_fin_jornada.Text.Substring(0, 2)))
            //            {
            //                max = Convert.ToInt32(txt_fin_jornada.Text.Substring(0, 2));
            //            }
            //            if (min > Convert.ToInt32(txt_inicio_jornada.Text.Substring(0, 2)))
            //            {
            //                min = Convert.ToInt32(txt_inicio_jornada.Text.Substring(0, 2));

            //            }
            //            break;
            //        case "Tuesday":
            //            if (max < Convert.ToInt32(txt_fin_jornada.Text.Substring(0, 2)))
            //            {
            //                max = Convert.ToInt32(txt_fin_jornada.Text.Substring(0, 2));
            //            }
            //            if (min > Convert.ToInt32(txt_inicio_jornada.Text.Substring(0, 2)))
            //            {
            //                min = Convert.ToInt32(txt_inicio_jornada.Text.Substring(0, 2));

            //            }
            //            break;
            //        case "Wednesday":
            //            if (max < Convert.ToInt32(txt_fin_jornada.Text.Substring(0, 2)))
            //            {
            //                max = Convert.ToInt32(txt_fin_jornada.Text.Substring(0, 2));
            //            }
            //            if (min > Convert.ToInt32(txt_inicio_jornada.Text.Substring(0, 2)))
            //            {
            //                min = Convert.ToInt32(txt_inicio_jornada.Text.Substring(0, 2));

            //            }
            //            break;

            //        case "Thursday":
            //            if (max < Convert.ToInt32(txt_fin_jornada.Text.Substring(0, 2)))
            //            {
            //                max = Convert.ToInt32(txt_fin_jornada.Text.Substring(0, 2));
            //            }
            //            if (min > Convert.ToInt32(txt_inicio_jornada.Text.Substring(0, 2)))
            //            {
            //                min = Convert.ToInt32(txt_inicio_jornada.Text.Substring(0, 2));

            //            }
            //            break;

            //        case "Friday":
            //            if (max < Convert.ToInt32(txt_fin_jornada.Text.Substring(0, 2)))
            //            {
            //                max = Convert.ToInt32(txt_fin_jornada.Text.Substring(0, 2));
            //            }
            //            if (min > Convert.ToInt32(txt_inicio_jornada.Text.Substring(0, 2)))
            //            {
            //                min = Convert.ToInt32(txt_inicio_jornada.Text.Substring(0, 2));

            //            }
            //            break;

            //        case "Saturday":
            //            if (max < Convert.ToInt32(txt_fin_sabado.Text.Substring(0, 2)))
            //            {
            //                max = Convert.ToInt32(txt_fin_sabado.Text.Substring(0, 2));
            //            }
            //            if (min > Convert.ToInt32(txt_inicio_sabado.Text.Substring(0, 2)))
            //            {
            //                min = Convert.ToInt32(txt_inicio_sabado.Text.Substring(0, 2));

            //            }
            //            break;

            //        case "Sunday":
            //            if (max < Convert.ToInt32(txt_fin_domingos.Text.Substring(0, 2)))
            //            {
            //                max = Convert.ToInt32(txt_fin_domingos.Text.Substring(0, 2));
            //            }
            //            if (min > Convert.ToInt32(txt_inicio_domingos.Text.Substring(0, 2)))
            //            {
            //                min = Convert.ToInt32(txt_inicio_domingos.Text.Substring(0, 2));

            //            }
            //            break;

                     

            //    }

            
            //    int x = 0;

             

            //    for (int i = min; i < max; i++)
            //    {
            //        int inicio1;
            //        int fin1;
            //        inicio1 = i;
            //        fin1 = (i + 1);
                    
                   
            //        dataGridView1.Rows.Add("");
            //        dataGridView1.Rows[x].HeaderCell.Value = Convert.ToString(i) + "-" + Convert.ToString(i + 1);
            //        TimeSpan inicio2 = TimeSpan.Parse(Convert.ToString(inicio1));
            //        MessageBox.Show(inicio2.ToString());
                    
                  

            //        x = x + 1;
            //    }



            //}

         
        }

        public void mostrar_reporte_datagrid()
        {
            DateTime fecha1;
            DateTime fecha2;
            fecha1 = Convert.ToDateTime(dateTimePicker1.Value);
            fecha2 = Convert.ToDateTime(dateTimePicker2.Value);
            dataGridView2.DataSource = disponibilidadCanchaDB.reporte_canchas_alquileres_torneo(fecha1, fecha2,comboBox1.Text);
        }
        public void mostrar_reporte_datagrid2()
        {
            DateTime fecha1;
            DateTime fecha2;
            fecha1 = Convert.ToDateTime(dateTimePicker1.Value);
            fecha2 = Convert.ToDateTime(dateTimePicker2.Value);
            dataGridView3.DataSource = disponibilidadCanchaDB.reporte_canchas_alquileres_alquileres(fecha1, fecha2, comboBox1.Text);
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
