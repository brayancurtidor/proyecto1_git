﻿
namespace Administracion_Torneos.Vista
{
    partial class ViewCambio
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
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Tiempo_entrada = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.listCambios = new System.Windows.Forms.DataGridView();
            this.entrada = new System.Windows.Forms.ComboBox();
            this.salida = new System.Windows.Forms.ComboBox();
            this.lblEntra = new System.Windows.Forms.Label();
            this.lblSale = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTorneo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbEquipos = new System.Windows.Forms.ComboBox();
            this.txtJuego = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listCambios)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(495, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 30);
            this.button1.TabIndex = 41;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Tiempo Salida";
            // 
            // Tiempo_entrada
            // 
            this.Tiempo_entrada.AutoSize = true;
            this.Tiempo_entrada.Location = new System.Drawing.Point(52, 161);
            this.Tiempo_entrada.Name = "Tiempo_entrada";
            this.Tiempo_entrada.Size = new System.Drawing.Size(82, 13);
            this.Tiempo_entrada.TabIndex = 38;
            this.Tiempo_entrada.Text = "Tiempo Entrada";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Jugador Salida";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(153, 123);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 35;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = " Jugador Entrada";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(153, 85);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 32;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // listCambios
            // 
            this.listCambios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listCambios.Location = new System.Drawing.Point(19, 246);
            this.listCambios.Name = "listCambios";
            this.listCambios.Size = new System.Drawing.Size(760, 191);
            this.listCambios.TabIndex = 45;
            // 
            // entrada
            // 
            this.entrada.FormattingEnabled = true;
            this.entrada.Location = new System.Drawing.Point(153, 161);
            this.entrada.Name = "entrada";
            this.entrada.Size = new System.Drawing.Size(121, 21);
            this.entrada.TabIndex = 50;
            // 
            // salida
            // 
            this.salida.FormattingEnabled = true;
            this.salida.Location = new System.Drawing.Point(153, 207);
            this.salida.Name = "salida";
            this.salida.Size = new System.Drawing.Size(121, 21);
            this.salida.TabIndex = 52;
            // 
            // lblEntra
            // 
            this.lblEntra.AutoSize = true;
            this.lblEntra.Location = new System.Drawing.Point(280, 93);
            this.lblEntra.Name = "lblEntra";
            this.lblEntra.Size = new System.Drawing.Size(10, 13);
            this.lblEntra.TabIndex = 34;
            this.lblEntra.Text = "-";
            this.lblEntra.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblSale
            // 
            this.lblSale.AutoSize = true;
            this.lblSale.Location = new System.Drawing.Point(280, 131);
            this.lblSale.Name = "lblSale";
            this.lblSale.Size = new System.Drawing.Size(10, 13);
            this.lblSale.TabIndex = 44;
            this.lblSale.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "id_juego";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(357, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 59;
            this.label7.Text = "Torneo";
            // 
            // txtTorneo
            // 
            this.txtTorneo.Location = new System.Drawing.Point(412, 8);
            this.txtTorneo.Name = "txtTorneo";
            this.txtTorneo.Size = new System.Drawing.Size(107, 20);
            this.txtTorneo.TabIndex = 56;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "Equipo";
            // 
            // cbEquipos
            // 
            this.cbEquipos.FormattingEnabled = true;
            this.cbEquipos.Location = new System.Drawing.Point(153, 47);
            this.cbEquipos.Name = "cbEquipos";
            this.cbEquipos.Size = new System.Drawing.Size(121, 21);
            this.cbEquipos.TabIndex = 60;
            this.cbEquipos.SelectedIndexChanged += new System.EventHandler(this.cbEquipos_SelectedIndexChanged);
            // 
            // txtJuego
            // 
            this.txtJuego.Location = new System.Drawing.Point(153, 8);
            this.txtJuego.Name = "txtJuego";
            this.txtJuego.Size = new System.Drawing.Size(118, 20);
            this.txtJuego.TabIndex = 62;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(495, 117);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 30);
            this.button2.TabIndex = 63;
            this.button2.Text = "Seleccionar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(598, 117);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(73, 30);
            this.button3.TabIndex = 64;
            this.button3.Text = "Modificar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(495, 180);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(73, 30);
            this.button4.TabIndex = 65;
            this.button4.Text = "Eliminar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // ViewCambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 455);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtJuego);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbEquipos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTorneo);
            this.Controls.Add(this.salida);
            this.Controls.Add(this.entrada);
            this.Controls.Add(this.listCambios);
            this.Controls.Add(this.lblSale);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Tiempo_entrada);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.lblEntra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Name = "ViewCambio";
            this.Text = "ViewCambio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewCambio_FormClosing);
            this.Load += new System.EventHandler(this.ViewCambio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listCambios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Tiempo_entrada;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        public System.Windows.Forms.DataGridView listCambios;
        private System.Windows.Forms.ComboBox entrada;
        private System.Windows.Forms.ComboBox salida;
        private System.Windows.Forms.Label lblEntra;
        private System.Windows.Forms.Label lblSale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTorneo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbEquipos;
        private System.Windows.Forms.TextBox txtJuego;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}