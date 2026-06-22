namespace Proyecto
{
    partial class FormAgenda
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.agendarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.citaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.misEventosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvCitas = new System.Windows.Forms.DataGridView();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gerenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.citarProvedoorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.citarEmpleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.citarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agendarToolStripMenuItem,
            this.misEventosToolStripMenuItem,
            this.gerenciaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(663, 35);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // agendarToolStripMenuItem
            // 
            this.agendarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.citaToolStripMenuItem,
            this.eventoToolStripMenuItem});
            this.agendarToolStripMenuItem.Name = "agendarToolStripMenuItem";
            this.agendarToolStripMenuItem.Size = new System.Drawing.Size(96, 29);
            this.agendarToolStripMenuItem.Text = "Agendar";
            // 
            // citaToolStripMenuItem
            // 
            this.citaToolStripMenuItem.Name = "citaToolStripMenuItem";
            this.citaToolStripMenuItem.Size = new System.Drawing.Size(168, 34);
            this.citaToolStripMenuItem.Text = "Cita";
            // 
            // eventoToolStripMenuItem
            // 
            this.eventoToolStripMenuItem.Name = "eventoToolStripMenuItem";
            this.eventoToolStripMenuItem.Size = new System.Drawing.Size(168, 34);
            this.eventoToolStripMenuItem.Text = "Evento";
            // 
            // misEventosToolStripMenuItem
            // 
            this.misEventosToolStripMenuItem.Name = "misEventosToolStripMenuItem";
            this.misEventosToolStripMenuItem.Size = new System.Drawing.Size(123, 29);
            this.misEventosToolStripMenuItem.Text = "Mis eventos";
            // 
            // dgvCitas
            // 
            this.dgvCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCitas.Location = new System.Drawing.Point(39, 149);
            this.dgvCitas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCitas.Name = "dgvCitas";
            this.dgvCitas.RowHeadersWidth = 62;
            this.dgvCitas.Size = new System.Drawing.Size(572, 331);
            this.dgvCitas.TabIndex = 2;
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(39, 517);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(84, 29);
            this.btnInfo.TabIndex = 4;
            this.btnInfo.Text = "Info";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMenu.Location = new System.Drawing.Point(526, 517);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(84, 29);
            this.btnMenu.TabIndex = 4;
            this.btnMenu.Text = "Menú";
            this.btnMenu.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "-- CITAS --";
            // 
            // cmbCliente
            // 
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(98, 108);
            this.cmbCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(180, 28);
            this.cmbCliente.TabIndex = 5;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente:";
            // 
            // gerenciaToolStripMenuItem
            // 
            this.gerenciaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.citarProvedoorToolStripMenuItem,
            this.citarEmpleadosToolStripMenuItem,
            this.citarClienteToolStripMenuItem});
            this.gerenciaToolStripMenuItem.Name = "gerenciaToolStripMenuItem";
            this.gerenciaToolStripMenuItem.Size = new System.Drawing.Size(95, 29);
            this.gerenciaToolStripMenuItem.Text = "Gerencia";
            // 
            // citarProvedoorToolStripMenuItem
            // 
            this.citarProvedoorToolStripMenuItem.Name = "citarProvedoorToolStripMenuItem";
            this.citarProvedoorToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.citarProvedoorToolStripMenuItem.Text = "citarProvedoor";
            this.citarProvedoorToolStripMenuItem.Click += new System.EventHandler(this.citarProvedoorToolStripMenuItem_Click);
            // 
            // citarEmpleadosToolStripMenuItem
            // 
            this.citarEmpleadosToolStripMenuItem.Name = "citarEmpleadosToolStripMenuItem";
            this.citarEmpleadosToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.citarEmpleadosToolStripMenuItem.Text = "citarEmpleados";
            this.citarEmpleadosToolStripMenuItem.Click += new System.EventHandler(this.citarEmpleadosToolStripMenuItem_Click);
            // 
            // citarClienteToolStripMenuItem
            // 
            this.citarClienteToolStripMenuItem.Name = "citarClienteToolStripMenuItem";
            this.citarClienteToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.citarClienteToolStripMenuItem.Text = "citarCliente";
            this.citarClienteToolStripMenuItem.Click += new System.EventHandler(this.citarClienteToolStripMenuItem_Click);
            // 
            // FormAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 590);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.dgvCitas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormAgenda";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormAgenda_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem agendarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem citaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem misEventosToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvCitas;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem gerenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem citarProvedoorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem citarEmpleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem citarClienteToolStripMenuItem;
    }
}