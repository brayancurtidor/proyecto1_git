﻿
namespace Administracion_Torneos.Vista
{
    partial class ReporteEstadisticasEquipo
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
            this.label3 = new System.Windows.Forms.Label();
            this.cbxEquipo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxTorneo = new System.Windows.Forms.ComboBox();
            this.listUtilidades = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listUtilidades)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ESTADÍSTICAS DEL EQUIPO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Equipo";
            // 
            // cbxEquipo
            // 
            this.cbxEquipo.Enabled = false;
            this.cbxEquipo.FormattingEnabled = true;
            this.cbxEquipo.Location = new System.Drawing.Point(356, 60);
            this.cbxEquipo.Name = "cbxEquipo";
            this.cbxEquipo.Size = new System.Drawing.Size(121, 21);
            this.cbxEquipo.TabIndex = 3;
            this.cbxEquipo.SelectedIndexChanged += new System.EventHandler(this.cbxEquipo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Torneo";
            // 
            // cbxTorneo
            // 
            this.cbxTorneo.FormattingEnabled = true;
            this.cbxTorneo.Location = new System.Drawing.Point(160, 60);
            this.cbxTorneo.Name = "cbxTorneo";
            this.cbxTorneo.Size = new System.Drawing.Size(121, 21);
            this.cbxTorneo.TabIndex = 6;
            this.cbxTorneo.SelectedIndexChanged += new System.EventHandler(this.cbxTorneo_SelectedIndexChanged);
            // 
            // listUtilidades
            // 
            this.listUtilidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listUtilidades.Location = new System.Drawing.Point(23, 104);
            this.listUtilidades.Name = "listUtilidades";
            this.listUtilidades.Size = new System.Drawing.Size(673, 216);
            this.listUtilidades.TabIndex = 7;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(591, 58);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 23);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // ReporteEstadisticasEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(721, 345);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.listUtilidades);
            this.Controls.Add(this.cbxTorneo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxEquipo);
            this.Controls.Add(this.label1);
            this.Name = "ReporteEstadisticasEquipo";
            this.Text = "Reporte Estadísticas del Equipo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReporteEstadisticasEquipo_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.listUtilidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxEquipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxTorneo;
        private System.Windows.Forms.DataGridView listUtilidades;
        private System.Windows.Forms.Button btnBuscar;
    }
}