using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.SqlClient;
using System.Windows.Forms;
using Administracion_Torneos.Modelo;

namespace Administracion_Torneos.BD
{
     public class REPORTE_CANCHA_ALQUILERES
    {

        //variable que me permitira hacer una conexion a mi base de datos
        private string connectionstring = "Server=DESKTOP-3JN9FSR;Database=Proyecto_AdministracionTorneosFutbol;User Id = capa; Password=123456789;";
        SqlConnection conn;
        public REPORTE_CANCHA_ALQUILERES()
        {
        }

        //METODO PARA BUSCAR A TODOS LOS JUGADORES
        public List<REPORTE_CANCHA_MODELO_ALQUILER> reporte_canchas_alquileres(DateTime fecha_inicio,DateTime fecha_fin)
        {
            List<REPORTE_CANCHA_MODELO_ALQUILER> reporte = new List<REPORTE_CANCHA_MODELO_ALQUILER>();
            string query = "EXEC reporte_canchas_alquileres @fecha_inico,@fecha_final";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {

                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@fecha_inico", fecha_inicio);
                sql.Parameters.AddWithValue("@fecha_final", fecha_fin);
                try
                {
                    connec.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        REPORTE_CANCHA_MODELO_ALQUILER reporte_canchas = new REPORTE_CANCHA_MODELO_ALQUILER();

                        reporte_canchas.numero_cancha = reader.GetInt32(0);
                        reporte_canchas.nombre_cancha = reader.GetString(1);
                        reporte_canchas.año = reader.GetInt32(2);
                        reporte_canchas.mes = reader.GetInt32(3);
                        reporte_canchas.dia = reader.GetInt32(4);
                        reporte_canchas.Moto_por_dia = reader.GetDecimal(5);
                    

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




















    }
}
