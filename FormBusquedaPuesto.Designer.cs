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
            this.cmbbusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbusqueda.FormattingEnabled = true;
            this.cmbbusqueda.Location = new System.Drawing.Point(201, 43);
            this.cmbbusqueda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbbusqueda.Name = "cmbbusqueda";
            this.cmbbusqueda.Size = new System.Drawing.Size(370, 24);
            this.cmbbusqueda.TabIndex = 0;
            this.cmbbusqueda.SelectedIndexChanged += new System.EventHandler(this.cmbbusqueda_SelectedIndexChanged);
            // 
            // dgvDepartamentos
            // 
            this.dgvDepartamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartamentos.Location = new System.Drawing.Point(21, 86);
            this.dgvDepartamentos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDepartamentos.Name = "dgvDepartamentos";
            this.dgvDepartamentos.ReadOnly = true;
            this.dgvDepartamentos.RowHeadersWidth = 62;
            this.dgvDepartamentos.RowTemplate.Height = 28;
            this.dgvDepartamentos.Size = new System.Drawing.Size(753, 311);
            this.dgvDepartamentos.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "selecciona departamento";
            // 
            // FormBusquedaPuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 440);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDepartamentos);
            this.Controls.Add(this.cmbbusqueda);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormBusquedaPuesto";
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