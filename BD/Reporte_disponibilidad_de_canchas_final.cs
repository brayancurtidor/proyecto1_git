using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Administracion_Torneos.Modelo;
using System.Windows.Forms;
using Administracion_Torneos.BD;
using System.Data;

namespace Administracion_Torneos.BD
{
    public class Reporte_disponibilidad_de_canchas_final
    {


        private string connectionstring = ("Server=DESKTOP-3JN9FSR;Database=Proyecto_AdministracionTorneosFutbol;User Id = capa; Password=123456789;");

        public void GetCanchas(ComboBox cbx)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                cbx.Items.Clear();
                connection.Open();
                //Query de consulta para obtener equipos
                SqlCommand sql = new SqlCommand("	SELECT * FROM CANCHA where estatus='Habilitada'", connection);
                //Lectura de datos y agregar al combo box los datos
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    //Agregar registros al combo box
                    cbx.Items.Add($" {dr[1]}");
                }
                connection.Close();
            }
        }



        //metodo para traer los horarios de lunes a viernes, horarios de i9nicoi de jornada y fin de jornada
        public string[] captar_info_horas_jornadas()
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand("select*from parametros_empresa", connection);
                //lee lo que esta en la base de datos
                SqlDataReader dr = sql.ExecuteReader();

                string[] resultado = null;
                while (dr.Read())
                {
                    string[] datos =
                    {
                        //Guarda lo que esta en la posicion 1 de la tabla
                        //nombre de torneo
                        dr[2].ToString(),
                        dr[3].ToString(),
                        dr[4].ToString(),
                        dr[5].ToString(),
                        dr[6].ToString(),
                        dr[7].ToString()


                    };
                    resultado = datos;
                }
                connection.Close();
                return resultado;

            }
        }

        //METODO PARA BUSCAR A TODOS LOS JUGADORES
        public List<disponibilidad_cancha_modelo_modelo> reporte_canchas_alquileres_torneo(DateTime fecha_inicio, DateTime fecha_fin,string nombre_cancha)
        {
            List<disponibilidad_cancha_modelo_modelo> reporte = new List<disponibilidad_cancha_modelo_modelo>();
            string query = "exec procedimiento_cacnhas_utilizadas_alquiler @fecha_incio,@fecha_fin,@nombre_canchas";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {

                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@fecha_incio", fecha_inicio);
                sql.Parameters.AddWithValue("@fecha_fin", fecha_fin);
                sql.Parameters.AddWithValue("@nombre_canchas", nombre_cancha);

                try
                {
                    connec.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        disponibilidad_cancha_modelo_modelo reporte_canchas = new disponibilidad_cancha_modelo_modelo();

                        reporte_canchas.numero_cancha = reader.GetInt32(0);
                        reporte_canchas.nombre_cancha = reader.GetString(1);
                        reporte_canchas.fecha_uso_cancha = reader.GetDateTime(2);
                        reporte_canchas.horaInicio_uso_cancha = reader.GetTimeSpan(3);
                        reporte_canchas.horaFin_uso_cancha = reader.GetTimeSpan(4);
                


                        reporte.Add(reporte_canchas);
                    }
                    reader.Close();
                    connec.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al traer los datos en la base de datos" + ex.Message);
                }
            }
            return reporte;
        }



        //METODO PARA BUSCAR A TODOS LOS canchas disponibles
        public List<disponibilidad_cancha_modelo_modelo> reporte_canchas_alquileres_alquileres(DateTime fecha_inicio, DateTime fecha_fin, string nombre_cancha)
        {
            List<disponibilidad_cancha_modelo_modelo> reporte = new List<disponibilidad_cancha_modelo_modelo>();
            string query = "exec disponibilidad_de_cacnchas_alquileres2 @fecha_i,@fecha_f,@nombre_c";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {

                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@fecha_i", fecha_inicio);
                sql.Parameters.AddWithValue("@fecha_f", fecha_fin);
                sql.Parameters.AddWithValue("@nombre_c", nombre_cancha);

                try
                {
                    connec.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        disponibilidad_cancha_modelo_modelo reporte_canchas = new disponibilidad_cancha_modelo_modelo();

                        reporte_canchas.numero_cancha = reader.GetInt32(0);
                        reporte_canchas.nombre_cancha = reader.GetString(1);
                        reporte_canchas.fecha_uso_cancha = reader.GetDateTime(2);
                        reporte_canchas.horaInicio_uso_cancha = reader.GetTimeSpan(3);
                        reporte_canchas.horaFin_uso_cancha = reader.GetTimeSpan(4);



                        reporte.Add(reporte_canchas);
                    }
                    reader.Close();
                    connec.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al traer los datos en la base de datos" + ex.Message);
                }
            }
            return reporte;
        }









        /* public List<disponibilidad_cancha_modelo_modelo> horariosCanchas(DateTime fechaInicio, DateTime fechaFin, string nombre_canchas)
         {
             List<disponibilidad_cancha_modelo_modelo> disponibilidad = new List<disponibilidad_cancha_modelo_modelo>();
             string query = "exec procedimiento_cacnhas_utilizadas_alquiler @fecha_incio,@fecha_fin,@nombre_canchas ";
             using (SqlConnection conexion = new SqlConnection(connectionstring))
             {

                 SqlCommand sql = new SqlCommand(query, conexion);
                 sql.Parameters.AddWithValue("@fecha_incio", fechaInicio);
                 sql.Parameters.AddWithValue("@fecha_fin", fechaFin);
                 sql.Parameters.AddWithValue("@nombre_canchas", nombre_canchas);

                 try
                 {
                     conexion.Open();
                     SqlDataReader reader = sql.ExecuteReader();
                     while (reader.Read())
                     {
                         disponibilidad_cancha_modelo_modelo dispo = new disponibilidad_cancha_modelo_modelo();

                         dispo.fecha = reader.GetDateTime(2);
                         dispo.horaInicio = reader.GetTimeSpan(3);
                         dispo.horaFin = reader.GetTimeSpan(4);
                         disponibilidad.Add(dispo);
                     }
                     reader.Close();
                     conexion.Close();

                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("Error en la base de datos" + ex.Message);
                 }
             }
             return disponibilidad;
         }

         */
























    }
}
