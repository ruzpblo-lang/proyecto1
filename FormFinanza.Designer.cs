namespace Proyecto
{
    partial class FormFinanza
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
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.egresosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcarComoCompletadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button6 = new System.Windows.Forms.Button();
            this.CmbTipopago = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbEstado = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.CmbMes = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btCM = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "-- PAGOS --";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(969, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresosToolStripMenuItem,
            this.egresosToolStripMenuItem,
            this.marcarComoCompletadoToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.reportesToolStripMenuItem.Text = "Pagos";
            // 
            // ingresosToolStripMenuItem
            // 
            this.ingresosToolStripMenuItem.Name = "ingresosToolStripMenuItem";
            this.ingresosToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.ingresosToolStripMenuItem.Text = "Agregar pago";
            this.ingresosToolStripMenuItem.Click += new System.EventHandler(this.ingresosToolStripMenuItem_Click);
            // 
            // egresosToolStripMenuItem
            // 
            this.egresosToolStripMenuItem.Name = "egresosToolStripMenuItem";
            this.egresosToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.egresosToolStripMenuItem.Text = "Eliminar pago";
            this.egresosToolStripMenuItem.Click += new System.EventHandler(this.egresosToolStripMenuItem_Click);
            // 
            // marcarComoCompletadoToolStripMenuItem
            // 
            this.marcarComoCompletadoToolStripMenuItem.Name = "marcarComoCompletadoToolStripMenuItem";
            this.marcarComoCompletadoToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.marcarComoCompletadoToolStripMenuItem.Text = "Agregar al carrito";
            this.marcarComoCompletadoToolStripMenuItem.Click += new System.EventHandler(this.marcarComoCompletadoToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 43);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(647, 290);
            this.dataGridView1.TabIndex = 3;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button6.Location = new System.Drawing.Point(23, 363);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 4;
            this.button6.Text = "Menú";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // CmbTipopago
            // 
            this.CmbTipopago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipopago.FormattingEnabled = true;
            this.CmbTipopago.Location = new System.Drawing.Point(723, 75);
            this.CmbTipopago.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CmbTipopago.Name = "CmbTipopago";
            this.CmbTipopago.Size = new System.Drawing.Size(121, 24);
            this.CmbTipopago.TabIndex = 5;
            this.CmbTipopago.SelectedIndexChanged += new System.EventHandler(this.CmbTipopago_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(720, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "-- TIPO DE PAGO --";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(703, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "-- ESTADO DEL PAGO--";
            // 
            // CmbEstado
            // 
            this.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEstado.FormattingEnabled = true;
            this.CmbEstado.Location = new System.Drawing.Point(724, 132);
            this.CmbEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CmbEstado.Name = "CmbEstado";
            this.CmbEstado.Size = new System.Drawing.Size(121, 24);
            this.CmbEstado.TabIndex = 5;
            this.CmbEstado.SelectedIndexChanged += new System.EventHandler(this.CmbEstado_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.CmbMes);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btCM);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.CmbEstado);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CmbTipopago);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(0, 31);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(964, 410);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(506, 338);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(164, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Ingresos vs egresos";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(715, 271);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 28);
            this.button1.TabIndex = 11;
            this.button1.Text = "Agregar ingreso";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CmbMes
            // 
            this.CmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMes.FormattingEnabled = true;
            this.CmbMes.Location = new System.Drawing.Point(723, 183);
            this.CmbMes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CmbMes.Name = "CmbMes";
            this.CmbMes.Size = new System.Drawing.Size(121, 24);
            this.CmbMes.TabIndex = 10;
            this.CmbMes.SelectedIndexChanged += new System.EventHandler(this.CmbMes_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(701, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "-- MES SELECCIONADO--";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Dinero Actual:";
            // 
            // btCM
            // 
            this.btCM.Location = new System.Drawing.Point(716, 226);
            this.btCM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btCM.Name = "btCM";
            this.btCM.Size = new System.Drawing.Size(139, 25);
            this.btCM.TabIndex = 6;
            this.btCM.Text = "Realizar Pagos";
            this.btCM.UseVisualStyleBackColor = true;
            this.btCM.Click += new System.EventHandler(this.btCM_Click);
            // 
            // FormFinanza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 439);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormFinanza";
            this.Text = "FormFinanza";
            this.Load += new System.EventHandler(this.FormFinanza_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem egresosToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox CmbTipopago;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbEstado;
        private System.Windows.Forms.ToolStripMenuItem marcarComoCompletadoToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btCM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbMes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}