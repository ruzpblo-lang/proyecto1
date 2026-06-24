namespace Proyecto
{
    partial class FormPersonal
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
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnbusqueda = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarCuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bajaCuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarCuentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpersonal)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvpersonal
            // 
            this.dgvpersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpersonal.Location = new System.Drawing.Point(45, 31);
            this.dgvpersonal.Name = "dgvpersonal";
            this.dgvpersonal.RowHeadersWidth = 51;
            this.dgvpersonal.Size = new System.Drawing.Size(657, 220);
            this.dgvpersonal.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lista de Empleados";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Turquoise;
            this.button3.Location = new System.Drawing.Point(362, 260);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(68, 30);
            this.button3.TabIndex = 5;
            this.button3.Text = "Menú";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnbusqueda
            // 
            this.btnbusqueda.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnbusqueda.Location = new System.Drawing.Point(45, 263);
            this.btnbusqueda.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnbusqueda.Name = "btnbusqueda";
            this.btnbusqueda.Size = new System.Drawing.Size(84, 27);
            this.btnbusqueda.TabIndex = 5;
            this.btnbusqueda.Text = "FILTRADO";
            this.btnbusqueda.UseVisualStyleBackColor = false;
            this.btnbusqueda.Click += new System.EventHandler(this.btnbusqueda_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem,
            this.clientesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(744, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.aToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem,
            this.quitarToolStripMenuItem});
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(59, 22);
            this.aToolStripMenuItem.Text = "Gestion";
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.agregarToolStripMenuItem.Text = "Agregar Empleados";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // quitarToolStripMenuItem
            // 
            this.quitarToolStripMenuItem.Name = "quitarToolStripMenuItem";
            this.quitarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quitarToolStripMenuItem.Text = "Quitar Empleado";
            this.quitarToolStripMenuItem.Click += new System.EventHandler(this.quitarToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarClienteToolStripMenuItem,
            this.agregarCuentaToolStripMenuItem,
            this.mostrarClienteToolStripMenuItem,
            this.bajaClienteToolStripMenuItem,
            this.bajaCuentaToolStripMenuItem,
            this.mostrarCuentasToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // agregarClienteToolStripMenuItem
            // 
            this.agregarClienteToolStripMenuItem.Name = "agregarClienteToolStripMenuItem";
            this.agregarClienteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.agregarClienteToolStripMenuItem.Text = "Agregar Cliente";
            this.agregarClienteToolStripMenuItem.Click += new System.EventHandler(this.agregarClienteToolStripMenuItem_Click);
            // 
            // agregarCuentaToolStripMenuItem
            // 
            this.agregarCuentaToolStripMenuItem.Name = "agregarCuentaToolStripMenuItem";
            this.agregarCuentaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.agregarCuentaToolStripMenuItem.Text = "Agregar Cuenta";
            this.agregarCuentaToolStripMenuItem.Click += new System.EventHandler(this.agregarCuentaToolStripMenuItem_Click);
            // 
            // mostrarClienteToolStripMenuItem
            // 
            this.mostrarClienteToolStripMenuItem.Name = "mostrarClienteToolStripMenuItem";
            this.mostrarClienteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mostrarClienteToolStripMenuItem.Text = "Mostrar Cliente";
            this.mostrarClienteToolStripMenuItem.Click += new System.EventHandler(this.mostrarClienteToolStripMenuItem_Click);
            // 
            // bajaClienteToolStripMenuItem
            // 
            this.bajaClienteToolStripMenuItem.Name = "bajaClienteToolStripMenuItem";
            this.bajaClienteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bajaClienteToolStripMenuItem.Text = "Baja Cliente";
            this.bajaClienteToolStripMenuItem.Click += new System.EventHandler(this.bajaClienteToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 269);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Filtrar por puesto";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.dgvpersonal);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnbusqueda);
            this.groupBox1.Location = new System.Drawing.Point(0, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 324);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // bajaCuentaToolStripMenuItem
            // 
            this.bajaCuentaToolStripMenuItem.Name = "bajaCuentaToolStripMenuItem";
            this.bajaCuentaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bajaCuentaToolStripMenuItem.Text = "Baja Cuenta";
            this.bajaCuentaToolStripMenuItem.Click += new System.EventHandler(this.bajaCuentaToolStripMenuItem_Click);
            // 
            // mostrarCuentasToolStripMenuItem
            // 
            this.mostrarCuentasToolStripMenuItem.Name = "mostrarCuentasToolStripMenuItem";
            this.mostrarCuentasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mostrarCuentasToolStripMenuItem.Text = "Mostrar cuentas";
            // 
            // FormPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 381);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "FormPersonal";
            this.Text = "Gestion de Personal";
            this.Load += new System.EventHandler(this.FormPersonal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvpersonal)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvpersonal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnbusqueda;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitarToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarCuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaCuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarCuentasToolStripMenuItem;
    }
}