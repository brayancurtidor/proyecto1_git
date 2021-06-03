using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.SqlClient;
using Administracion_Torneos.Modelo;
using System.Windows.Forms;
using Administracion_Torneos.BD;

namespace Administracion_Torneos.BD
{
     public class alquile_DB
    {
        private string connectionstring = ("Server=DESKTOP-3JN9FSR;Database=Proyecto_AdministracionTorneosFutbol;User Id = capa; Password=123456789;");
        SqlConnection conexion;
        public string dia;


        //verifcar conexion
        public void openConexion()
        {
            try
            {
                conexion = new SqlConnection(connectionstring);
                conexion.Open();
                MessageBox.Show("Conexion realizada con exito");
            }
            catch
            {
                MessageBox.Show("NO SEA REALIZADO LA CONEXION");
            }
        }


        //METODO PARA BUSCAR A TODOS LOS JUGADORES
        public List<Alquileres> busqueda_alquileres_total()
        {
            List<Alquileres> listado_usuarios = new List<Alquileres>();
            string query = "exec mostrar_alquileres";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {

                SqlCommand sql = new SqlCommand(query, connec);
                try
                {
                    connec.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        Alquileres jugador = new Alquileres();

                        jugador.id_alquiler = reader.GetInt32(0);
                        jugador.dpi_cliente = reader.GetInt64(1);
                        jugador.nombre_cliente = reader.GetString(2);
                        jugador.apellido_cliente = reader.GetString(3);
                        jugador.teleefono_clinete = reader.GetString(4);
                        jugador.correo_cliente = reader.GetString(5);
                        jugador.id_cancha = reader.GetInt32(6);
                        jugador.id_arbitro = reader.GetInt32(7);
                        jugador.fecha_reservacion = reader.GetDateTime(8);
                        jugador.hora_inicio_reservacion = reader.GetTimeSpan(9);
                        jugador.hora_final_reservacion = reader.GetTimeSpan(10);
                        jugador.pago_cancha = reader.GetDecimal(11);
                        jugador.pago_arbitro = reader.GetDecimal(12);
                        jugador.total_pagar = reader.GetDecimal(13);
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



        //METODO QUE ME PERMITIORA AGREGAR LAS RESERVACIONES


        public void Agregar_Jugadores(Alquileres tipo_jugador)
        {
            //$"insert into TIPO_PRODUCTO (NOMBRE)values(@nombre)"+
            string query = "exec insertar_alquileres @DPI,@nombres,@apellidos,@telefono,@correo,@id_cancha,@id_arbitro,@fecha_reservacion,@horainicio,@horasalida,@pago_cancha,@pago_arbitro";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@DPI", tipo_jugador.dpi_cliente);
                sql.Parameters.AddWithValue("@nombres", tipo_jugador.nombre_cliente);
                sql.Parameters.AddWithValue("@apellidos", tipo_jugador.apellido_cliente);
                sql.Parameters.AddWithValue("@telefono", tipo_jugador.teleefono_clinete);
                sql.Parameters.AddWithValue("@correo", tipo_jugador.correo_cliente);
                sql.Parameters.AddWithValue("@id_cancha", tipo_jugador.id_cancha);
                sql.Parameters.AddWithValue("@id_arbitro", tipo_jugador.id_arbitro);
                sql.Parameters.AddWithValue("@fecha_reservacion", tipo_jugador.fecha_reservacion);
                sql.Parameters.AddWithValue("@horainicio", tipo_jugador.hora_inicio_reservacion);
                sql.Parameters.AddWithValue("@horasalida", tipo_jugador.hora_final_reservacion);
                sql.Parameters.AddWithValue("@pago_cancha", tipo_jugador.pago_cancha);
                sql.Parameters.AddWithValue("@pago_arbitro", tipo_jugador.pago_arbitro);


                try
                {
                    connec.Open();
                    sql.ExecuteNonQuery();
                    connec.Close();
                    MessageBox.Show("Se Agrego correctamente LA RESERVACION DEL CLIENTE :  " + " " + tipo_jugador.nombre_cliente + "  " + tipo_jugador.apellido_cliente);
                 
                }
                catch (Exception ex)
                {
                 
                    MessageBox.Show("ERROR NO SE PUEDE AGREGAR LA RESERVACION"+ex.Message);
                }

            }

        }

        //llenando el combobox
        public void Buscar_canchas_disponibles(ComboBox cb,DateTime fecha_reservacion,TimeSpan hora_inicio,TimeSpan horafinal)
        {
            string query = "exec canchas_disponibles @fecha_reservaciones,@hora_inicio_reservacion,@hora_fin_reservacion";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@fecha_reservaciones", fecha_reservacion);
                sql.Parameters.AddWithValue("@hora_inicio_reservacion", hora_inicio);
                sql.Parameters.AddWithValue("@hora_fin_reservacion", horafinal);
                cb.Items.Clear();
                connec.Open();
                SqlDataReader reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    cb.Items.Add(reader[1].ToString());
                }


                connec.Close();
             
            }
        }




        //metodo para traer los id_de las canchas selecionadas
        public string[] captar_info_id_canchas(string nombre_canchas)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand("select*from CANCHA where Nombre='"+ nombre_canchas + "'", connection);
                //lee lo que esta en la base de datos
                SqlDataReader dr = sql.ExecuteReader();

                string[] resultado = null;
                while (dr.Read())
                {
                    string[] datos =
                    {
                        //Guarda lo que esta en la posicion 1 de la tabla
                        //nombre de torneo
                        dr[0].ToString(),
                        dr[1].ToString(),
                        dr[2].ToString(),
                        dr[3].ToString(),
                        dr[4].ToString()



                    };
                    resultado = datos;
                }
                connection.Close();
                return resultado;

            }
        }




        //----------------- 
        //llenando el combobox
        public void Buscar_arbitros_disponibles(ComboBox cb, DateTime fecha_reservacion, TimeSpan hora_inicio, TimeSpan horafinal)
        {
            string query = "exec vista_arbitros_disponibles @fecha_reservacion,@hora_inicio_reservacion,@hora_fin_reservacion";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@fecha_reservacion", fecha_reservacion);
                sql.Parameters.AddWithValue("@hora_inicio_reservacion", hora_inicio);
                sql.Parameters.AddWithValue("@hora_fin_reservacion", horafinal);
                cb.Items.Clear();
                connec.Open();
                SqlDataReader reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    cb.Items.Add(reader[1].ToString());
                }


                connec.Close();

            }
        }




        //metodo para traer los id_de las canchas selecionadas
        public string[] captar_info_id_arbitros(string nombre_arbitro)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand("select*from ARBITRO where nombre='" + nombre_arbitro + "'", connection);
                //lee lo que esta en la base de datos
                SqlDataReader dr = sql.ExecuteReader();

                string[] resultado = null;
                while (dr.Read())
                {
                    string[] datos =
                    {
                        //Guarda lo que esta en la posicion 1 de la tabla
                        //nombre de torneo
                        dr[0].ToString(),
                        dr[1].ToString(),
                        dr[2].ToString(),
                        dr[3].ToString(),
                        dr[4].ToString(),
                        dr[5].ToString(),
                        dr[6].ToString(),
                        dr[7].ToString(),
                        dr[8].ToString(),
                        dr[9].ToString()



                    };
                    resultado = datos;
                }
                connection.Close();
                return resultado;

            }
        }


        //metodo que me permitira buscar informacion de los usuarios
        public Alquileres Get_alquiler_A_EDITAR(int? id_alquiler)
        {
            Alquileres jugador_editar = new Alquileres();
            string query = "editar_un_aluiler @id_cancha";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@id_cancha", id_alquiler); //pasandole a la variable el parametro
                try
                {
                    connec.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read(); //leer solo un registro (read)
                    jugador_editar.id_alquiler = reader.GetInt32(0);
                    jugador_editar.dpi_cliente = reader.GetInt64(1);
                    jugador_editar.nombre_cliente = reader.GetString(2);
                    jugador_editar.apellido_cliente = reader.GetString(3);
                    jugador_editar.teleefono_clinete = reader.GetString(4);
                    jugador_editar.correo_cliente = reader.GetString(5);
                    jugador_editar.id_cancha = reader.GetInt32(6);
                    jugador_editar.id_arbitro = reader.GetInt32(7);
                    jugador_editar.fecha_reservacion = reader.GetDateTime(8);
                    jugador_editar.hora_inicio_reservacion = reader.GetTimeSpan(9);
                    jugador_editar.hora_final_reservacion = reader.GetTimeSpan(10);
                    jugador_editar.pago_cancha = reader.GetDecimal(11);
                    jugador_editar.pago_arbitro = reader.GetDecimal(12);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener solo un registro de la base de datos " + ex.Message);
                }
                return jugador_editar;
            }
        }







        //metodo para actualizar la informacion de los jugadores
        public void Actualizar_alquiler(int? id_cancha,long dpi_actualizar ,string nombre_actualizar, string apellido_actualizar, string telefono, string coreo, int i_cancha, int  id_arbitro, DateTime fecha_actualizar, TimeSpan hora_inicio, TimeSpan horafin,decimal pago_cancha, decimal pago_arbitro)
        {


            string query = "exec update_alquileres @id_alquiler  ,@DPI ,@nombres ,@apellidos ,@telefono ,@correo ,@id_cancha,@id_arbitro ,@fecha_reservacion,@hora_inicio_reservacion,@hora_fin_reservacion,@pago_cancha,@pago_arbitro";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(query, connec);
                command.Parameters.AddWithValue("@id_alquiler", id_cancha);
                command.Parameters.AddWithValue("@DPI", dpi_actualizar);
                command.Parameters.AddWithValue("@nombres", nombre_actualizar);
                command.Parameters.AddWithValue("@apellidos", apellido_actualizar);
                command.Parameters.AddWithValue("@telefono", telefono);
                command.Parameters.AddWithValue("@correo", coreo);
                command.Parameters.AddWithValue("@id_cancha", i_cancha);
                command.Parameters.AddWithValue("@id_arbitro", id_arbitro);
                command.Parameters.AddWithValue("@fecha_reservacion", fecha_actualizar);
                command.Parameters.AddWithValue("@hora_inicio_reservacion", hora_inicio);
                command.Parameters.AddWithValue("@hora_fin_reservacion", horafin);
                command.Parameters.AddWithValue("@pago_cancha", pago_cancha);
                command.Parameters.AddWithValue("@pago_arbitro", pago_arbitro);



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
