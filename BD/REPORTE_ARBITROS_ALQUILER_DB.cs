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
    public  class REPORTE_ARBITROS_ALQUILER_DB
    {
        //variable que me permitira hacer una conexion a mi base de datos
        private string connectionstring = "Server=DESKTOP-3JN9FSR;Database=Proyecto_AdministracionTorneosFutbol;User Id = capa; Password=123456789;";
        SqlConnection conn;
        public REPORTE_ARBITROS_ALQUILER_DB()
        {
        }

        //METODO PARA BUSCAR A TODOS LOS JUGADORES
        public List<REPORTE_ARBITROS_ALQUILER_MODELO> reporte_arbitros_alquileres(DateTime fecha_inicio, DateTime fecha_fin)
        {
            List<REPORTE_ARBITROS_ALQUILER_MODELO> reporte = new List<REPORTE_ARBITROS_ALQUILER_MODELO>();
            string query = "EXEC reporte_arbitro_alquileres @fecha_inico,@fecha_final";
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
                        REPORTE_ARBITROS_ALQUILER_MODELO reporte_arbitros = new REPORTE_ARBITROS_ALQUILER_MODELO();

                        reporte_arbitros.DPI_arbitros = reader.GetInt32(0);
                        reporte_arbitros.nombres_arbitros = reader.GetString(1);
                        reporte_arbitros.apellidos_arbitros = reader.GetString(2);
                        reporte_arbitros.año = reader.GetInt32(3);
                        reporte_arbitros.mes = reader.GetInt32(4);
                        reporte_arbitros.dia = reader.GetInt32(5);
                        reporte_arbitros.monto_por_dia_tootal = reader.GetDecimal(6);

                        reporte.Add(reporte_arbitros);
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
