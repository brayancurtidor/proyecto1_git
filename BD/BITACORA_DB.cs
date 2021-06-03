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
    public class BITACORA_DB
    {
        //variable que me permitira hacer una conexion a mi base de datos
        private string connectionstring = "Server=DESKTOP-3JN9FSR;Database=Proyecto_AdministracionTorneosFutbol;User Id = capa; Password=123456789;";
        SqlConnection conn;
        public BITACORA_DB()
        {

        }

        //metodo para insertar nuevos registros en bitacora
        public void Agregar_registro(bitacora_modelo nuevo_registro_bitacora )
        {
            //$"insert into TIPO_PRODUCTO (NOMBRE)values(@nombre)"+
            string query = "exec insertando_bitacoras @nombre_usuario,@apellido_usuaio,@puesto_trabajo,@acciones_sistema";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@nombre_usuario", nuevo_registro_bitacora.nombre);
                sql.Parameters.AddWithValue("@apellido_usuaio", nuevo_registro_bitacora.apellidos);
                sql.Parameters.AddWithValue("@puesto_trabajo", nuevo_registro_bitacora.Puesto_usuario);
                sql.Parameters.AddWithValue("@acciones_sistema", nuevo_registro_bitacora.Acciones_en_sistema);
                


                try
                {
                    connec.Open();
                    sql.ExecuteNonQuery();
                    connec.Close();
          

                }
                catch (Exception ex)
                {

                    MessageBox.Show("ERROR no se puede agregar, este uysuario ya que la identificacion ya esta en uso"/*, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error*/+ ex.Message);
                }

            }

        }






        //metodos para hacer reportes
        //Seleccionar partido, necesitamos la informacion
        public void usuario_all(ComboBox cb)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                cb.Items.Clear();
                connection.Open();
                SqlCommand sql = new SqlCommand("select  DISTINCT nombre_usuario  from usuarios", connection);
                //lee lo que esta en la tabla
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    //se guarda en una variable lo que esta en la posicion 1 de la tabla que seria el ID
                    cb.Items.Add(dr[0].ToString());
                }
                connection.Close();
                //mensaje q se mostrara en el combobox
                //cb.Items.Insert(0, "----Seleccione un Torneo----");
                //cb.SelectedIndex = 0;
            }
        }


        //Seleccionar partido, necesitamos la informacion
        public void usuario_all_apellios(ComboBox cb, string apellidos)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                cb.Items.Clear();
                connection.Open();
                SqlCommand sql = new SqlCommand("exec apellidos_nombres_iguales @nombres='" + apellidos + "'", connection);
                //lee lo que esta en la tabla
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    //se guarda en una variable lo que esta en la posicion 1 de la tabla que seria el ID
                    cb.Items.Add(dr[0].ToString());
                }
                connection.Close();
                //mensaje q se mostrara en el combobox
                //cb.Items.Insert(0, "----Seleccione un Torneo----");
                //cb.SelectedIndex = 0;
            }
        }



        //metodo para hacer el reporte por fechas
        public List<bitacora_modelo> reporte_bitacora_fechas(DateTime fecha_inicio, DateTime fecha_fin)
        {
            List<bitacora_modelo> reporte = new List<bitacora_modelo>();
            string query = "exec reporte_por_fechas_bitacora @fecha_inico,@fecha_fin";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {

                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@fecha_inico", fecha_inicio);
                sql.Parameters.AddWithValue("@fecha_fin", fecha_fin);
                try
                {
                    connec.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        bitacora_modelo reporte_bitacora_fechas = new bitacora_modelo();

                        reporte_bitacora_fechas.nombre = reader.GetString(1);
                        reporte_bitacora_fechas.apellidos = reader.GetString(2);
                        reporte_bitacora_fechas.Puesto_usuario = reader.GetString(3);
                        reporte_bitacora_fechas.Acciones_en_sistema = reader.GetString(4);
                        reporte_bitacora_fechas.fecha_registro = reader.GetDateTime(5);
                       


                        reporte.Add(reporte_bitacora_fechas);
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



        //metodo para hacer el reporte por nombre y apellido
        public List<bitacora_modelo> reporte_bitacora_nombre_apellido(string nombre, string apellido)
        {
            List<bitacora_modelo> reporte = new List<bitacora_modelo>();
            string query = "exec reporte_por_usuario_bitacora @nombre_usuario,@apellido_usuario";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {

                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@nombre_usuario", nombre);
                sql.Parameters.AddWithValue("@apellido_usuario", apellido);
                try
                {
                    connec.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        bitacora_modelo reporte_bitacora_fechas = new bitacora_modelo();

                        reporte_bitacora_fechas.nombre = reader.GetString(1);
                        reporte_bitacora_fechas.apellidos = reader.GetString(2);
                        reporte_bitacora_fechas.Puesto_usuario = reader.GetString(3);
                        reporte_bitacora_fechas.Acciones_en_sistema = reader.GetString(4);
                        reporte_bitacora_fechas.fecha_registro = reader.GetDateTime(5);



                        reporte.Add(reporte_bitacora_fechas);
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
