﻿
namespace Administracion_Torneos.Vista
{
    partial class controlgoles
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
            this.listagoles = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TipoL = new System.Windows.Forms.ComboBox();
            this.tlocal = new System.Windows.Forms.ComboBox();
            this.jlocal = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TipoV = new System.Windows.Forms.ComboBox();
            this.tiempoV = new System.Windows.Forms.ComboBox();
            this.jvisita = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listagoles)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listagoles);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 165);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista ";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // listagoles
            // 
            this.listagoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listagoles.Location = new System.Drawing.Point(11, 19);
            this.listagoles.Name = "listagoles";
            this.listagoles.Size = new System.Drawing.Size(480, 136);
            this.listagoles.TabIndex = 0;
            this.listagoles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.TipoL);
            this.groupBox2.Controls.Add(this.tlocal);
            this.groupBox2.Controls.Add(this.jlocal);
            this.groupBox2.Location = new System.Drawing.Point(13, 222);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 200);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Local";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 25);
            this.button1.TabIndex = 10;
            this.button1.Text = "Guardar Goles Local";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "tipo ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "minuto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Jugador";
            // 
            // TipoL
            // 
            this.TipoL.FormattingEnabled = true;
            this.TipoL.Items.AddRange(new object[] {
            "Penal ",
            "Normal"});
            this.TipoL.Location = new System.Drawing.Point(113, 113);
            this.TipoL.Name = "TipoL";
            this.TipoL.Size = new System.Drawing.Size(121, 21);
            this.TipoL.TabIndex = 4;
            // 
            // tlocal
            // 
            this.tlocal.FormattingEnabled = true;
            this.tlocal.Location = new System.Drawing.Point(113, 74);
            this.tlocal.Name = "tlocal";
            this.tlocal.Size = new System.Drawing.Size(121, 21);
            this.tlocal.TabIndex = 1;
            // 
            // jlocal
            // 
            this.jlocal.FormattingEnabled = true;
            this.jlocal.Location = new System.Drawing.Point(71, 37);
            this.jlocal.Name = "jlocal";
            this.jlocal.Size = new System.Drawing.Size(163, 21);
            this.jlocal.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.TipoV);
            this.groupBox3.Controls.Add(this.tiempoV);
            this.groupBox3.Controls.Add(this.jvisita);
            this.groupBox3.Location = new System.Drawing.Point(270, 222);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(249, 200);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Visitante";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 157);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 25);
            this.button2.TabIndex = 11;
            this.button2.Text = "Guardar Goles Visita";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "tipo ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "minuto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Jugador";
            // 
            // TipoV
            // 
            this.TipoV.FormattingEnabled = true;
            this.TipoV.Items.AddRange(new object[] {
            "Penal ",
            "Normal"});
            this.TipoV.Location = new System.Drawing.Point(112, 116);
            this.TipoV.Name = "TipoV";
            this.TipoV.Size = new System.Drawing.Size(121, 21);
            this.TipoV.TabIndex = 3;
            // 
            // tiempoV
            // 
            this.tiempoV.FormattingEnabled = true;
            this.tiempoV.Location = new System.Drawing.Point(112, 74);
            this.tiempoV.Name = "tiempoV";
            this.tiempoV.Size = new System.Drawing.Size(121, 21);
            this.tiempoV.TabIndex = 2;
            // 
            // jvisita
            // 
            this.jvisita.FormattingEnabled = true;
            this.jvisita.Location = new System.Drawing.Point(70, 37);
            this.jvisita.Name = "jvisita";
            this.jvisita.Size = new System.Drawing.Size(163, 21);
            this.jvisita.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(182, 428);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 25);
            this.button3.TabIndex = 11;
            this.button3.Text = "regresar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(126, 183);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(139, 25);
            this.button4.TabIndex = 12;
            this.button4.Text = "Seleccionar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(140, 157);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(76, 25);
            this.button5.TabIndex = 11;
            this.button5.Text = "Modifcar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(128, 157);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(76, 25);
            this.button6.TabIndex = 12;
            this.button6.Text = "Modifcar";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // controlgoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(531, 484);
            this.ControlBox = false;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "controlgoles";
            this.Text = "controlgoles";
            this.Load += new System.EventHandler(this.controlgoles_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listagoles)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox TipoL;
        private System.Windows.Forms.ComboBox tlocal;
        private System.Windows.Forms.ComboBox jlocal;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox TipoV;
        private System.Windows.Forms.ComboBox tiempoV;
        private System.Windows.Forms.ComboBox jvisita;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView listagoles;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}