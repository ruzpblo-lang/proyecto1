using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class FormInventarioCuenta : Form
    {
        public AppBancaria gestorempresa;
        public FormInventarioCuenta(AppBancaria gestorempresa)
        {
            InitializeComponent();
            this.gestorempresa = gestorempresa;
        }

        private void FormInventarioCuenta_Load(object sender, EventArgs e)
        {
            dgvInventarioCuenta.DataSource = gestorempresa.GetInventarioCliente();
            dgvInventarioCuenta.Columns["CuentaId"].Visible = false;
            dgvInventarioCuenta.Columns["ClienteId"].Visible = false;

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarCliente forms = new AgregarCliente(gestorempresa);
            forms.ShowDialog();
            dgvInventarioCuenta.DataSource = gestorempresa.GetInventarioCliente();
        }
    }
}
