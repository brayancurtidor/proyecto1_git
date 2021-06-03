
namespace Administracion_Torneos.Vista
{
    partial class Crud_usuarios
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_dpi = new System.Windows.Forms.TextBox();
            this.txt_nombres = new System.Windows.Forms.TextBox();
            this.txt_apellidos = new System.Windows.Forms.TextBox();
            this.txt_telefono = new System.Windows.Forms.TextBox();
            this.txt_direccion = new System.Windows.Forms.TextBox();
            this.txt_correo = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_actualizar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txt_contra = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmb_activo = new System.Windows.Forms.ComboBox();
            this.txt_rol_usuario = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(354, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Creacion de nuevos usuarios";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "DPI Usuario";
            // 
            // txt_dpi
            // 
            this.txt_dpi.Location = new System.Drawing.Point(53, 140);
            this.txt_dpi.Name = "txt_dpi";
            this.txt_dpi.Size = new System.Drawing.Size(100, 22);
            this.txt_dpi.TabIndex = 2;
            this.txt_dpi.TextChanged += new System.EventHandler(this.txt_dpi_TextChanged);
            this.txt_dpi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_dpi_KeyPress);
            // 
            // txt_nombres
            // 
            this.txt_nombres.Location = new System.Drawing.Point(243, 140);
            this.txt_nombres.Name = "txt_nombres";
            this.txt_nombres.Size = new System.Drawing.Size(100, 22);
            this.txt_nombres.TabIndex = 3;
            this.txt_nombres.TextChanged += new System.EventHandler(this.txt_nombres_TextChanged);
            this.txt_nombres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_nombres_KeyPress);
            // 
            // txt_apellidos
            // 
            this.txt_apellidos.Location = new System.Drawing.Point(455, 140);
            this.txt_apellidos.Name = "txt_apellidos";
            this.txt_apellidos.Size = new System.Drawing.Size(100, 22);
            this.txt_apellidos.TabIndex = 4;
            this.txt_apellidos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_apellidos_KeyPress);
            // 
            // txt_telefono
            // 
            this.txt_telefono.Location = new System.Drawing.Point(629, 140);
            this.txt_telefono.Name = "txt_telefono";
            this.txt_telefono.Size = new System.Drawing.Size(100, 22);
            this.txt_telefono.TabIndex = 5;
            this.txt_telefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_telefono_KeyPress);
            // 
            // txt_direccion
            // 
            this.txt_direccion.Location = new System.Drawing.Point(792, 140);
            this.txt_direccion.Name = "txt_direccion";
            this.txt_direccion.Size = new System.Drawing.Size(100, 22);
            this.txt_direccion.TabIndex = 6;
            // 
            // txt_correo
            // 
            this.txt_correo.Location = new System.Drawing.Point(53, 215);
            this.txt_correo.Name = "txt_correo";
            this.txt_correo.Size = new System.Drawing.Size(100, 22);
            this.txt_correo.TabIndex = 7;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Administrador",
            "Operador",
            "Reportes"});
            this.comboBox1.Location = new System.Drawing.Point(455, 213);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Text = "Seleccione una opcion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nombres usuarios";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(458, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Apellido Usuarios";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(659, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Telefono";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(818, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Direccion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Correo electronico";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(453, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Puesto de trabajo";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 276);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(914, 201);
            this.dataGridView1.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 499);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 50);
            this.button1.TabIndex = 16;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_actualizar
            // 
            this.btn_actualizar.Location = new System.Drawing.Point(318, 499);
            this.btn_actualizar.Name = "btn_actualizar";
            this.btn_actualizar.Size = new System.Drawing.Size(87, 50);
            this.btn_actualizar.TabIndex = 17;
            this.btn_actualizar.Text = "Actualizar";
            this.btn_actualizar.UseVisualStyleBackColor = true;
            this.btn_actualizar.Click += new System.EventHandler(this.btn_actualizar_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(528, 499);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 50);
            this.button3.TabIndex = 18;
            this.button3.Text = "Desactivar Usuario";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txt_contra
            // 
            this.txt_contra.Location = new System.Drawing.Point(629, 211);
            this.txt_contra.Name = "txt_contra";
            this.txt_contra.Size = new System.Drawing.Size(100, 22);
            this.txt_contra.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(635, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "contraseña";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(810, 191);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 17);
            this.label10.TabIndex = 24;
            this.label10.Text = "Activo";
            // 
            // cmb_activo
            // 
            this.cmb_activo.FormattingEnabled = true;
            this.cmb_activo.Items.AddRange(new object[] {
            "S",
            "N"});
            this.cmb_activo.Location = new System.Drawing.Point(792, 209);
            this.cmb_activo.Name = "cmb_activo";
            this.cmb_activo.Size = new System.Drawing.Size(121, 24);
            this.cmb_activo.TabIndex = 25;
            this.cmb_activo.Text = "Seleccione una opcion";
            // 
            // txt_rol_usuario
            // 
            this.txt_rol_usuario.Location = new System.Drawing.Point(234, 217);
            this.txt_rol_usuario.Name = "txt_rol_usuario";
            this.txt_rol_usuario.Size = new System.Drawing.Size(100, 22);
            this.txt_rol_usuario.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(240, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 17);
            this.label11.TabIndex = 26;
            this.label11.Text = "ROL";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(840, 509);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 50);
            this.button2.TabIndex = 28;
            this.button2.Text = "Regresar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Crud_usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(976, 571);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txt_rol_usuario);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmb_activo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_contra);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btn_actualizar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txt_correo);
            this.Controls.Add(this.txt_direccion);
            this.Controls.Add(this.txt_telefono);
            this.Controls.Add(this.txt_apellidos);
            this.Controls.Add(this.txt_nombres);
            this.Controls.Add(this.txt_dpi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Crud_usuarios";
            this.Text = "Crud_usuarios";
            this.Load += new System.EventHandler(this.Crud_usuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_dpi;
        private System.Windows.Forms.TextBox txt_nombres;
        private System.Windows.Forms.TextBox txt_apellidos;
        private System.Windows.Forms.TextBox txt_telefono;
        private System.Windows.Forms.TextBox txt_direccion;
        private System.Windows.Forms.TextBox txt_correo;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_actualizar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txt_contra;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmb_activo;
        private System.Windows.Forms.TextBox txt_rol_usuario;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
    }
}