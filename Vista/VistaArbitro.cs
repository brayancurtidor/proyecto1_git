﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Administracion_Torneos.Modelo;
using Administracion_Torneos.BD;
using Administracion_Torneos.Vista;

namespace Administracion_Torneos.Vista
{
    public partial class VistaArbitro : Form
    {
        public arbitroDB arbitrosContext = new arbitroDB();
        public Arbitro arbitroSeleccionado = new Arbitro();
        String activ;
        public VistaArbitro()
        {
            InitializeComponent();
            listArbitros.AllowUserToAddRows = false;
            listArbitros.AllowDrop = false;
            listArbitros.AllowUserToDeleteRows = false;
            mostrar();
        }
        public void mostrar()
        {
            listArbitros.DataSource = arbitrosContext.manejoArbitros();
        }
        private void VistaArbitro_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(
                txtIdentificacion.Text==""||
                txtNombre.Text==""||
                    txtApellidos.Text==""||
                txtDireccion.Text==""||
                txtTelefono.Text==""||
                txtNacionalidad.Text==""||
                txtCorreo.Text==""||
                txt_pago_alquiler_arbitro.Text==""
            



                )
            {
                MessageBox.Show("No se puede agregar al arbitro por que hay valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
            {
                if (rbCentral.Checked == true)
                {
                    activ = "Central";
                }

                else if (rbAsistente.Checked == true)
                {
                    activ = "Asistente";
                }


                if (txtIdentificacion.Text != string.Empty && txtNacionalidad.SelectedIndex >= 0)
                {
                    Arbitro ingreso_arbitro = new Arbitro();
                    ingreso_arbitro.Dpi = Convert.ToInt32(txtIdentificacion.Text);
                    ingreso_arbitro.Nombre = txtNombre.Text;
                    ingreso_arbitro.Apellidos = txtApellidos.Text;
                    ingreso_arbitro.Direccion = txtDireccion.Text;
                    ingreso_arbitro.Telefono = txtTelefono.Text;
                    ingreso_arbitro.Nacionalidad = txtNacionalidad.Text;
                    ingreso_arbitro.FechaNac = Convert.ToDateTime(dTFechaNacimiento.Text);
                    ingreso_arbitro.Correo = txtCorreo.Text;
                    ingreso_arbitro.Rol = activ;
                    ingreso_arbitro.pago_alquiler = Convert.ToDecimal(txt_pago_alquiler_arbitro.Text);
                    arbitrosContext.Insertar_arbitro(ingreso_arbitro);
                    this.Hide();
                    VistaArbitro va = new VistaArbitro();
                    va.Show();
                }
                else
                {
                    MessageBox.Show("ingrese el numero de Identificacion");
                }

            }
           
        }

        private void bthSeleccionar_Click(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            int? DPI = buscar_id();
            Arbitro actualizar_arbitro = arbitrosContext.buscar(DPI);
            txtIdentificacion.Text = Convert.ToString(actualizar_arbitro.Dpi);
            txtNombre.Text = actualizar_arbitro.Nombre;
            txtApellidos.Text = actualizar_arbitro.Apellidos;
            txtDireccion.Text = actualizar_arbitro.Direccion;
            txtTelefono.Text = actualizar_arbitro.Telefono;
            txtNacionalidad.Text = actualizar_arbitro.Nacionalidad;
            dTFechaNacimiento.Text = Convert.ToString(actualizar_arbitro.FechaNac);
            txtCorreo.Text = actualizar_arbitro.Correo;
            activ = actualizar_arbitro.Rol;
            txt_pago_alquiler_arbitro.Text = Convert.ToString(actualizar_arbitro.pago_alquiler);

            if (rbCentral.Checked == true)
            {
                activ = "Central";
            }

            else if (rbAsistente.Checked == true)
            {
                activ = "Asistente";
            }
        }
        private int? buscar_id()
        {
            try
            {
                return int.Parse(listArbitros.Rows[listArbitros.CurrentRow.Index].Cells[0].Value.ToString());
            }

            catch
            {
                return null;
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int? DPI = buscar_id();
            if (rbCentral.Checked == true)
            {
                activ = "Central";
            }

            else if (rbAsistente.Checked == true)
            {
                activ = "Asistente";
            }
            string Nombre = txtNombre.Text;
            string Apellidos = txtApellidos.Text;
            string Direccion = txtDireccion.Text;
            string Telefono = txtTelefono.Text;
            string Nacionalidad = txtNacionalidad.Text;
            DateTime FechaNac = Convert.ToDateTime(dTFechaNacimiento.Text);
            string Correo = txtCorreo.Text;
            string Rol = activ;
            decimal pago_alquileres_act = Convert.ToDecimal(txt_pago_alquiler_arbitro.Text);

            arbitrosContext.actualizar_arbitro(DPI, Nombre, Apellidos, Direccion, Telefono, Nacionalidad, FechaNac, Correo, Rol, pago_alquileres_act);
            this.Hide();
            VistaArbitro va = new VistaArbitro();
            va.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? DPI = buscar_id();
            arbitrosContext.eliminar_arbitro(DPI);
            this.Hide();
            VistaArbitro va = new VistaArbitro();
            va.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloLetras(e);
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloLetras(e);
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloNumeros(e);
        }

        private void txtNacionalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloLetras(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menucontrol m = new Menucontrol();
            m.Show();
        }

        private void txt_pago_alquiler_arbitro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validando que sean solo numeros decimales y numneros enteros
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Agregar solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
