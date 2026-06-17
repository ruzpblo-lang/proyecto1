namespace Proyecto
{
    partial class FormBusquedaPuesto
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
            this.cmbbusqueda = new System.Windows.Forms.ComboBox();
            this.dgvDepartamentos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbbusqueda
            // 
            this.cmbbusqueda.FormattingEnabled = true;
            this.cmbbusqueda.Location = new System.Drawing.Point(226, 54);
            this.cmbbusqueda.Name = "cmbbusqueda";
            this.cmbbusqueda.Size = new System.Drawing.Size(416, 28);
            this.cmbbusqueda.TabIndex = 0;
            this.cmbbusqueda.SelectedIndexChanged += new System.EventHandler(this.cmbbusqueda_SelectedIndexChanged);
            // 
            // dgvDepartamentos
            // 
            this.dgvDepartamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartamentos.Location = new System.Drawing.Point(24, 107);
            this.dgvDepartamentos.Name = "dgvDepartamentos";
            this.dgvDepartamentos.RowHeadersWidth = 62;
            this.dgvDepartamentos.RowTemplate.Height = 28;
            this.dgvDepartamentos.Size = new System.Drawing.Size(847, 389);
            this.dgvDepartamentos.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "selecciona departamento";
            // 
            // FormBusquedaDepartamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 550);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDepartamentos);
            this.Controls.Add(this.cmbbusqueda);
            this.Name = "FormBusquedaDepartamento";
            this.Text = "FormBusquedaDepartamento";
            this.Load += new System.EventHandler(this.FormBusquedaDepartamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbbusqueda;
        private System.Windows.Forms.DataGridView dgvDepartamentos;
        private System.Windows.Forms.Label label1;
    }
}