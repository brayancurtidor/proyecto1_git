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
    public class USUARIOS_DB
    {


        //variable que me permitira hacer una conexion a mi base de datos
        private string connectionstring = "Server=DESKTOP-3JN9FSR;Database=Proyecto_AdministracionTorneosFutbol;User Id = capa; Password=123456789;";
        SqlConnection conn;
        public USUARIOS_DB()
        {
        }


        //METODO PARA BUSCAR A TODOS LOS JUGADORES
        public List<USUARIO_MODELO> busqueda_usuarios_total()
        {
            List<USUARIO_MODELO> listado_usuarios = new List<USUARIO_MODELO>();
            string query = "exec ver_usuarios";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {

                SqlCommand sql = new SqlCommand(query, connec);
                try
                {
                    connec.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        USUARIO_MODELO jugador = new USUARIO_MODELO();

                        jugador.dpi_usuario = reader.GetInt64(0);
                        jugador.nombre_usuario = reader.GetString(1);
                        jugador.apellidos = reader.GetString(2);
                        jugador.telefono = reader.GetString(3);
                        jugador.direccion = reader.GetString(4);
                        jugador.correo = reader.GetString(5);
                        jugador.puesto_usuario = reader.GetString(6);
                        jugador.rol_usuario = reader.GetString(7);
                        jugador.contraeña = reader.GetString(8);
                        jugador.activo = reader.GetString(9);

                        listado_usuarios.Add(jugador);
                    }
                    reader.Close();
                    connec.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al traer los datos en la base de datos" + ex.Message);
                }
            }
            return listado_usuarios;
        }

        //metodo para insertar nuevos productos
        public void Agregar_usuarios(USUARIO_MODELO tipo_jugador)
        {
            //$"insert into TIPO_PRODUCTO (NOMBRE)values(@nombre)"+
            string query = "exec insertar_usuarios @dpi,@nombres,@apellidos,@telefonos,@direccion,@correo,@puesto_usuario,@rol,@contraeña,@activo";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@dpi", tipo_jugador.dpi_usuario);
                sql.Parameters.AddWithValue("@nombres", tipo_jugador.nombre_usuario);
                sql.Parameters.AddWithValue("@apellidos", tipo_jugador.apellidos);
                sql.Parameters.AddWithValue("@telefonos", tipo_jugador.telefono);
                sql.Parameters.AddWithValue("@direccion", tipo_jugador.direccion);
                sql.Parameters.AddWithValue("@correo", tipo_jugador.correo);
                sql.Parameters.AddWithValue("@puesto_usuario", tipo_jugador.puesto_usuario);
                sql.Parameters.AddWithValue("@rol", tipo_jugador.rol_usuario);
                sql.Parameters.AddWithValue("@contraeña", tipo_jugador.contraeña);
                sql.Parameters.AddWithValue("@activo", tipo_jugador.activo);


                try
                {
                    connec.Open();
                    sql.ExecuteNonQuery();
                    connec.Close();
                    MessageBox.Show("Se Agrego correctamente al usuario : " + " " + tipo_jugador.nombre_usuario + " " + tipo_jugador.apellidos);
                
                }
                catch (Exception ex)
                {
                  
                    MessageBox.Show("ERROR no se puede agregar, este uysuario ya que la identificacion ya esta en uso"/*, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error*/+ex.Message);
                }

            }

        }



        //metodo que me permitira buscar informacion de los usuarios
        public USUARIO_MODELO Get_usuario_A_EDITAR(long? dpi)
        {
            USUARIO_MODELO jugador_editar = new USUARIO_MODELO();
            string query = "exec buscar_usuarios_dpi @dpi";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@dpi", dpi); //pasandole a la variable el parametro
                try
                {
                    connec.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read(); //leer solo un registro (read)
                    jugador_editar.dpi_usuario = reader.GetInt64(0);
                    jugador_editar.nombre_usuario = reader.GetString(1);
                    jugador_editar.apellidos = reader.GetString(2);
                    jugador_editar.telefono = reader.GetString(3);
                    jugador_editar.direccion = reader.GetString(4);
                    jugador_editar.correo = reader.GetString(5);
                    jugador_editar.puesto_usuario = reader.GetString(6);
                    jugador_editar.rol_usuario = reader.GetString(7);
                    jugador_editar.contraeña = reader.GetString(8);
                    jugador_editar.activo = reader.GetString(9);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener solo un registro de la base de datos " + ex.Message);
                }
                return jugador_editar;
            }
        }




        //metodo para actualizar la informacion de los jugadores
        public void Actualizar_usuarios(long? dpi_usuario, string nombre_actualizar, string apellido_actualizar, string telefono, string direccion_actualizar, string correo, string puesto_usuario,string rol_usuariuo, string contraseña,string activo)
        {


            string query = "exec actualizar_datos_usuarios @dpi_usuario,@nombre_usuario,@apellidos,@telefono,@direccion,@correo,@puesto_usuario,@rol_usuario,@contraeña,@activo";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(query, connec);
                command.Parameters.AddWithValue("@dpi_usuario", dpi_usuario);
                command.Parameters.AddWithValue("@nombre_usuario", nombre_actualizar);
                command.Parameters.AddWithValue("@apellidos", apellido_actualizar);
                command.Parameters.AddWithValue("@telefono", telefono);
                command.Parameters.AddWithValue("@direccion", direccion_actualizar);
                command.Parameters.AddWithValue("@correo", correo);
                command.Parameters.AddWithValue("@puesto_usuario", puesto_usuario);
                command.Parameters.AddWithValue("@rol_usuario", rol_usuariuo);
                command.Parameters.AddWithValue("@contraeña", contraseña);
                command.Parameters.AddWithValue("@activo", activo);
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



        //metodo para actualizar la informacion de los jugadores
        public void DESACTIVAR_usuarios(long? dpi_usuario)
        {


            string query = "exec desactivar_usuarios_por_dpi @dpi_usuario";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(query, connec);
                command.Parameters.AddWithValue("@dpi_usuario", dpi_usuario);
          
                try
                {
                    connec.Open();
                    command.ExecuteNonQuery();
                    connec.Close();
                    MessageBox.Show("USUARIO DESACTIVADO ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puedo actualizra en la base de datos" + ex.Message);
                }

            }
        }






















    }
}
