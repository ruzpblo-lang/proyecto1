namespace Proyecto
{
    partial class FormInventario
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
            this.btnInventarioDeposito = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInventarioBanco = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.btnInventarioDeposito);
            this.groupBox1.Controls.Add(this.btnMenu);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnInventarioBanco);
            this.groupBox1.Location = new System.Drawing.Point(0, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(307, 220);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnInventarioDeposito
            // 
            this.btnInventarioDeposito.Location = new System.Drawing.Point(18, 102);
            this.btnInventarioDeposito.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInventarioDeposito.Name = "btnInventarioDeposito";
            this.btnInventarioDeposito.Size = new System.Drawing.Size(262, 19);
            this.btnInventarioDeposito.TabIndex = 5;
            this.btnInventarioDeposito.Text = "InventarioDeposito";
            this.btnInventarioDeposito.UseVisualStyleBackColor = true;
            this.btnInventarioDeposito.Click += new System.EventHandler(this.btnInventarioDeposito_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(237, 190);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(56, 19);
            this.btnMenu.TabIndex = 4;
            this.btnMenu.Text = "Menú";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inventario";
            // 
            // btnInventarioBanco
            // 
            this.btnInventarioBanco.Location = new System.Drawing.Point(18, 63);
            this.btnInventarioBanco.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInventarioBanco.Name = "btnInventarioBanco";
            this.btnInventarioBanco.Size = new System.Drawing.Size(262, 22);
            this.btnInventarioBanco.TabIndex = 0;
            this.btnInventarioBanco.Text = "Inventario del Banco";
            this.btnInventarioBanco.UseVisualStyleBackColor = true;
            this.btnInventarioBanco.Click += new System.EventHandler(this.btnInventarioBanco_Click);
            // 
            // FormInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 223);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormInventario";
            this.Text = "FormInventario";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInventarioBanco;
        private System.Windows.Forms.Button btnInventarioDeposito;
    }
}