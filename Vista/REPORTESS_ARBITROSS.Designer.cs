
namespace Administracion_Torneos.Vista
{
    partial class REPORTESS_ARBITROSS
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
            this.listArbitros = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listArbitros)).BeginInit();
            this.SuspendLayout();
            // 
            // listArbitros
            // 
            this.listArbitros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listArbitros.Location = new System.Drawing.Point(41, 209);
            this.listArbitros.Margin = new System.Windows.Forms.Padding(4);
            this.listArbitros.Name = "listArbitros";
            this.listArbitros.RowHeadersWidth = 51;
            this.listArbitros.Size = new System.Drawing.Size(704, 235);
            this.listArbitros.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(203, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(327, 46);
            this.label4.TabIndex = 18;
            this.label4.Text = "Reporte Arbitros";
            // 
            // REPORTESS_ARBITROSS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 534);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listArbitros);
            this.Name = "REPORTESS_ARBITROSS";
            this.Text = "REPORTESS_ARBITROSS";
            this.Load += new System.EventHandler(this.REPORTESS_ARBITROSS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listArbitros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView listArbitros;
        private System.Windows.Forms.Label label4;
    }
}