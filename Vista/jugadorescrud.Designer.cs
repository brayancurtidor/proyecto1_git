﻿
namespace Administracion_Torneos.Vista
{
    partial class jugadorescrud
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.eliminar = new System.Windows.Forms.Button();
            this.editar = new System.Windows.Forms.Button();
            this.listjugadores = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.txtapellido = new System.Windows.Forms.TextBox();
            this.correo = new System.Windows.Forms.TextBox();
            this.tel = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txtdireccion = new System.Windows.Forms.TextBox();
            this.fecha_nac = new System.Windows.Forms.DateTimePicker();
            this.nacionalidad = new System.Windows.Forms.ComboBox();
            this.Guardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listjugadores)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.eliminar);
            this.groupBox1.Controls.Add(this.editar);
            this.groupBox1.Controls.Add(this.listjugadores);
            this.groupBox1.Location = new System.Drawing.Point(52, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(947, 315);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de jugadores";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // eliminar
            // 
            this.eliminar.Location = new System.Drawing.Point(505, 246);
            this.eliminar.Margin = new System.Windows.Forms.Padding(4);
            this.eliminar.Name = "eliminar";
            this.eliminar.Size = new System.Drawing.Size(133, 50);
            this.eliminar.TabIndex = 19;
            this.eliminar.Text = "Eliminar";
            this.eliminar.UseVisualStyleBackColor = true;
            this.eliminar.Click += new System.EventHandler(this.eliminar_Click);
            // 
            // editar
            // 
            this.editar.Location = new System.Drawing.Point(268, 246);
            this.editar.Margin = new System.Windows.Forms.Padding(4);
            this.editar.Name = "editar";
            this.editar.Size = new System.Drawing.Size(140, 50);
            this.editar.TabIndex = 18;
            this.editar.Text = "Editar";
            this.editar.UseVisualStyleBackColor = true;
            this.editar.Click += new System.EventHandler(this.button1_Click);
            // 
            // listjugadores
            // 
            this.listjugadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listjugadores.Location = new System.Drawing.Point(20, 25);
            this.listjugadores.Margin = new System.Windows.Forms.Padding(4);
            this.listjugadores.Name = "listjugadores";
            this.listjugadores.RowHeadersWidth = 51;
            this.listjugadores.Size = new System.Drawing.Size(905, 203);
            this.listjugadores.TabIndex = 0;
            this.listjugadores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listjugadores_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 370);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Identificacion ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 430);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombres ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 479);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Apellidos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 375);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "fecha de Nacimiento ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(345, 430);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Direccion ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(352, 479);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Nacionalidad/Pais";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(671, 375);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Correo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(671, 430);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Telefono";
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(135, 426);
            this.txtnombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(191, 22);
            this.txtnombre.TabIndex = 9;
            // 
            // txtapellido
            // 
            this.txtapellido.Location = new System.Drawing.Point(135, 475);
            this.txtapellido.Margin = new System.Windows.Forms.Padding(4);
            this.txtapellido.Name = "txtapellido";
            this.txtapellido.Size = new System.Drawing.Size(191, 22);
            this.txtapellido.TabIndex = 10;
            // 
            // correo
            // 
            this.correo.Location = new System.Drawing.Point(729, 372);
            this.correo.Margin = new System.Windows.Forms.Padding(4);
            this.correo.Name = "correo";
            this.correo.Size = new System.Drawing.Size(191, 22);
            this.correo.TabIndex = 11;
            // 
            // tel
            // 
            this.tel.Location = new System.Drawing.Point(744, 430);
            this.tel.Margin = new System.Windows.Forms.Padding(4);
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(191, 22);
            this.tel.TabIndex = 12;
            this.tel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tel_KeyPress);
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(135, 367);
            this.txtid.Margin = new System.Windows.Forms.Padding(4);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(192, 22);
            this.txtid.TabIndex = 13;
            this.txtid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtid_KeyPress);
            // 
            // txtdireccion
            // 
            this.txtdireccion.Location = new System.Drawing.Point(445, 426);
            this.txtdireccion.Margin = new System.Windows.Forms.Padding(4);
            this.txtdireccion.Name = "txtdireccion";
            this.txtdireccion.Size = new System.Drawing.Size(191, 22);
            this.txtdireccion.TabIndex = 14;
            // 
            // fecha_nac
            // 
            this.fecha_nac.Location = new System.Drawing.Point(485, 372);
            this.fecha_nac.Margin = new System.Windows.Forms.Padding(4);
            this.fecha_nac.Name = "fecha_nac";
            this.fecha_nac.Size = new System.Drawing.Size(175, 22);
            this.fecha_nac.TabIndex = 15;
            this.fecha_nac.ValueChanged += new System.EventHandler(this.fecha_nac_ValueChanged);
            // 
            // nacionalidad
            // 
            this.nacionalidad.FormattingEnabled = true;
            this.nacionalidad.Items.AddRange(new object[] {
            " Afganistán",
            "Albania",
            "Alemania",
            "Andorra",
            "Angola",
            "Antigua y Barbuda",
            "Arabia Saudita",
            "Argelia",
            "Argentina",
            "Armenia",
            "Australia",
            "Austria",
            "Azerbaiyán",
            "Bahamas",
            "Bangladés",
            "Barbados",
            "Baréin",
            "Bélgica",
            "Belice",
            "Benín",
            "Bielorrusia",
            "Birmania",
            "Bolivia",
            "Bosnia y Herzegovina",
            "Botsuana",
            "Brasil",
            "Brunéi",
            "Bulgaria",
            "Burkina Faso",
            "Burundi",
            "Bután",
            "Cabo Verde",
            "Camboya",
            "Camerún",
            "Canadá",
            "Catar",
            "Chad",
            "Chile",
            "China",
            "Chipre",
            "Ciudad del Vaticano",
            "Colombia",
            "Comoras",
            "Corea del Norte",
            "Corea del Sur",
            "Costa de Marfil",
            "Costa Rica",
            "Croacia",
            "Cuba",
            "Dinamarca",
            "Dominica",
            "Ecuador",
            "Egipto",
            "El Salvador",
            "Emiratos Árabes Unidos",
            "Eritrea",
            "Eslovaquia",
            "Eslovenia",
            "España",
            "Estados Unidos",
            "Estonia",
            "Etiopía",
            "Filipinas",
            "Finlandia",
            "Fiyi",
            "Francia",
            "Gabón",
            "Gambia",
            "Georgia",
            "Ghana",
            "Granada",
            "Grecia",
            "Guatemala",
            "Guyana",
            "Guinea",
            "Guinea ecuatorial",
            "Guinea-Bisáu",
            "Haití",
            "Honduras",
            "Hungría",
            "India",
            "Indonesia",
            "Irak",
            "Irán",
            "Irlanda",
            "Islandia",
            "Islas Marshall",
            "Islas Salomón",
            "Israel",
            "Italia",
            "Jamaica",
            "Japón",
            "Jordania",
            "Kazajistán",
            "Kenia",
            "Kirguistán",
            "Kiribati",
            "Kuwait",
            "Laos",
            "Lesoto",
            "Letonia",
            "Líbano",
            "Liberia",
            "Libia",
            "Liechtenstein",
            "Lituania",
            "Luxemburgo",
            "Macedonia del Norte",
            "Madagascar",
            "Malasia",
            "Malaui",
            "Maldivas",
            "Malí",
            "Malta",
            "Marruecos",
            "Mauricio",
            "Mauritania",
            "México",
            "Micronesia",
            "Moldavia",
            "Mónaco",
            "Mongolia",
            "Montenegro",
            "Mozambique",
            "Namibia",
            "Nauru",
            "Nepal",
            "Nicaragua",
            "Níger",
            "Nigeria",
            "Noruega",
            "Nueva Zelanda",
            "Omán",
            "Países Bajos",
            "Pakistán",
            "Palaos",
            "Panamá",
            "Papúa Nueva Guinea",
            "Paraguay",
            "Perú",
            "Polonia",
            "Portugal",
            "Reino Unido",
            "República Centroafricana",
            "República Checa",
            "República del Congo",
            "República Democrática del Congo",
            "República Dominicana",
            "Ruanda",
            "Rumanía",
            "Rusia",
            "Samoa",
            "San Cristóbal y Nieves",
            "San Marino",
            "San Vicente y las Granadinas",
            "Santa Lucía",
            "Santo Tomé y Príncipe",
            "Senegal",
            "Serbia",
            "Seychelles",
            "Sierra Leona",
            "Singapur",
            "Siria",
            "Somalia",
            "Sri Lanka",
            "Suazilandia",
            "Sudáfrica",
            "Sudán",
            "Sudán del Sur",
            "Suecia",
            "Suiza",
            "Surinam",
            "Tailandia",
            "Tanzania",
            "Tayikistán",
            "Timor Oriental",
            "Togo",
            "Tonga",
            "Trinidad y Tobago",
            "Túnez",
            "Turkmenistán",
            "Turquía",
            "Tuvalu",
            "Ucrania",
            "Uganda",
            "Uruguay",
            "Uzbekistán",
            "Vanuatu",
            "Venezuela",
            "Vietnam",
            "Yemen",
            "Yibuti",
            "Zambia",
            "Zimbabue"});
            this.nacionalidad.Location = new System.Drawing.Point(520, 475);
            this.nacionalidad.Margin = new System.Windows.Forms.Padding(4);
            this.nacionalidad.Name = "nacionalidad";
            this.nacionalidad.Size = new System.Drawing.Size(169, 24);
            this.nacionalidad.TabIndex = 16;
            // 
            // Guardar
            // 
            this.Guardar.Location = new System.Drawing.Point(729, 475);
            this.Guardar.Margin = new System.Windows.Forms.Padding(4);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(119, 30);
            this.Guardar.TabIndex = 17;
            this.Guardar.Text = "Guardar";
            this.Guardar.UseVisualStyleBackColor = true;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // jugadorescrud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1053, 554);
            this.Controls.Add(this.Guardar);
            this.Controls.Add(this.nacionalidad);
            this.Controls.Add(this.fecha_nac);
            this.Controls.Add(this.txtdireccion);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.tel);
            this.Controls.Add(this.correo);
            this.Controls.Add(this.txtapellido);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "jugadorescrud";
            this.Text = "jugadorescrud";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.jugadorescrud_FormClosing);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listjugadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView listjugadores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.TextBox txtapellido;
        private System.Windows.Forms.TextBox correo;
        private System.Windows.Forms.TextBox tel;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.TextBox txtdireccion;
        private System.Windows.Forms.DateTimePicker fecha_nac;
        private System.Windows.Forms.ComboBox nacionalidad;
        private System.Windows.Forms.Button Guardar;
        private System.Windows.Forms.Button eliminar;
        private System.Windows.Forms.Button editar;
    }
}