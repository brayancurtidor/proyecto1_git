using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System.Data.SqlClient;
using System.Windows.Forms;
using Administracion_Torneos.Modelo;
namespace Administracion_Torneos.Modelo
{
    public class PARAMETROS_EMPRESA_DB
    {

        //variable que me permitira hacer una conexion a mi base de datos
        private string connectionstring = "Server=DESKTOP-3JN9FSR;Database=Proyecto_AdministracionTorneosFutbol;User Id = capa; Password=123456789;";
        SqlConnection conn;
        public PARAMETROS_EMPRESA_DB()
        {
        }



        //METODO PARA BUSCAR A TODOS LOS JUGADORES
        public List<PARAMETROS_EMPRESA_MODELO> busqueda_parametros_empresa_total()
        {
            List<PARAMETROS_EMPRESA_MODELO> listado_parametros = new List<PARAMETROS_EMPRESA_MODELO>();
            string query = "exec parametros";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {

                SqlCommand sql = new SqlCommand(query, connec);
                try
                {
                    connec.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        PARAMETROS_EMPRESA_MODELO jugador = new PARAMETROS_EMPRESA_MODELO();

                        jugador.id_empresa = reader.GetInt32(0);
                        jugador.nombre_empresa = reader.GetString(1);
                        jugador.inicio_lunes_viernes = reader.GetTimeSpan(2);
                        jugador.fin_lunes_viernes = reader.GetTimeSpan(3);
                        jugador.inicio_jornada_sabado = reader.GetTimeSpan(4);
                        jugador.fin_jornada_sabado = reader.GetTimeSpan(5);
                        jugador.inicio_jornada_domingos = reader.GetTimeSpan(6);
                        jugador.fin_jornada_domingos = reader.GetTimeSpan(7);


                        listado_parametros.Add(jugador);
                    }
                    reader.Close();
                    connec.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al traer los datos en la base de datos" + ex.Message);
                }
            }
            return listado_parametros;
        }





        //metodo que me permitira buscar informacion de los usuarios
        public PARAMETROS_EMPRESA_MODELO Get_paramtros_A_EDITAR(int? dpi)
        {
            PARAMETROS_EMPRESA_MODELO parametros_editar = new PARAMETROS_EMPRESA_MODELO();
            string query = "exec seleccionar_un_registro @id_empresa";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@id_empresa", dpi); //pasandole a la variable el parametro
                try
                {
                    connec.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read(); //leer solo un registro (read)

                    parametros_editar.id_empresa = reader.GetInt32(0);
                    parametros_editar.nombre_empresa = reader.GetString(1);
                    parametros_editar.inicio_lunes_viernes = reader.GetTimeSpan(2);
                    parametros_editar.fin_lunes_viernes = reader.GetTimeSpan(3);
                    parametros_editar.inicio_jornada_sabado = reader.GetTimeSpan(4);
                    parametros_editar.fin_jornada_sabado = reader.GetTimeSpan(5);
                    parametros_editar.inicio_jornada_domingos = reader.GetTimeSpan(6);
                    parametros_editar.fin_jornada_domingos = reader.GetTimeSpan(7);
                    
             

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener solo un registro de la base de datos " + ex.Message);
                }
                return parametros_editar;
            }
        }






        //metodo para actualizar la informacion de los jugadores
        public void Actualizar_parametros(int? id_empresa, string nombre_emoresa,TimeSpan inicio_lunes_viernes, TimeSpan fin_lunes_viernes, TimeSpan inicio_sabado, TimeSpan fin_sabado, TimeSpan inicio_domingo, TimeSpan fin_domingo)
        {


            string query = "exec actualizar_parametros_empresa @id_empresa,@nombre_empresa,@inicio_jornada_lunes_vienres,@fin_jornada_lunes_viernes,@inicio_jornada_sabados,@fin_jornadas_sabados,@inicio_jornadas_domingo,@fin_jornada_domingo";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(query, connec);
                command.Parameters.AddWithValue("@id_empresa", id_empresa);
                command.Parameters.AddWithValue("@nombre_empresa", nombre_emoresa);
                command.Parameters.AddWithValue("@inicio_jornada_lunes_vienres", inicio_lunes_viernes);
                command.Parameters.AddWithValue("@fin_jornada_lunes_viernes", fin_lunes_viernes);
                command.Parameters.AddWithValue("@inicio_jornada_sabados", inicio_sabado);
                command.Parameters.AddWithValue("@fin_jornadas_sabados", fin_sabado);
                command.Parameters.AddWithValue("@inicio_jornadas_domingo", inicio_domingo);
                command.Parameters.AddWithValue("@fin_jornada_domingo", fin_domingo);
                try
                {
                    connec.Open();
                    command.ExecuteNonQuery();
                    connec.Close();
                    MessageBox.Show("Actualizacion Correcta ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puedo actualizra en la base de datos" + ex.Message);
                }

            }
        }






















    }
}
