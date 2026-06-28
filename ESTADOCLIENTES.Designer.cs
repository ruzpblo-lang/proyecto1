namespace Proyecto
{
    partial class ESTADO_CLIENTES
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
            this.dgvpersonal = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpersonal)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvpersonal
            // 
            this.dgvpersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpersonal.Location = new System.Drawing.Point(61, 71);
            this.dgvpersonal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvpersonal.Name = "dgvpersonal";
            this.dgvpersonal.ReadOnly = true;
            this.dgvpersonal.RowHeadersWidth = 51;
            this.dgvpersonal.Size = new System.Drawing.Size(947, 416);
            this.dgvpersonal.TabIndex = 0;
            // 
            // ESTADO_CLIENTES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.dgvpersonal);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ESTADO_CLIENTES";
            this.Text = "ESTADO_CLIENTES";
            this.Load += new System.EventHandler(this.ESTADO_CLIENTES_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvpersonal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvpersonal;
    }
}