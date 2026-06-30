namespace Proyecto
{
    partial class AppBancaria
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnFinanzas = new System.Windows.Forms.Button();
            this.btnGestionarPersonal = new System.Windows.Forms.Button();
            this.btnConsultarAgenda = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(493, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aplicacion de gestion de una sucursal bancaria de uso administrativo";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.btnInventario);
            this.groupBox1.Controls.Add(this.btnFinanzas);
            this.groupBox1.Controls.Add(this.btnGestionarPersonal);
            this.groupBox1.Controls.Add(this.btnConsultarAgenda);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(190, 145);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(522, 321);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnInventario
            // 
            this.btnInventario.Location = new System.Drawing.Point(28, 218);
            this.btnInventario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(465, 41);
            this.btnInventario.TabIndex = 4;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.UseVisualStyleBackColor = true;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnFinanzas
            // 
            this.btnFinanzas.Location = new System.Drawing.Point(28, 169);
            this.btnFinanzas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFinanzas.Name = "btnFinanzas";
            this.btnFinanzas.Size = new System.Drawing.Size(465, 41);
            this.btnFinanzas.TabIndex = 3;
            this.btnFinanzas.Text = "Comprobar finanzas";
            this.btnFinanzas.UseVisualStyleBackColor = true;
            this.btnFinanzas.Click += new System.EventHandler(this.btnFinanzas_Click);
            // 
            // btnGestionarPersonal
            // 
            this.btnGestionarPersonal.Location = new System.Drawing.Point(28, 121);
            this.btnGestionarPersonal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGestionarPersonal.Name = "btnGestionarPersonal";
            this.btnGestionarPersonal.Size = new System.Drawing.Size(465, 41);
            this.btnGestionarPersonal.TabIndex = 2;
            this.btnGestionarPersonal.Text = "Gestionar personal";
            this.btnGestionarPersonal.UseVisualStyleBackColor = true;
            this.btnGestionarPersonal.Click += new System.EventHandler(this.btnGestionarPersonal_Click);
            // 
            // btnConsultarAgenda
            // 
            this.btnConsultarAgenda.Location = new System.Drawing.Point(28, 72);
            this.btnConsultarAgenda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConsultarAgenda.Name = "btnConsultarAgenda";
            this.btnConsultarAgenda.Size = new System.Drawing.Size(465, 41);
            this.btnConsultarAgenda.TabIndex = 1;
            this.btnConsultarAgenda.Text = "Consultar agenda";
            this.btnConsultarAgenda.UseVisualStyleBackColor = true;
            this.btnConsultarAgenda.Click += new System.EventHandler(this.btnConsultarAgenda_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Menu";
            // 
            // AppBancaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AppBancaria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AppBancaria";
            this.Load += new System.EventHandler(this.AppBancaria_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnFinanzas;
        private System.Windows.Forms.Button btnGestionarPersonal;
        private System.Windows.Forms.Button btnConsultarAgenda;
        private System.Windows.Forms.Label label2;
    }
}

