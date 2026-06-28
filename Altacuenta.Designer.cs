namespace Proyecto
{
    partial class Altacuenta
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
            this.cmbcliente = new System.Windows.Forms.ComboBox();
            this.cmbtipocuenta = new System.Windows.Forms.ComboBox();
            this.txtsaldo = new System.Windows.Forms.TextBox();
            this.btnagregar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbcliente
            // 
            this.cmbcliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcliente.FormattingEnabled = true;
            this.cmbcliente.Location = new System.Drawing.Point(52, 28);
            this.cmbcliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbcliente.Name = "cmbcliente";
            this.cmbcliente.Size = new System.Drawing.Size(160, 24);
            this.cmbcliente.TabIndex = 0;
            // 
            // cmbtipocuenta
            // 
            this.cmbtipocuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtipocuenta.FormattingEnabled = true;
            this.cmbtipocuenta.Location = new System.Drawing.Point(52, 73);
            this.cmbtipocuenta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbtipocuenta.Name = "cmbtipocuenta";
            this.cmbtipocuenta.Size = new System.Drawing.Size(160, 24);
            this.cmbtipocuenta.TabIndex = 1;
            // 
            // txtsaldo
            // 
            this.txtsaldo.Location = new System.Drawing.Point(52, 140);
            this.txtsaldo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtsaldo.Name = "txtsaldo";
            this.txtsaldo.Size = new System.Drawing.Size(132, 22);
            this.txtsaldo.TabIndex = 2;
            // 
            // btnagregar
            // 
            this.btnagregar.Location = new System.Drawing.Point(52, 188);
            this.btnagregar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(100, 28);
            this.btnagregar.TabIndex = 3;
            this.btnagregar.Text = "agregar";
            this.btnagregar.UseVisualStyleBackColor = true;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // Altacuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 554);
            this.Controls.Add(this.btnagregar);
            this.Controls.Add(this.txtsaldo);
            this.Controls.Add(this.cmbtipocuenta);
            this.Controls.Add(this.cmbcliente);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Altacuenta";
            this.Text = "Altacuenta";
            this.Load += new System.EventHandler(this.Altacuenta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbcliente;
        private System.Windows.Forms.ComboBox cmbtipocuenta;
        private System.Windows.Forms.TextBox txtsaldo;
        private System.Windows.Forms.Button btnagregar;
    }
}