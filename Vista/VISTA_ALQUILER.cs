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
    public partial class VISTA_ALQUILER : Form
    {
        public alquile_DB alquileres_context = new alquile_DB();

        Alquileres combo = new Alquileres();
        alquile_DB combo1 = new alquile_DB();
        alquile_DB combo2 = new alquile_DB();
        public int accion = 1;

        public string dias;
        public DateTime fechaaaaa;
        public TimeSpan inico;
        public TimeSpan fin;
        public VISTA_ALQUILER()
        {
            InitializeComponent();
            mostrar_alquileres_datagrid();
            txt_dia_alquiler.Visible = false;
            txt_id_arbitros.Visible = false;
            txt_pago_arbitro.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            comboBox4.Visible = false;
            txt_alquiler_hora_inicio.Visible = false;
            txt_alquiler_hora_final.Visible = false;
            txt_inicio_jornada.Enabled = false;
            txt_fin_jornada.Enabled = false;
            txt_inicio_sabado.Enabled = false;
            txt_fin_sabado.Enabled = false;
            txt_inicio_domingos.Enabled = false;
            txt_fin_domingos.Enabled = false;
            txt_precio_canchas.Enabled = false;
            txt_pago_canchas.Enabled = false;
            txt_precio_arbitro_alquiler.Enabled = false;
            txt_cantidad_horas.Enabled = false;
            txt_id_canchas.Visible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowDrop = false;
            dataGridView1.AllowUserToDeleteRows = false;

            //estas variables ayudan a ver si existe informacion en la base de datos
            string[] datos = alquileres_context.captar_info_horas_jornadas();
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
        public void mostrar_alquileres_datagrid()
        {

            dataGridView1.DataSource =alquileres_context.busqueda_alquileres_total();
        }
        private int? Get_dpi_alquiler_seleccionado()
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



        private void VISTA_ALQUILER_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Alquileres agregando_jugador = new Alquileres();
            TimeSpan validacion_hora_inicio;
            TimeSpan validacion_hora_final;


            TimeSpan hora_inicio_jornada;
            TimeSpan hora_final_jornada;
            TimeSpan hora_inicio_sabados;
            TimeSpan hora_final_sabados;
            TimeSpan hora_inicio_domingos;
            TimeSpan hora_fin_domingos;
            hora_inicio_domingos = TimeSpan.Parse(txt_inicio_domingos.Text);
            hora_fin_domingos = TimeSpan.Parse(txt_fin_domingos.Text);

            hora_inicio_sabados = TimeSpan.Parse(txt_inicio_sabado.Text);
            hora_final_sabados = TimeSpan.Parse(txt_fin_sabado.Text);


            hora_inicio_jornada = TimeSpan.Parse(txt_inicio_jornada.Text);
            hora_final_jornada = TimeSpan.Parse(txt_fin_jornada.Text);
            switch (accion)
            {
                case 1:

                    if (txt_alquiler_hora_final.Text == "" || txt_alquiler_hora_inicio.Text == "" || txt_dia_alquiler.Text == "" ||
               txt_dpi_cli.Text == "" || txt_nombre_cli.Text == "" || txt_apellido_clie.Text == "" || txt_telefono_cli.Text == "" || txt_correo_cli.Text == "" ||
               txt_id_canchas.Text == "" || txt_precio_canchas.Text == "" || txt_pago_canchas.Text == "" || cmb_opcion_arbitros.Text == "Seleccione una opcion"
               )
                    {
                        MessageBox.Show("No formulario invalido, hay campos vacios", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else if (txt_alquiler_hora_inicio.Text == txt_alquiler_hora_final.Text)
                    {
                        MessageBox.Show("Rango de horas no permitida, debe almenos alquilar una cancha por una hora", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (Convert.ToInt32(txt_cantidad_horas.Text) < 0)
                    {
                        MessageBox.Show("Las horas de inicio reservacion debe ser menor que las horas finales", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        validacion_hora_inicio = TimeSpan.Parse(txt_alquiler_hora_inicio.Text);


                        validacion_hora_final = TimeSpan.Parse(txt_alquiler_hora_final.Text);



                        if (txt_dia_alquiler.Text == "Monday" || txt_dia_alquiler.Text == "Tuesday" || txt_dia_alquiler.Text == "Wednesday" || txt_dia_alquiler.Text == "Thursday" || txt_dia_alquiler.Text == "Friday")
                        {
                            if (hora_inicio_jornada > validacion_hora_inicio || hora_final_jornada < validacion_hora_final)

                            {
                                MessageBox.Show("Las canchas no se puden alquilar  de Lunes a Viernes \n Abrimos:  " + txt_inicio_jornada.Text + "   Cerramos: " + txt_fin_jornada.Text, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {


                                MessageBox.Show("Bienvenido lunes a viernes");

                                //MessageBox.Show(dias);
                                //agregando infirmacion a la base de datos
                                agregando_jugador.dpi_cliente = Convert.ToInt64(txt_dpi_cli.Text);
                                agregando_jugador.nombre_cliente = txt_nombre_cli.Text;
                                agregando_jugador.apellido_cliente = txt_apellido_clie.Text;
                                agregando_jugador.teleefono_clinete = txt_telefono_cli.Text;
                                agregando_jugador.correo_cliente = txt_correo_cli.Text;
                                agregando_jugador.id_cancha = Convert.ToInt32(txt_id_canchas.Text);
                                agregando_jugador.id_arbitro = Convert.ToInt32(txt_id_arbitros.Text);
                                agregando_jugador.fecha_reservacion = Convert.ToDateTime(dateTimePicker1.Value);
                                agregando_jugador.hora_inicio_reservacion = TimeSpan.Parse(txt_alquiler_hora_inicio.Text);
                                agregando_jugador.hora_final_reservacion = TimeSpan.Parse(txt_alquiler_hora_final.Text);
                                agregando_jugador.pago_cancha = Convert.ToDecimal(txt_pago_canchas.Text);
                                agregando_jugador.pago_arbitro = Convert.ToDecimal(txt_pago_arbitro.Text);
                                alquileres_context.Agregar_Jugadores(agregando_jugador);
                                mostrar_alquileres_datagrid();

                                txt_alquiler_hora_final.Text = "";
                                txt_alquiler_hora_inicio.Text = "";
                                txt_dia_alquiler.Text = "";
                                txt_dpi_cli.Text = "";
                                txt_nombre_cli.Text = "";
                                txt_apellido_clie.Text = "";
                                txt_telefono_cli.Text = "";
                                txt_correo_cli.Text = "";
                                txt_id_canchas.Text = "";
                                txt_precio_canchas.Text = "";
                                txt_pago_canchas.Text = "";
                                cmb_opcion_arbitros.Text = "Seleccione una opcion";
                                comboBox1.Text = "";
                                txt_id_canchas.Text = "";
                                txt_precio_canchas.Text = "";
                                txt_pago_canchas.Text = "";
                                comboBox4.Text = "";
                                txt_id_arbitros.Text = "";
                                txt_precio_arbitro_alquiler.Text = "";
                                txt_pago_arbitro.Text = "";
                                cmb_opcion_arbitros.Text = "Seleccione una opcion";
                                comboBox2.Text = "";
                                comboBox3.Text = "";
                                comboBox1.Text = "";
                                comboBox4.Text = "";


                            }
                        }
                        else if (txt_dia_alquiler.Text == "Saturday")
                        {


                            if (hora_inicio_sabados > validacion_hora_inicio || hora_final_sabados < validacion_hora_final)

                            {

                                MessageBox.Show("Las canchas no se puden alquilar Sabados ,\n Abrimos:  " + txt_inicio_sabado.Text + "   Cerramos: " + txt_fin_sabado.Text, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {

                                MessageBox.Show("Bienvenido sabados");
                                //MessageBox.Show(dias);
                                //agregando infirmacion a la base de datos
                                agregando_jugador.dpi_cliente = Convert.ToInt64(txt_dpi_cli.Text);
                                agregando_jugador.nombre_cliente = txt_nombre_cli.Text;
                                agregando_jugador.apellido_cliente = txt_apellido_clie.Text;
                                agregando_jugador.teleefono_clinete = txt_telefono_cli.Text;
                                agregando_jugador.correo_cliente = txt_correo_cli.Text;
                                agregando_jugador.id_cancha = Convert.ToInt32(txt_id_canchas.Text);
                                agregando_jugador.id_arbitro = Convert.ToInt32(txt_id_arbitros.Text);
                                agregando_jugador.fecha_reservacion = Convert.ToDateTime(dateTimePicker1.Value);
                                agregando_jugador.hora_inicio_reservacion = TimeSpan.Parse(txt_alquiler_hora_inicio.Text);
                                agregando_jugador.hora_final_reservacion = TimeSpan.Parse(txt_alquiler_hora_final.Text);
                                agregando_jugador.pago_cancha = Convert.ToDecimal(txt_pago_canchas.Text);
                                agregando_jugador.pago_arbitro = Convert.ToDecimal(txt_pago_arbitro.Text);
                                alquileres_context.Agregar_Jugadores(agregando_jugador);
                                mostrar_alquileres_datagrid();
                                txt_alquiler_hora_final.Text = "";
                                txt_alquiler_hora_inicio.Text = "";
                                txt_dia_alquiler.Text = "";
                                txt_dpi_cli.Text = "";
                                txt_nombre_cli.Text = "";
                                txt_apellido_clie.Text = "";
                                txt_telefono_cli.Text = "";
                                txt_correo_cli.Text = "";
                                txt_id_canchas.Text = "";
                                txt_precio_canchas.Text = "";
                                txt_pago_canchas.Text = "";
                                cmb_opcion_arbitros.Text = "Seleccione una opcion";
                                comboBox1.Text = "";
                                txt_id_canchas.Text = "";
                                txt_precio_canchas.Text = "";
                                txt_pago_canchas.Text = "";
                                comboBox4.Text = "";
                                txt_id_arbitros.Text = "";
                                txt_precio_arbitro_alquiler.Text = "";
                                txt_pago_arbitro.Text = "";
                                cmb_opcion_arbitros.Text = "Seleccione una opcion";
                                comboBox2.Text = "";
                                comboBox3.Text = "";
                                comboBox1.Text = "";
                                comboBox4.Text = "";


                            }


                        }
                        else if (txt_dia_alquiler.Text == "Sunday")
                        {




                            if (hora_inicio_domingos > validacion_hora_inicio || hora_fin_domingos < validacion_hora_final)

                            {
                                MessageBox.Show("Las canchas no se puden alquilar Domingos ,\n Abrimos:  " + txt_inicio_domingos.Text + "   Cerramos: " + txt_fin_domingos.Text, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {

                               
                                agregando_jugador.dpi_cliente = Convert.ToInt64(txt_dpi_cli.Text);
                                agregando_jugador.nombre_cliente = txt_nombre_cli.Text;
                                agregando_jugador.apellido_cliente = txt_apellido_clie.Text;
                                agregando_jugador.teleefono_clinete = txt_telefono_cli.Text;
                                agregando_jugador.correo_cliente = txt_correo_cli.Text;
                                agregando_jugador.id_cancha = Convert.ToInt32(txt_id_canchas.Text);
                                agregando_jugador.id_arbitro = Convert.ToInt32(txt_id_arbitros.Text);
                                agregando_jugador.fecha_reservacion = Convert.ToDateTime(dateTimePicker1.Value);
                                agregando_jugador.hora_inicio_reservacion = TimeSpan.Parse(txt_alquiler_hora_inicio.Text);
                                agregando_jugador.hora_final_reservacion = TimeSpan.Parse(txt_alquiler_hora_final.Text);
                                agregando_jugador.pago_cancha = Convert.ToDecimal(txt_pago_canchas.Text);
                                agregando_jugador.pago_arbitro = Convert.ToDecimal(txt_pago_arbitro.Text);
                                alquileres_context.Agregar_Jugadores(agregando_jugador);
                                mostrar_alquileres_datagrid();

                                txt_alquiler_hora_final.Text = "";
                                txt_alquiler_hora_inicio.Text = "";
                                txt_dia_alquiler.Text = "";
                                txt_dpi_cli.Text = "";
                                txt_nombre_cli.Text = "";
                                txt_apellido_clie.Text = "";
                                txt_telefono_cli.Text = "";
                                txt_correo_cli.Text = "";
                                txt_id_canchas.Text = "";
                                txt_precio_canchas.Text = "";
                                txt_pago_canchas.Text = "";
                                cmb_opcion_arbitros.Text = "Seleccione una opcion";
                                comboBox1.Text = "";
                                txt_id_canchas.Text = "";
                                txt_precio_canchas.Text = "";
                                txt_pago_canchas.Text = "";
                                comboBox4.Text = "";
                                txt_id_arbitros.Text = "";
                                txt_precio_arbitro_alquiler.Text = "";
                                txt_pago_arbitro.Text = "";
                                cmb_opcion_arbitros.Text = "Seleccione una opcion";
                                comboBox2.Text = "";
                                comboBox3.Text = "";
                                comboBox1.Text = "";
                                comboBox4.Text = "";
                            }


                        }




                    }

                    break;

                case 2:

                    if (txt_alquiler_hora_final.Text == "" || txt_alquiler_hora_inicio.Text == "" || txt_dia_alquiler.Text == "" ||
               txt_dpi_cli.Text == "" || txt_nombre_cli.Text == "" || txt_apellido_clie.Text == "" || txt_telefono_cli.Text == "" || txt_correo_cli.Text == "" ||
               txt_id_canchas.Text == "" || txt_precio_canchas.Text == "" || txt_pago_canchas.Text == "" || cmb_opcion_arbitros.Text == "Seleccione una opcion"
               )
                    {
                        MessageBox.Show("No formulario invalido, hay campos vacios", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else if (txt_alquiler_hora_inicio.Text == txt_alquiler_hora_final.Text)
                    {
                        MessageBox.Show("Rango de horas no permitida, debe almenos alquilar una cancha por una hora", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (Convert.ToInt32(txt_cantidad_horas.Text) < 0)
                    {
                        MessageBox.Show("Las horas de inicio reservacion debe ser menor que las horas finales", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        validacion_hora_inicio = TimeSpan.Parse(txt_alquiler_hora_inicio.Text);


                        validacion_hora_final = TimeSpan.Parse(txt_alquiler_hora_final.Text);



                        if (txt_dia_alquiler.Text == "Monday" || txt_dia_alquiler.Text == "Tuesday" || txt_dia_alquiler.Text == "Wednesday" || txt_dia_alquiler.Text == "Thursday" || txt_dia_alquiler.Text == "Friday")
                        {
                            if (hora_inicio_jornada > validacion_hora_inicio || hora_final_jornada < validacion_hora_final)

                            {
                                MessageBox.Show("Las canchas no se puden alquilar  de Lunes a Viernes \n Abrimos:  " + txt_inicio_jornada.Text + "   Cerramos: " + txt_fin_jornada.Text, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {


                                int? id_alquiler = Get_dpi_alquiler_seleccionado();
                                long dpi =Convert.ToInt64(txt_dpi_cli.Text);
                                string nombres = txt_nombre_cli.Text;
                                string apellidos = txt_apellido_clie.Text;
                                string telefono = txt_telefono_cli.Text;
                                string correo = txt_correo_cli.Text;
                                int id_cancha =Convert.ToInt32(txt_id_canchas.Text);
                                int id_arbitro =Convert.ToInt32(txt_id_arbitros.Text);
                                DateTime fecha =Convert.ToDateTime(dateTimePicker1.Text);
                                TimeSpan hora_inicio =TimeSpan.Parse(txt_alquiler_hora_inicio.Text);
                                TimeSpan hora_fin = TimeSpan.Parse(txt_alquiler_hora_final.Text);
                                decimal pago_cancha = Convert.ToDecimal(txt_pago_canchas.Text);
                                decimal pago_arbitros=Convert.ToDecimal(txt_pago_arbitro.Text);

                                
                    
                            
                      
        alquileres_context.Actualizar_alquiler(id_alquiler, dpi, nombres, apellidos, telefono, correo, id_cancha, id_arbitro, fecha, hora_inicio, hora_fin,pago_cancha,pago_arbitros);
                                mostrar_alquileres_datagrid();
                           
                                accion = 1;




                                txt_alquiler_hora_final.Text = "";
                                txt_alquiler_hora_inicio.Text = "";
                                txt_dia_alquiler.Text = "";
                                txt_dpi_cli.Text = "";
                                txt_nombre_cli.Text = "";
                                txt_apellido_clie.Text = "";
                                txt_telefono_cli.Text = "";
                                txt_correo_cli.Text = "";
                                txt_id_canchas.Text = "";
                                txt_precio_canchas.Text = "";
                                txt_pago_canchas.Text = "";
                                cmb_opcion_arbitros.Text = "Seleccione una opcion";
                                comboBox1.Text = "";
                                txt_id_canchas.Text = "";
                                txt_precio_canchas.Text = "";
                                txt_pago_canchas.Text = "";
                                comboBox4.Text = "";
                                txt_id_arbitros.Text = "";
                                txt_precio_arbitro_alquiler.Text = "";
                                txt_pago_arbitro.Text = "";
                                cmb_opcion_arbitros.Text = "Seleccione una opcion";
                                comboBox2.Text = "";
                                comboBox3.Text = "";
                                comboBox1.Text = "";
                                comboBox4.Text = "";


                            }
                        }
                        else if (txt_dia_alquiler.Text == "Saturday")
                        {


                            if (hora_inicio_sabados > validacion_hora_inicio || hora_final_sabados < validacion_hora_final)

                            {

                                MessageBox.Show("Las canchas no se puden alquilar Sabados ,\n Abrimos:  " + txt_inicio_sabado.Text + "   Cerramos: " + txt_fin_sabado.Text, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {

                                


                                txt_alquiler_hora_final.Text = "";
                                txt_alquiler_hora_inicio.Text = "";
                                txt_dia_alquiler.Text = "";
                                txt_dpi_cli.Text = "";
                                txt_nombre_cli.Text = "";
                                txt_apellido_clie.Text = "";
                                txt_telefono_cli.Text = "";
                                txt_correo_cli.Text = "";
                                txt_id_canchas.Text = "";
                                txt_precio_canchas.Text = "";
                                txt_pago_canchas.Text = "";
                                cmb_opcion_arbitros.Text = "Seleccione una opcion";
                                comboBox1.Text = "";
                                txt_id_canchas.Text = "";
                                txt_precio_canchas.Text = "";
                                txt_pago_canchas.Text = "";
                                comboBox4.Text = "";
                                txt_id_arbitros.Text = "";
                                txt_precio_arbitro_alquiler.Text = "";
                                txt_pago_arbitro.Text = "";
                                cmb_opcion_arbitros.Text = "Seleccione una opcion";
                                comboBox2.Text = "";
                                comboBox3.Text = "";
                                comboBox1.Text = "";
                                comboBox4.Text = "";


                            }


                        }
                        else if (txt_dia_alquiler.Text == "Sunday")
                        {




                            if (hora_inicio_domingos > validacion_hora_inicio || hora_fin_domingos < validacion_hora_final)

                            {
                                MessageBox.Show("Las canchas no se puden alquilar Domingos ,\n Abrimos:  " + txt_inicio_domingos.Text + "   Cerramos: " + txt_fin_domingos.Text, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {


                                txt_alquiler_hora_final.Text = "";
                                txt_alquiler_hora_inicio.Text = "";
                                txt_dia_alquiler.Text = "";
                                txt_dpi_cli.Text = "";
                                txt_nombre_cli.Text = "";
                                txt_apellido_clie.Text = "";
                                txt_telefono_cli.Text = "";
                                txt_correo_cli.Text = "";
                                txt_id_canchas.Text = "";
                                txt_precio_canchas.Text = "";
                                txt_pago_canchas.Text = "";
                                cmb_opcion_arbitros.Text = "Seleccione una opcion";
                                comboBox1.Text = "";
                                txt_id_canchas.Text = "";
                                txt_precio_canchas.Text = "";
                                txt_pago_canchas.Text = "";
                                comboBox4.Text = "";
                                txt_id_arbitros.Text = "";
                                txt_precio_arbitro_alquiler.Text = "";
                                txt_pago_arbitro.Text = "";
                                cmb_opcion_arbitros.Text = "Seleccione una opcion";
                                comboBox2.Text = "";
                                comboBox3.Text = "";
                                comboBox1.Text = "";
                                comboBox4.Text = "";
                            }


                        }




                    }
                    break;



            }
          

           

        }

        private void txt_fecha_alquiler_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if(comboBox2.Text=="" && comboBox3.Text=="")
            {
                
            }
            else
            {
                //si se modifica la hora y la fecha, los campos vuelven a ser vacio canchas
                comboBox1.Text = "";
                txt_id_canchas.Text = "";
                txt_precio_canchas.Text = "";
                txt_pago_canchas.Text = "";

                //si se modifica la hora y la fecha, los campos vuelven a ser vacio arbitros
                comboBox4.Text = "";
                txt_id_arbitros.Text = "";
                txt_precio_arbitro_alquiler.Text = "";
                txt_pago_arbitro.Text = "";
                cmb_opcion_arbitros.Text = "Seleccione una opcion";

                DateTime fecha2;
                fecha2 = DateTime.Parse(dateTimePicker1.Text);

                combo1.Buscar_canchas_disponibles(comboBox1, fecha2, TimeSpan.Parse(comboBox2.Text), TimeSpan.Parse(comboBox3.Text));
                combo2.Buscar_arbitros_disponibles(comboBox4, fecha2, TimeSpan.Parse(comboBox2.Text), TimeSpan.Parse(comboBox3.Text));

            }

            DateTime fecha;
            fecha = DateTime.Parse(dateTimePicker1.Text);
            fechaaaaa = fecha;
            //txt_dia_alquiler.Text=fecha.DayOfWeek.ToString();
            dias = fecha.DayOfWeek.ToString() ;
            txt_dia_alquiler.Text = dias;
        }
       
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cmb_opcion_arbitros_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmb_opcion_arbitros.SelectedIndex == 0)
            {

                txt_id_arbitros.Visible = true;
                txt_pago_arbitro.Visible = true;
                comboBox4.Visible = true;
                label17.Visible = true;
                label18.Visible = true;
                txt_id_arbitros.Text = "";
                txt_pago_arbitro.Text = "";


            }
            else if(cmb_opcion_arbitros.SelectedIndex >= 1)
            {
                txt_id_arbitros.Visible = false;
                txt_pago_arbitro.Visible = false;
                comboBox4.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                txt_id_arbitros.Text = "0";
                txt_pago_arbitro.Text = "00.00";
            }




        }

        private void txt_arbitros_TextChanged(object sender, EventArgs e)
        {
  
        }

        private void txt_pago_arbitro_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void txt_alquiler_hora_inicio_TextChanged(object sender, EventArgs e)
        {
           
           

        }

        private void txt_alquiler_hora_final_TextChanged(object sender, EventArgs e)
        {
        

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex>=0)
            {
                txt_alquiler_hora_inicio.Text = comboBox2.Text;

            }

            if (comboBox3.Text == "")
            {

            }
            else
            {
                //si se modifica la hora y la fecha, los campos vuelven a ser vacio en canchas
                comboBox1.Text = "";
                txt_id_canchas.Text = "";
                txt_precio_canchas.Text = "";
                txt_pago_canchas.Text = "";
                //si se modifica la hora y la fecha, los campos vuelven a ser vacio arbitros
                comboBox4.Text = "";
                txt_id_arbitros.Text = "";
                txt_precio_arbitro_alquiler.Text = "";
                txt_pago_arbitro.Text = "";
                cmb_opcion_arbitros.Text = "Seleccione una opcion";

                DateTime fecha;

                fecha = DateTime.Parse(dateTimePicker1.Text);
                combo1.Buscar_canchas_disponibles(comboBox1, fecha, TimeSpan.Parse(comboBox2.Text), TimeSpan.Parse(comboBox3.Text));
                combo2.Buscar_arbitros_disponibles(comboBox4, fecha, TimeSpan.Parse(comboBox2.Text), TimeSpan.Parse(comboBox3.Text));

                decimal dif_inicio;
                dif_inicio = Convert.ToDecimal(TimeSpan.Parse(comboBox3.Text).TotalHours) - Convert.ToDecimal(TimeSpan.Parse(comboBox2.Text).TotalHours);
                txt_cantidad_horas.Text = dif_inicio.ToString();



            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex >= 0)
            {
                txt_alquiler_hora_final.Text = comboBox3.Text;

            }


            if (comboBox2.Text == "")
            {

            }
            else
            {
                //si se modifica la hora y la fecha, los campos vuelven a ser vacio canchas
                comboBox1.Text = "";
                txt_id_canchas.Text = "";
                txt_precio_canchas.Text = "";
                txt_pago_canchas.Text = "";
                //si se modifica la hora y la fecha, los campos vuelven a ser vacio arbitros
                comboBox4.Text = "";
                txt_id_arbitros.Text = "";
                txt_precio_arbitro_alquiler.Text = "";
                txt_pago_arbitro.Text = "";
                cmb_opcion_arbitros.Text = "Seleccione una opcion";
                DateTime fecha;
                fecha = DateTime.Parse(dateTimePicker1.Text);
                combo1.Buscar_canchas_disponibles(comboBox1, fecha, TimeSpan.Parse(comboBox2.Text), TimeSpan.Parse(comboBox3.Text));
                combo2.Buscar_arbitros_disponibles(comboBox4, fecha, TimeSpan.Parse(comboBox2.Text), TimeSpan.Parse(comboBox3.Text));

                decimal dif_inicio;
                dif_inicio = Convert.ToDecimal(TimeSpan.Parse(comboBox3.Text).TotalHours) - Convert.ToDecimal(TimeSpan.Parse(comboBox2.Text).TotalHours);
                txt_cantidad_horas.Text = dif_inicio.ToString();


            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex>=0)
            {

             
                string[] datos = alquileres_context.captar_info_id_canchas(comboBox1.Text);
                txt_id_canchas.Text = datos[0];
                string[] datoss = alquileres_context.captar_info_id_canchas(comboBox1.Text);
                txt_precio_canchas.Text = datoss[4];

                decimal horas_a_pagar;
                decimal precio_canchas;
                decimal tatoal_pagar;

                if(txt_cantidad_horas.Text==""|| txt_precio_canchas.Text=="")
                {


                }
                else
                {
                    horas_a_pagar = Convert.ToDecimal(txt_cantidad_horas.Text);
                    precio_canchas = Convert.ToDecimal(txt_precio_canchas.Text);
                    tatoal_pagar = horas_a_pagar * precio_canchas;
                    txt_pago_canchas.Text = tatoal_pagar.ToString();
                }









            }
        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {   
            

        }

        private void txt_id_canchas_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( comboBox4.SelectedIndex>=0)
            {
                string[] datos3 = alquileres_context.captar_info_id_arbitros(comboBox4.Text);
                txt_id_arbitros.Text = datos3[0];


                string[] datoss4 = alquileres_context.captar_info_id_arbitros(comboBox4.Text);
                txt_precio_arbitro_alquiler.Text = datoss4[9];


                decimal horas_a_pagar;
                decimal precio_arbitro;
                decimal tatoal_pagar;
                if (txt_cantidad_horas.Text == "" || txt_precio_arbitro_alquiler.Text == "")
                {


                }
                else
                {
                    horas_a_pagar = Convert.ToDecimal(txt_cantidad_horas.Text);
                    precio_arbitro = Convert.ToDecimal(txt_precio_arbitro_alquiler.Text);
                    tatoal_pagar = horas_a_pagar * precio_arbitro;
                    txt_pago_arbitro.Text = tatoal_pagar.ToString();
                }


            }
        }

        private void txt_precio_arbitro_alquiler_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_cantidad_horas_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
            MessageBoxButtons eliminar = MessageBoxButtons.YesNo;
            DialogResult dr2 = MessageBox.Show("¿SEGURO DE QUE DESEA actualizar informacion del  usuario?", "ALERTA", eliminar, MessageBoxIcon.Warning);
            if (dr2 == DialogResult.Yes)
            {
                accion = 2;
                //llamado al dpi del jugador a travez del datagrid
                int? id_cancha = Get_dpi_alquiler_seleccionado();

                Alquileres usuario_edita_v = alquileres_context.Get_alquiler_A_EDITAR(id_cancha);

                txt_dpi_cli.Text = usuario_edita_v.dpi_cliente.ToString();
                txt_nombre_cli.Text = usuario_edita_v.nombre_cliente;
                txt_apellido_clie.Text = usuario_edita_v.apellido_cliente;
                txt_telefono_cli.Text = usuario_edita_v.teleefono_clinete;
                txt_correo_cli.Text = usuario_edita_v.correo_cliente;
                txt_id_canchas.Text = usuario_edita_v.id_cancha.ToString();
                txt_id_arbitros.Text = usuario_edita_v.id_arbitro.ToString();
                dateTimePicker1.Value = usuario_edita_v.fecha_reservacion;

                txt_alquiler_hora_inicio.Text = usuario_edita_v.hora_inicio_reservacion.ToString();
                txt_alquiler_hora_final.Text = usuario_edita_v.hora_final_reservacion.ToString();

                comboBox2.Text = usuario_edita_v.hora_inicio_reservacion.ToString();
                comboBox3.Text = usuario_edita_v.hora_final_reservacion.ToString();

                txt_pago_canchas.Text = usuario_edita_v.pago_cancha.ToString();
                txt_pago_arbitro.Text = usuario_edita_v.pago_arbitro.ToString();

            }
            else if (dr2 == DialogResult.No)
            {


                MessageBox.Show("Actualizacion cancelada exitosamente");
            }
        }

    }
}
