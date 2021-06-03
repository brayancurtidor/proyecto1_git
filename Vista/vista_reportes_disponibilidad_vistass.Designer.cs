
namespace Administracion_Torneos.Vista
{
    partial class vista_reportes_disponibilidad_vistass
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_fin_jornada = new System.Windows.Forms.TextBox();
            this.txt_inicio_domingos = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_fin_domingos = new System.Windows.Forms.TextBox();
            this.txt_inicio_jornada = new System.Windows.Forms.TextBox();
            this.txt_inicio_sabado = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_fin_sabado = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(147, 126);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(446, 126);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(147, 80);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Desde ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(387, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "seleccione canchas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(310, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Reporte_disponibilidad de canchas";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(303, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 50);
            this.button1.TabIndex = 7;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 498);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(480, 196);
            this.dataGridView1.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(846, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 17);
            this.label11.TabIndex = 36;
            this.label11.Text = "Lunes - Viernes";
            // 
            // txt_fin_jornada
            // 
            this.txt_fin_jornada.Location = new System.Drawing.Point(917, 59);
            this.txt_fin_jornada.Name = "txt_fin_jornada";
            this.txt_fin_jornada.Size = new System.Drawing.Size(100, 22);
            this.txt_fin_jornada.TabIndex = 31;
            // 
            // txt_inicio_domingos
            // 
            this.txt_inicio_domingos.Location = new System.Drawing.Point(795, 204);
            this.txt_inicio_domingos.Name = "txt_inicio_domingos";
            this.txt_inicio_domingos.Size = new System.Drawing.Size(100, 22);
            this.txt_inicio_domingos.TabIndex = 34;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(863, 102);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 17);
            this.label12.TabIndex = 37;
            this.label12.Text = "sabados";
            // 
            // txt_fin_domingos
            // 
            this.txt_fin_domingos.Location = new System.Drawing.Point(922, 204);
            this.txt_fin_domingos.Name = "txt_fin_domingos";
            this.txt_fin_domingos.Size = new System.Drawing.Size(100, 22);
            this.txt_fin_domingos.TabIndex = 35;
            // 
            // txt_inicio_jornada
            // 
            this.txt_inicio_jornada.Location = new System.Drawing.Point(791, 59);
            this.txt_inicio_jornada.Name = "txt_inicio_jornada";
            this.txt_inicio_jornada.Size = new System.Drawing.Size(100, 22);
            this.txt_inicio_jornada.TabIndex = 30;
            // 
            // txt_inicio_sabado
            // 
            this.txt_inicio_sabado.Location = new System.Drawing.Point(792, 128);
            this.txt_inicio_sabado.Name = "txt_inicio_sabado";
            this.txt_inicio_sabado.Size = new System.Drawing.Size(100, 22);
            this.txt_inicio_sabado.TabIndex = 32;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(863, 184);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 17);
            this.label13.TabIndex = 38;
            this.label13.Text = "Domingos";
            // 
            // txt_fin_sabado
            // 
            this.txt_fin_sabado.Location = new System.Drawing.Point(919, 128);
            this.txt_fin_sabado.Name = "txt_fin_sabado";
            this.txt_fin_sabado.Size = new System.Drawing.Size(100, 22);
            this.txt_fin_sabado.TabIndex = 33;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(560, 296);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(480, 196);
            this.dataGridView2.TabIndex = 39;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(31, 296);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(480, 196);
            this.dataGridView3.TabIndex = 40;
            // 
            // vista_reportes_disponibilidad_vistass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 699);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_fin_jornada);
            this.Controls.Add(this.txt_inicio_domingos);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt_fin_domingos);
            this.Controls.Add(this.txt_inicio_jornada);
            this.Controls.Add(this.txt_inicio_sabado);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txt_fin_sabado);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "vista_reportes_disponibilidad_vistass";
            this.Text = "vista_reportes_disponibilidad_vistass";
            this.Load += new System.EventHandler(this.vista_reportes_disponibilidad_vistass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_fin_jornada;
        private System.Windows.Forms.TextBox txt_inicio_domingos;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_fin_domingos;
        private System.Windows.Forms.TextBox txt_inicio_jornada;
        private System.Windows.Forms.TextBox txt_inicio_sabado;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_fin_sabado;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
    }
}