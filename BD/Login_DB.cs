using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System.Data.SqlClient;
using System.Windows.Forms;
using Administracion_Torneos.Modelo;
using Administracion_Torneos.Vista;
using System.Data;

namespace Administracion_Torneos.BD
{
     public class Login_DB
    {
  


        //variable que me permitira hacer una conexion a mi base de datos
        private string connectionstring = "Server=DESKTOP-3JN9FSR;Database=Proyecto_AdministracionTorneosFutbol;User Id = capa; Password=123456789;";
        SqlConnection conn;
        public int bandera_acceso=1;
        public Login_DB()
        {
        }


        public void Login_usuarios(string nombre,string apellido, string contraseña )
        {
            //$"insert into TIPO_PRODUCTO (NOMBRE)values(@nombre)"+
            string query = "exec validar_ingreso_usuarios @nombre_usuario, @apellido_usuario, @contraseña";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@nombre_usuario", nombre); //pasandole a la variable el parametro
                sql.Parameters.AddWithValue("@apellido_usuario", apellido); //pasandole a la variable el parametro
                sql.Parameters.AddWithValue("@contraseña", contraseña); //pasandole a la variable el parametro

                try
                {
                    connec.Open();
                 
                    SqlDataAdapter sda = new SqlDataAdapter(sql);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if(dt.Rows.Count==1) //si se llena la tabla con la informacion a buscar, quiere decir que el nombre apellido y contraseña si existe
                    {
                      

                        if (dt.Rows[0][5].ToString() == "N") //condicinal, cuando si exista informacion de que el nombre, apellido, contraseña son correctos, pero cuando se llena la tabla datatable, en la columna de actiuvo, y ese activo es N entonces no se dejara ver la vista y mostrata un mensaje
                        {
                            MessageBox.Show("Error al acceder, el usuario ya esta bloqueado", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            bandera_acceso = 0;
                        }
                        else
                        {

                            bandera_acceso = 1;
                            string dpi = dt.Rows[0][0].ToString();
                            string nombres_usuarios = dt.Rows[0][1].ToString();
                            string apellidos_usuarios = dt.Rows[0][2].ToString();
                            string puesto_usuario= dt.Rows[0][4].ToString();
                          


                            if (dt.Rows[0][4].ToString() == "Administrador") //si en la columna 3  de mi tabla datatable se llena con administrador me dirige ala vista
                            {

                                MessageBox.Show("presentado vista administrador");
                                
                                Vista_opciones_admin vista_asmin = new Vista_opciones_admin(dpi,nombres_usuarios,apellidos_usuarios,puesto_usuario);
                                vista_asmin.Show();
                                


                            }
                            else if (dt.Rows[0][4].ToString() == "Operador")
                            {


                                MessageBox.Show("presentado vista operador");
                                Vista_operador vista_operador = new Vista_operador(dpi, nombres_usuarios, apellidos_usuarios, puesto_usuario);
                                vista_operador.Show();

                               
                            }
                            else if (dt.Rows[0][4].ToString() == "Reportes")
                            {



                                MessageBox.Show("presentado vista reportes");

                                Vista_reportes vista_reportes = new Vista_reportes(dpi, nombres_usuarios, apellidos_usuarios, puesto_usuario);
                                vista_reportes.Show();


                            }
                           
                        }

                    }
                    else
                    {
                        MessageBox.Show("Error la contraseña es incorrecta","ALERTA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        bandera_acceso = 0;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("ERROR "/*, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error*/+ ex.Message);
                }
               
            }
          
        }


        //Metodo para mostrar los usuarios

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
        public void usuario_all_apellios(ComboBox cb,string apellidos)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                cb.Items.Clear();
                connection.Open();
                SqlCommand sql = new SqlCommand("exec apellidos_nombres_iguales @nombres='"+ apellidos + "'", connection);
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







    }
}
