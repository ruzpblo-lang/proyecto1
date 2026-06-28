namespace Proyecto
{
    partial class GerenteCitas
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
            this.cmbAsistentes = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cmbHoras = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 166);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "btn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbAsistentes
            // 
            this.cmbAsistentes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAsistentes.FormattingEnabled = true;
            this.cmbAsistentes.Location = new System.Drawing.Point(21, 10);
            this.cmbAsistentes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbAsistentes.Name = "cmbAsistentes";
            this.cmbAsistentes.Size = new System.Drawing.Size(108, 24);
            this.cmbAsistentes.TabIndex = 1;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(21, 67);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(178, 22);
            this.dtpFecha.TabIndex = 2;
            // 
            // cmbHoras
            // 
            this.cmbHoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoras.FormattingEnabled = true;
            this.cmbHoras.Location = new System.Drawing.Point(21, 108);
            this.cmbHoras.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbHoras.Name = "cmbHoras";
            this.cmbHoras.Size = new System.Drawing.Size(108, 24);
            this.cmbHoras.TabIndex = 3;
            // 
            // GerenteCitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.cmbHoras);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.cmbAsistentes);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GerenteCitas";
            this.Text = "GerenteCitas";
            this.Load += new System.EventHandler(this.GerenteCitas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbAsistentes;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cmbHoras;
    }
}